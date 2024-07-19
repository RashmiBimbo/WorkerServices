using CommonCode.Config;
using Newtonsoft.Json.Linq;
using static System.DateTime;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;
using System.Data;

namespace SqlIntegrationServices
{
    internal class BaseWorker : BackgroundService
    {
        protected int ExecutionCount;
        protected ServiceDbContext cntxt;
        protected string msg;
        protected readonly string logFile;
        protected readonly double period = 30;
        protected readonly IServiceScopeFactory serviceScopeFactory;
        protected readonly ILogger<BaseWorker> logger;
        protected Timer timer;
        protected Thread BackgroundThread;
        private CancellationTokenSource? _stoppingCts;
        //protected readonly ServiceConfiguration ServiceConfig;
        protected readonly ServiceDetail ServiceConfig;
        private readonly string ServiceName, ServiceEndpoint, ServiceTbl;

        public BaseWorker(IServiceScopeFactory serviceScopeFactory, ILogger<BaseWorker> logger, ServiceDetail ServiceConfiguration)
        {
            //ServiceEndpoint = ServiceDetail.ServiceConfiguration.Table.Replace("Test", string.Empty, StringComparison.OrdinalIgnoreCase);
            //ServiceName = Regex.Replace(ServiceEndpoint, "(\\B[A-Z])", " $1");

            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
            ServiceConfig = ServiceConfiguration;
            DateTimeOffset now = DateTimeOffset.Now;
            string lstMnth = now.AddMonths(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
            ServiceEndpoint = ServiceConfig.Endpoint + (!IsEmpty(ServiceConfig.QueryString) ? "?" + ServiceConfig.QueryString : "");
            ServiceTbl = ServiceConfig.Table;
            logFile = AppDomain.CurrentDomain.BaseDirectory + $"{ServiceTbl.Replace("Test", Emp)}Service_Log.txt";
            ServiceName = ServiceConfig.Name;
            period = ServiceConfig.Period;
            try
            {
                if (!File.Exists(logFile)) File.Create(logFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Now}: {ex?.Message} \r\n {ex?.StackTrace}");
            }
        }

        protected void LogInfo(string msg)
        {
            try
            {
                logger.LogInformation(msg);
                File.AppendAllText(logFile, "\r\n" + msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Now}: {ex?.Message} \r\n {ex?.StackTrace}");
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            // Create linked token to allow cancelling executing tsk from provided token
            _stoppingCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            BackgroundThread = new Thread(async () =>
            {
                try
                {
                    await ExecuteAsync(_stoppingCts.Token);
                }
                catch (Exception ex)
                {
                    LogInfo($"\r\n{Now}: An error occurred in the background service.");
                }
            })
            {
                IsBackground = true
            };
            BackgroundThread.Start();

            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string resource = "https://mfprod.operations.dynamics.com";
            try
            {
                // When the timer should have no due-time, then do the work once now.
                using PeriodicTimer timer = new(TimeSpan.FromMinutes(period));
                do
                {
                    int count = Interlocked.Increment(ref ExecutionCount);
                    string url = $"{resource}/data/{ServiceEndpoint}";

                    string msg = $"{Now}: {ServiceName} Service is running; Count: {count}";
                    LogInfo(msg);

                    var startTime = Now;
                    msg = $"{Now}: Data migration started.";
                    LogInfo(msg);

                    int i = 0;
                    while (!IsEmpty(url))
                    {
                        LogInfo($"\r\n{Now}: API iteration no. {++i}");
                        url = await DoWork(resource, url);
                        //i++;
                    }
                    var endTime = Now;
                    var elapsedTime = endTime - startTime;

                    LogInfo($"\r\n{Now}: Data migration completed."
                          + $"\r\n{Now}: No. of times api executed : {i}"
                          + $"\r\n{Now}: Task execution time: {elapsedTime}"
                          + $"\r\n{Now}: Next iteration will start after {period} minutes at {Now.AddMinutes(period)}"
                          + "\r\n***********************************************************\r\n");
                    await Task.Delay(TimeSpan.FromMinutes(period), stoppingToken);
                }
                while (await timer.WaitForNextTickAsync(stoppingToken));
            }
            catch (Exception ex)
            {
                LogInfo($"{Now}: Error: {ex?.Message} + \r\n {ex?.StackTrace}");
            }
            finally
            {
                LogInfo($"{Now}: {ServiceName} Service stopped.");
            }
        }


        protected async virtual Task<string> DoWork(string resource, string url)
        {
            string result = Emp;
            for (int cnt = 1; cnt <= 2; cnt++)
            {
                result = await GetJson(resource, url);
                if (!IsEmpty(result))
                    break;
                else if (cnt < 2)
                {
                    LogInfo($"{Now}: Error: Getting JSON failed! Retrying...");
                }
            }
            await JsonToDb(result);
            if (IsEmpty(result)) return Emp;
            string[] strArr = result.Split("@odata.nextLink");
            if (strArr.Length > 1 && !IsEmpty(strArr[1]))
            {
                string? nxtUrl = strArr?[1]?.Replace("\":\"", Emp).Replace("\"\r\n}", Emp);
                return !IsEmpty(nxtUrl) ? nxtUrl : Emp;
            }
            else return Emp;
        }

        protected async virtual Task JsonToDb(string result)
        {
            //File.WriteAllText("SalesInvoiceHeaders_JSON.txt", tblExists);
            if (IsEmpty(result))
            {
                LogInfo($"{Now}: Error: The response JSON string is empty. Returning...");
                return;
            }
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    ServiceDbContext context = scope.ServiceProvider.GetRequiredService<ServiceDbContext>();

                    var strategy = context.Database.CreateExecutionStrategy();

                    await strategy.ExecuteAsync(async () => await Transact(context, result));
                }
                //await Transact(result);
            }
            catch (Exception ex)
            {
                LogInfo($"{Now} : Error: {ex?.Message} + \r\n {ex?.StackTrace}");
            }
        }

        protected async virtual Task Transact(ServiceDbContext context, string result)
        {
            try
            {
                JObject obj = JObject.Parse(result);
                JArray Items = (JArray)obj["value"];

                int i = Items.Count;
                List<long> cnts = await JsonToDb(context, Items, ServiceConfig.Table);
                long updtCnt = cnts[1], addCnt = cnts[0];

                using var transaction = await context.Database.BeginTransactionAsync();
                {
                    for (int cnt = 1; cnt <= 2; cnt++)
                    {
                        try
                        {
                            await context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            break;
                        }
                        catch (Exception ex)
                        {
                            LogInfo($"{Now}: Error: {ex?.Message} + \r\n {ex.StackTrace}");
                            if (cnt < 2)
                            {
                                string msg = $"{Now}: Error: Saving changes failed! Retrying...";
                                LogInfo(msg);
                            }
                            else
                            {
                                await transaction.RollbackAsync();
                                return;
                            }
                        }
                    }
                }
                msg = $"\r\n{Now}: Success: Saved data successfully." +
                      $"\r\n{Now}: Total no. of records tracked:{i}" +
                      $"\r\n{Now}: Total no. of records added: {addCnt}" +
                      $"\r\n{Now}: Total no. of records updated: {updtCnt}\r\n";

                LogInfo(msg);
            }
            catch (Exception ex)
            {
                LogInfo($"{Now}: Error: {ex?.Message} + \r\n {ex?.StackTrace}");
            }
        }

        protected async Task<List<long>> JsonToDb(ServiceDbContext context, JArray Items, string tableName)
        {
            string currentNamespace = typeof(BaseWorker).Namespace;
            string typeName = $"{currentNamespace}.{tableName}";
            try
            {
                Type entityType = Type.GetType(typeName, throwOnError: false, ignoreCase: true);

                Type t = Type.GetType(typeName, throwOnError: false, ignoreCase: true) ?? throw new InvalidOperationException($"Type {typeName} not found");
                MethodInfo method = this.GetType().GetMethod(nameof(UpdateTbl), BindingFlags.Instance | BindingFlags.NonPublic);
                MethodInfo genericMethod = method.MakeGenericMethod(t);
                Task<List<long>> resultTask = (Task<List<long>>)genericMethod.Invoke(this, [context, Items]);
                return await resultTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected async Task<List<long>> UpdateTbl<T>(ServiceDbContext context, JArray Items) where T : class, new()
        {
            long addCnt = 0, updtCnt = 0;
            T ent;
            Expression<Func<T, bool>> exp;
            try
            {
                if (!await CheckTableExistsOrAltered<T>(context))
                {
                    //LogInfo($"\r\n{Now}: Error: Could not find or create or alter the table {ServiceConfig.Table}!");
                    throw new Exception($"Could not find or create or alter the table {ServiceConfig.Table}!");
                }

                DbSet<T> dbSet = context.Set<T>();
                List<PropertyInfo> primaryKeyProperties = GetPrimaryKeyProperties(typeof(T));

                foreach (var itm in Items)
                {
                    string itmJsn;
                    T existingEntity = null;

                    for (int cnt = 1; cnt <= 2; cnt++)
                    {
                        try
                        {
                            itmJsn = Serialize.ToJson(itm);
                            T poco = DeserializeJson<T>.Deserialize(itmJsn);

                            if (poco is null) continue;
                            foreach (var pkProp in primaryKeyProperties)
                            {
                                var value = pkProp.GetValue(poco);
                                if (value == null)
                                {
                                    LogInfo($"{Now}: Error: Primary key property '{pkProp.Name}' is null.");
                                    continue;
                                }
                            }

                            exp = GetPrimaryKeyComparisonExpression(poco, primaryKeyProperties);

                            // Find existing entity in the database
                            if (dbSet.Any())
                                existingEntity = dbSet?.AsNoTracking()?.FirstOrDefault(exp);

                            // Check if the entity exists in the database
                            if ((dbSet.Local.Count < 1) || (!dbSet.Local.AsQueryable().Any(exp)))
                            {
                                ent = PrepareEntity(poco);
                                if (ent is null) continue;

                                if (existingEntity is null) // Add the new entity
                                {
                                    dbSet.Add(ent);
                                    addCnt++;
                                }
                                else // Update the existing entity if modified
                                {
                                    if (typeof(T).GetProperties().Any(p => p.Name == "ModifiedDateTime1"))
                                        if (((poco as dynamic).ModifiedDateTime1 != null) && !((existingEntity as dynamic).ModifiedDateTime1 != null) && ((poco as dynamic).ModifiedDateTime1 > (existingEntity as dynamic).ModifiedDateTime1))
                                        {
                                            context.Entry(existingEntity).CurrentValues.SetValues(ent);
                                            updtCnt++;
                                        }
                                }
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            LogInfo($"{Now}: Error: {ex?.Message} + \r\n {ex?.StackTrace}");
                            if (cnt < 2)
                                LogInfo($"{Now}: Saving entity failed. Retrying...");
                        }
                    }
                }
                return [addCnt, updtCnt];
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected async Task<bool> CheckTableExistsOrAltered<T>(ServiceDbContext context) where T : class
        {
            bool success = false;
            for (int i = 1; i <= 2; i++)
                try
                {
                    IEntityType entityType = context.Model.FindEntityType(typeof(T));
                    string tblName = entityType.GetTableName();
                    string schemaName = entityType.GetSchema() ?? "dbo"; // Use default schemaName if none is specified

                    string sql = "SELECT CASE WHEN EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = @schemaName AND TABLE_NAME = @tblName) THEN 1 ELSE 0 END";

                    SqlParameter schema = new("@schemaName", schemaName);
                    SqlParameter table = new("@tblName", tblName);

                    // Check the tblExists (1 means the table exists, 0 means it doesn't)
                    success = context.Database.SqlQueryRaw<int>(sql, [schema, table])?.ToList()?[0] == 1;

                    if (success)
                    {
                        if (ServiceConfig.Altered)
                        {
                            success = await AlterTable(context, entityType);
                            ServiceConfig.Altered = !success;
                            string jsn = JsonConvert.SerializeObject(ServiceConfig);
                        }
                        return success;
                    }
                    success = await CreateTbl<T>(context, entityType, tblName, schemaName);
                    return success;
                }
                catch (Exception ex)
                {
                    string msg = $"{Now}: Error checking if table exists: {ex.Message} \r\n {ex.StackTrace}";
                    // Log the error if necessary
                    if (i == 2)
                    {
                        LogInfo(msg);
                        success = false;
                    }
                    else
                    {
                        msg += "Retrying...";
                        LogInfo(msg);
                    }
                }
            return success;
        }

        private async Task<bool> CreateTable<T>(ServiceDbContext context, IEntityType entityType, string tblName, String schemaName = "dbo")
        {
            try
            {
                string sql = @$"CREATE TABLE [{schemaName}].[{tblName}] (";

                var properties = entityType.GetProperties();

                foreach (var prop in properties)
                {
                    string colName = prop.GetColumnName();
                    string colType = prop.GetColumnType() ?? GetColumnType(prop);
                    bool isNull = prop.IsNullable;
                    string colDef = $" [{colName}] {colType.ToUpper()}";
                    colDef += (isNull ? " NULL," : " NOT NULL,");
                    //colDef += properties.Last() == prop ? "" : ",";
                    sql += colDef;
                }
                List<PropertyInfo> keyProps = GetPrimaryKeyProperties(typeof(T));
                if (keyProps != null && keyProps.Count > 0)
                {
                    sql += " PRIMARY KEY CLUSTERED (";
                    keyProps.ForEach(p => sql += $"[{p.Name}] ASC" + (keyProps.Last() == p ? ")" : ", "));
                }
                else
                    sql = sql.Remove(sql.Length - 1);

                sql += ");";

                return await ExecuteQuery(context, sql);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<bool> ExecuteQuery(ServiceDbContext context, string query)
        {
            try
            {
                await context.Database.ExecuteSqlRawAsync(query);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetColumnType(IProperty property)
        {
            Type clrType = property.ClrType;

            if (clrType == typeof(string))
                return $"nvarchar({(property.GetMaxLength().ToString() ?? "max")})";
            if (clrType == typeof(char))
                return $"nchar(1)";
            if (clrType == typeof(char[]))
                return $"nvarchar({(property.GetMaxLength().ToString() ?? "max")})";
            if (clrType == typeof(int)) return "int";
            if (clrType == typeof(short)) return "smallint";
            if (clrType == typeof(byte)) return "tinyint";
            if (clrType == typeof(sbyte)) return "tinyint";
            if (clrType == typeof(long)) return "bigint";
            if (clrType == typeof(float)) return "real";
            if (clrType == typeof(double)) return "float";
            if (clrType == typeof(bool)) return "bit";
            if (clrType == typeof(Guid)) return "uniqueidentifier";
            if (clrType == typeof(decimal)) return "decimal(18, 2)";
            if (clrType == typeof(DateTime)) return "datetime";
            if (clrType == typeof(DateTimeOffset)) return "datetimeoffset";
            if (clrType == typeof(TimeSpan)) return "time";
            if (clrType == typeof(object)) return "sql_variant";
            if (clrType == typeof(byte[]))
                return $"varbinary({property.GetMaxLength().ToString() ?? "max"})";
            if (clrType.IsEnum)
                return "int";

            throw new NotSupportedException($"Unsupported CLR type: {clrType.Name}");
        }

        protected T? PrepareEntity<T>(T poco) where T : class, new()
        {
            try
            {
                T ent = new T();
                foreach (var col in ServiceConfig.Columns)
                {
                    string propName = col.Name;
                    var propInfo = typeof(T).GetProperty(propName);
                    if (propInfo != null && col.Include)
                    {
                        var val = propInfo.GetValue(poco);
                        propInfo.SetValue(ent, val, null);
                    }
                }
                return ent;
            }
            catch (Exception ex)
            {
                LogInfo($"{Now}: Error: {ex?.Message} + \r\n {ex?.StackTrace}");
                return default;
            }
        }

        // Method to get the primary key comparison expression
        protected Expression<Func<T, bool>> GetPrimaryKeyComparisonExpression<T>(T poco, List<PropertyInfo> primaryKeyProperties)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(T), "e");

                Expression body = null;

                foreach (var keyProperty in primaryKeyProperties)
                {
                    var pocoValue = keyProperty.GetValue(poco);
                    var left = Expression.Property(parameter, keyProperty.Name);
                    var right = Expression.Constant(pocoValue, keyProperty.PropertyType);
                    var equal = Expression.Equal(left, right);

                    body = body == null ? equal : Expression.AndAlso(body, equal);
                }

                return Expression.Lambda<Func<T, bool>>(body, parameter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Method to get primary key properties of a type
        protected List<PropertyInfo> GetPrimaryKeyProperties(Type type)
        {
            try
            {
                return type.GetProperties()
                               .Where(prop => prop.IsDefined(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), true))
                               .ToList();
                //return type.GetCustomAttributes<PrimaryKeyAttribute>().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            LogInfo($"{Now}: {ServiceName} Service is stopping.");
            return base.StopAsync(cancellationToken);
        }

        public async Task<bool> CreateTbl<T>(ServiceDbContext context, IEntityType entityType, string tblName, String schemaName = "dbo") where T : class
        {
            // Get table name and schema
            try
            {
                var tableName = entityType.GetTableName();
                var schema = entityType.GetSchema() ?? "dbo"; // Default schema is dbo if not specified

                var createTableSql = new StringBuilder();
                createTableSql.AppendLine($"CREATE TABLE [{schema}].[{tableName}] (");

                var primaryKeyProperties = entityType.FindPrimaryKey()?.Properties ?? Enumerable.Empty<IProperty>();

                // Iterate over properties to construct columns
                var properties = entityType.GetProperties();
                foreach (var property in properties)
                {
                    var columnName = property.GetColumnName();
                    var columnType = property.GetColumnType() ?? GetColumnType(property);
                    var isNullable = property.IsNullable;

                    var columnDefinition = new StringBuilder();
                    columnDefinition.Append($"[{columnName}] {columnType}");

                    if (property.IsConcurrencyToken) // Check if it has RowVersion or other concurrency token
                    {
                        columnDefinition.Append(" ROWVERSION");
                    }
                    else
                    {
                        if (!isNullable)
                        {
                            columnDefinition.Append(" NOT NULL");
                        }

                        var defaultValueSql = property.GetDefaultValueSql();
                        if (!string.IsNullOrEmpty(defaultValueSql))
                        {
                            columnDefinition.Append($" DEFAULT {defaultValueSql}");
                        }
                    }

                    // If it's a single-column primary key with identity
                    if (primaryKeyProperties.Count() == 1 && primaryKeyProperties.Contains(property) && IsKeyIdentity(property))
                    {
                        columnDefinition.Append(" PRIMARY KEY IDENTITY(1,1)");
                    }

                    createTableSql.AppendLine($"{columnDefinition},");
                }

                // Remove trailing comma from the last column definition
                createTableSql.Length -= 1;

                createTableSql.AppendLine(");");

                // If there are multiple columns in the primary key, define the composite key constraint
                if (primaryKeyProperties.Count() > 1)
                {
                    var primaryKeyColumns = string.Join(", ", primaryKeyProperties.Select(p => $"[{p.GetColumnName()}]"));
                    createTableSql.AppendLine($"ALTER TABLE [{schema}].[{tableName}] ADD CONSTRAINT [PK_{tableName}] PRIMARY KEY ({primaryKeyColumns});");
                }

                // Generate unique constraints after the table definition
                foreach (var index in entityType.GetIndexes())
                {
                    if (index.IsUnique)
                    {
                        var uniqueColumns = string.Join(", ", index.Properties.Select(p => $"[{p.GetColumnName()}]"));
                        createTableSql.AppendLine($"ALTER TABLE [{schema}].[{tableName}] ADD CONSTRAINT [UQ_{tableName}_{string.Join("_", index.Properties.Select(p => p.Name))}] UNIQUE ({uniqueColumns});");
                    }
                }

                return await ExecuteQuery(context, createTableSql.ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Utility method to check if a property is an identity column
        private static bool IsKeyIdentity(IProperty property)
        {
            try
            {
                var annotations = property.GetAnnotations();
                return annotations.Any(a => a.Name == "SqlServer:ValueGenerationStrategy" &&
                                             (SqlServerValueGenerationStrategy)a.Value == SqlServerValueGenerationStrategy.IdentityColumn);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Utility method to get additional constraints for a property
        private static string GetConstraints(ServiceDbContext context, IProperty property, IEntityType entityType)
        {
            try
            {
                var constraints = new StringBuilder();

                // Generate unique constraints after the table definition
                foreach (var index in entityType.GetIndexes())
                {
                    if (index.IsUnique)
                    {
                        var uniqueColumns = string.Join(", ", index.Properties.Select(p => $"[{p.GetColumnName()}]"));

                        constraints.AppendLine($"ALTER TABLE [{entityType.GetSchema()}].[{entityType.GetTableName()}] ADD CONSTRAINT [UQ_{entityType.GetTableName()}_{string.Join("_", index.Properties.Select(p => p.Name))}] UNIQUE ({uniqueColumns});");
                    }
                }

                // Check constraint
                var checkConstraint = property.GetAnnotations().FirstOrDefault(a => a.Name.StartsWith("CheckConstraint:"));
                if (checkConstraint != null)
                {
                    constraints.AppendLine($"ALTER TABLE [{property.DeclaringEntityType.GetSchema()}].[{property.DeclaringEntityType.GetTableName()}] ADD CONSTRAINT [CK_{property.Name}] CHECK ({checkConstraint.Value});");
                }

                return constraints.Length > 0 ? constraints.ToString() : null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<bool> AlterTable(ServiceDbContext context, IEntityType entityTyp)
        {
            bool success = true;
            var sql = new StringBuilder();
            string schema = entityTyp.GetSchema() ?? "dbo";
            string tblNm = entityTyp.GetTableName();
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    var crntCols = GetColsFromDbTbl(context, schema, tblNm);
                    if (crntCols != null)
                    {
                        var props = entityTyp.GetProperties();

                        string colDef = Emp;
                        colDef += $"ALTER TABLE [{schema}].[{tblNm}] ADD";
                        foreach (var prop in props)
                        {
                            string name = prop.GetColumnName();
                            if (!crntCols.Keys.Any(key => key.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                            {
                                success = false;
                                string colTyp = prop.GetColumnType() ?? GetColumnType(prop);
                                bool isNull = prop.IsNullable;
                                bool isPK = prop.IsPrimaryKey();
                                colDef += $" [{name}] {colTyp}";
                                if (prop.IsConcurrencyToken) // Check if it has RowVersion or other concurrency token
                                    colDef += " ROWVERSION";
                                else
                                {
                                    if (!isNull)
                                        colDef += " NOT NULL";

                                    if (isPK)
                                        colDef += " PRIMARY KEY";

                                    if (IsKeyIdentity(prop))
                                        colDef += " INDENTY(1, 1)";

                                    var defaultValueSql = prop.GetDefaultValueSql();
                                    if (!string.IsNullOrEmpty(defaultValueSql))
                                    {
                                        colDef += $" DEFAULT {defaultValueSql}";
                                    }
                                }
                                colDef += ",";
                            }
                        }
                        if (!success)
                        {
                            //colDef.Length -= 1;
                            while (colDef.ToString().Replace("\r", string.Empty).Last() == ',')
                                colDef = colDef.Remove(colDef.Length - 1);
                            sql.Append(colDef + ";");
                            success = await ExecuteQuery(context, sql.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (i == 1) throw;
                }
            }
            return success;
        }

        private Dictionary<string, Dictionary<string, string>> GetColsFromDbTbl(ServiceDbContext context, string schema, string tblName)
        {
            Dictionary<string, Dictionary<string, string>> cols = [];
            for (int i = 0; i < 2; i++)
            {
                var conct = context.Database.GetDbConnection();
                try
                {
                    string query = $@"SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA= '{schema}' AND TABLE_NAME = '{tblName}'";
                    conct.ConnectionString = context.Database.GetConnectionString();
                    using var cmd = conct.CreateCommand();
                    cmd.CommandText = query;
                    if (conct.State != ConnectionState.Open) conct.Open();
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var colName = reader["COLUMN_NAME"].ToString();
                        var colTyp = reader["DATA_TYPE"].ToString();
                        var isNull = reader["IS_NULLABLE"].ToString();
                        cols[colName] = new Dictionary<string, string>
                        {
                            { "DataType", colTyp },
                            { "IsNullable", isNull}
                        };
                    }
                }
                catch (Exception ex)
                {
                    //LogInfo($"\r\n{Now} : Error: {ex?.Message} + \\r\\n {ex?.StackTrace}\"");
                    if (i == 1)
                        throw;
                }
                finally
                {
                    conct.Close();
                }
            }
            return cols;
        }
    }

    //                RelationalDatabaseCreator databaseCreator =
    //(RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
    //                databaseCreator.CreateTables();
    //                var ServiceDetail = new DbMigrationsConfiguration<MyContext> { AutomaticMigrationsEnabled = true };
    //                var migrator = new DbMigrator(ServiceDetail); dbm
    //                migrator.Update();
    //                Shar
    //sucess = await context.Database.EnsureCreatedAsync();
}

