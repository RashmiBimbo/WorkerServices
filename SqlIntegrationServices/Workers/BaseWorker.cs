using CommonCode.Config;
using Newtonsoft.Json.Linq;
using static System.DateTime;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Reflection;

namespace SqlIntegrationServices
{
    internal abstract class BaseWorker : BackgroundService
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
        protected readonly ServiceConfiguration config;
        private readonly string ServiceName, ServiceNameOrgnl;

        public BaseWorker(IServiceScopeFactory serviceScopeFactory, ILogger<BaseWorker> logger, Service config)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
            ServiceNameOrgnl = config.ServiceConfiguration.Table.Replace("TestR", string.Empty, StringComparison.OrdinalIgnoreCase);
            this.config = config.ServiceConfiguration;
            logFile = AppDomain.CurrentDomain.BaseDirectory + $"{ServiceName}Service_Log.txt";
            ServiceName = Regex.Replace(ServiceNameOrgnl, "(\\B[A-Z])", " $1");
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
            // Create linked token to allow cancelling executing task from provided token
            _stoppingCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            BackgroundThread = new Thread(async () =>
            {
                try
                {
                    await ExecuteAsync(_stoppingCts.Token);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred in the background service.");
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

                    string url = $"{resource}/data/{ServiceNameOrgnl}";

                    string msg = $"{Now}: {ServiceName} Service is running; Count: {count}";
                    LogInfo(msg);

                    var startTime = DateTimeOffset.Now;
                    msg = $"{Now}: Data migration started.";
                    LogInfo(msg);

                    int i = 0;
                    while (!IsEmpty(url))
                    {
                        LogInfo($"\r\n{Now}: API iteration no. {i + 1}");
                        url = await DoWork(resource, url);
                        i++;
                    }
                    var endTime = DateTimeOffset.Now;
                    var elapsedTime = endTime - startTime;

                    LogInfo($"\r\n{Now}: Data migration completed."
                          + $"\r\n{Now}: No. of times api executed : {i}"
                          + $"\r\n{Now}: Task execution time: {elapsedTime}"
                          + $"\r\n{Now}: Next iteration will start after {period} minutes at {DateTimeOffset.Now.AddMinutes(period)}"
                          + "***********************************************************\r\n");
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

        // Could also be a async method, that can be awaited in ExecuteAsync above
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
                    LogInfo($"{Now}: Getting JSON failed! Retrying...");
                }
            }
            await JsonToDb(result);
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
            //File.WriteAllText("SalesInvoiceHeaders_JSON.txt", result);
            if (IsEmpty(result))
            {
                LogInfo($"{Now}: Error: The response JSON string is empty. Returning...");
                return;
            }
            try
            {
                using var scope = serviceScopeFactory.CreateScope();
                cntxt = scope.ServiceProvider.GetRequiredService<ServiceDbContext>();

                var strategy = cntxt.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () => await Transact(result));
            }
            catch (Exception ex)
            {
                LogInfo($"{Now} : Error: {ex?.Message} + \r\n {ex?.StackTrace}");
            }
        }

        protected async virtual Task Transact(string result)
        {
            try
            {
                using var transaction = await cntxt.Database.BeginTransactionAsync();
                //if (!await CheckTableExists(cntxt)) return;

                JObject obj = JObject.Parse(result);
                JArray Items = (JArray)obj["value"];

                int i = Items.Count;
                string currentNamespace = typeof(Program).Namespace;
                List<long> cnts = await JsonToDbChild(Items, config.Table);
                long updtCnt = cnts[1], addCnt = cnts[0];

                for (int cnt = 1; cnt <= 2; cnt++)
                {
                    try
                    {
                        await cntxt.SaveChangesAsync();
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
                        return;
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

        protected abstract Task<List<long>> JsonToDbChild(JArray Items, string tableName);

        protected async Task<List<long>> UpdateTblHSNCodesTestR<T>(JArray Items, string typ) where T : class, new()
        {
            long addCnt = 0, updtCnt = 0;
            DbSet<T> dbSet = cntxt.Set<T>();
            foreach (var itm in Items)
            {
                string itmJsn;
                T existingEntity = null;

                for (int cnt = 1; cnt <= 2; cnt++)
                {
                    try
                    {
                        itmJsn = Serialize.ToJson(itm);
                        T poco = JsonConvert.DeserializeObject<T>(itmJsn);

                        if (poco is null) continue;
                        Expression<Func<T, bool>> exp = GetPrimaryKeyComparisonExpression(poco);

                        // Find existing entity in the database
                        if (dbSet.Any())
                            existingEntity = await dbSet.AsNoTracking().FirstOrDefaultAsync(exp);

                        // Check if the entity exists in the database
                        if (dbSet.Local.Count < 1 || !dbSet.Local.AsQueryable().Any(exp))
                        {
                            T ent = PrepareEntity(poco);
                            if (ent is null) continue;

                            if (existingEntity is null) // Add the new entity
                            {
                                dbSet.Add(ent);
                                addCnt++;
                            }
                            else // Update the existing entity if modified
                            {
                                if (((poco as dynamic).ModifiedDateTime1 != null) && !((existingEntity as dynamic).ModifiedDateTime1 != null) && ((poco as dynamic).ModifiedDateTime1 > (existingEntity as dynamic).ModifiedDateTime1))
                                {
                                    cntxt.Entry(existingEntity).CurrentValues.SetValues(ent);
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

        protected async Task<bool> CheckTableExists<T>() where T : class
        {
            bool exist = false;
            for (int i = 1; i <= 2; i++)
                try
                {
                    // Get the name of the table associated with the DbSet<T>
                    var entityType = cntxt.Model.FindEntityType(typeof(T));
                    var tableName = entityType.GetTableName();

                    // Build a query to check for the existence of the table
                    var sql = $"SELECT CASE WHEN OBJECT_ID(N'{tableName}', 'U') IS NOT NULL THEN 1 ELSE 0 END";

                    // Execute the query
                    var result = await cntxt.Database.ExecuteSqlRawAsync(sql);

                    // Check the result (1 means the table exists, 0 means it doesn't)
                    exist = result == 1;
                    break;
                }
                catch (Exception ex)
                {
                    // Log the error if necessary
                    LogInfo($"{Now}: Error checking if table exists: {ex.Message} \r\n {ex.StackTrace}");
                    if (i == 2)
                        exist = false;
                }
            return exist;
        }

        protected T? PrepareEntity<T>(T poco) where T : class, new()
        {
            try
            {
                T ent = new T();
                foreach (var col in config.Columns)
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
        protected Expression<Func<T, bool>> GetPrimaryKeyComparisonExpression<T>(T poco)
        {
            var parameter = Expression.Parameter(typeof(T), "e");
            var primaryKeyProperties = GetPrimaryKeyProperties(typeof(T));

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

        // Method to get primary key properties of a type
        protected List<PropertyInfo> GetPrimaryKeyProperties(Type type)
        {
            return type.GetProperties()
                       .Where(prop => prop.IsDefined(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), true))
                       .ToList();
        }

        protected virtual async Task ApplyMigration()
        {
            try
            {
                await cntxt.Database.MigrateAsync();
            }
            catch (Exception ex1)
            {
                LogInfo($"{Now}: Error: {ex1?.Message} + \r\n {ex1.StackTrace}");
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            LogInfo($"{Now}: {ServiceName} Service is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
