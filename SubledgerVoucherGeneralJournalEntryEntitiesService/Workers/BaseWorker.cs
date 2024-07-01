using CommonCode.Config;
using Newtonsoft.Json.Linq;
using static System.DateTime;
using System.Text.RegularExpressions;

namespace SqlIntegrationServices.Workers
{
    internal class BaseWorker : IHostedService, IDisposable
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
        protected readonly CancellationTokenSource cancellationTokenSource;
        protected readonly ServiceConfiguration config;
        private string ServiceName; 
        private string ServiceNameOrgnl; 

        public BaseWorker(IServiceScopeFactory serviceScopeFactory, ILogger<BaseWorker> logger, ServiceConfiguration config)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
            ServiceNameOrgnl = config.Table.Replace("TestR", string.Empty, StringComparison.OrdinalIgnoreCase);
            
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

        public Task StartAsync(CancellationToken cancellationToken)
        {
            BackgroundThread = new Thread(async () =>
            {
                try
                {
                    await ExecuteService(cancellationTokenSource.Token);
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

        protected async virtual Task ExecuteService(CancellationToken stoppingToken)
        {
            //Task.Run(async () =>
            //{
            string resource = "https://mfprod.operations.dynamics.com";
            try
            {
                LogInfo($"\r\n{Now}: {ServiceName} Service running.");

                // When the timer should have no due-time, then do the work once now.
                using PeriodicTimer timer = new(TimeSpan.FromMinutes(period));
                do
                {
                    int count = Interlocked.Increment(ref ExecutionCount);

                    string url = $"{resource}/data/{ServiceNameOrgnl}";

                    string msg = $"{Now}: {ServiceName} Service is working; Count: {count}";
                    LogInfo(msg);

                    var startTime = DateTimeOffset.Now;
                    msg = $"{Now}: Data migration started.";
                    LogInfo(msg);

                    int i = 0;
                    while (!IsEmpty(url))
                    {
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
        //, stoppingToken);
        //    return Task.CompletedTask;
        //}

        // Could also be a async method, that can be awaited in ExecuteAsync above
        protected async virtual Task<string> DoWork(string resource, string url)
        {
            string? result = Emp;
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
            using (var transaction = await cntxt.Database.BeginTransactionAsync())
            {
                //if (!await CheckTableExists(cntxt)) return;

                JObject obj = JObject.Parse(result);
                JArray Items = (JArray)obj["value"];

                long updtCnt = 0, addCnt = 0;
                int i = Items.Count;
                string currentNamespace = typeof(Program).Namespace;
                string tblName = config.Table;
                tblName = $"{currentNamespace}.{tblName}";
                Type typ = Type.GetType(tblName, throwOnError: false, ignoreCase: true);

                foreach (var itm in Items)
                {
                    string itmJsn;
                    AllProductsTestR existingEntity = null;
                    for (int cnt = 1; cnt <= 2; cnt++)
                    {
                        try
                        {
                            itmJsn = itm.ToJson();
                            //if (poco is null) continue;

                            //// Find existing entity in the database
                            //if (cntxt.AllProductsTestR.Count() > 0)
                            //    existingEntity = await cntxt.Set("AllProductsTestR").AsNoTracking().FirstOrDefaultAsync(e => e.ProductNumber == poco.ProductNumber);

                            //if (!cntxt.AllProductsTestR.Local.Any(e => e.ProductNumber == poco.ProductNumber))
                            //{
                            //    // Check if the entity exists in the database
                            //    if (existingEntity == null) // Add the new entity
                            //    {
                            //        cntxt.AllProductsTestR.Add(poco);
                            //        addCnt++;
                            //    }
                            //    else // Update the existing entity if modified
                            //    {
                            //        if (poco.ModifiedDateTime1 != null && !(existingEntity.ModifiedDateTime1 != null) && poco.ModifiedDateTime1 > existingEntity.ModifiedDateTime1)
                            //        {
                            //            cntxt.Entry(existingEntity).CurrentValues.SetValues(poco);
                            //            updtCnt++;
                            //        }
                            //    }
                            //}
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
        }

        private async Task<bool> CheckTableExists(ServiceDbContext cntxt)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    // Try to access the poco table
                    var testQuery = await cntxt.AllProductsTestR.FirstOrDefaultAsync();
                    break;
                }
                catch (Exception ex1)
                {
                    LogInfo($"{Now}: Error: {ex1?.Message} + \r\n {ex1.StackTrace}");
                    if (i < 2)
                    {
                        LogInfo($"{Now}: Applying migration...");
                        await ApplyMigration(cntxt);
                    }
                    else return false;
                    // If an exception occurs, the table doesn't exist, Apply migrations to create it

                }
            }
            return true;
        }

        private async Task ApplyMigration(ServiceDbContext cntxt)
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

        public Task StopAsync(CancellationToken cancellationToken)
        {
            cancellationTokenSource.Cancel();
            BackgroundThread.Join();
            logger.LogInformation("Background service is stopping.");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

    }
}
