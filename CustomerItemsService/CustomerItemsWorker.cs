using Newtonsoft.Json.Linq;
using static System.DateTime;

namespace CustomerItemsService
{
    public class CustomerItemsWorker : BackgroundService
    {
        private int _executionCount;
        private CustomerItemsContext cntxt;
        string msg, logFile;
        double period = 30;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<CustomerItemsWorker> logger;
        private CustomerItemsBase Poco;

        public CustomerItemsWorker(IServiceScopeFactory serviceScopeFactory, ILogger<CustomerItemsWorker> logger)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
            //Poco = cust;
            logFile = AppDomain.CurrentDomain.BaseDirectory + "CustomerItemsService_Log.txt";
            try
            {
                if (!File.Exists(logFile)) File.Create(logFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Now}: {ex?.Message} \r\n {ex?.StackTrace}");
            }
        }

        private void LogInfo(string msg)
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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string resource = "https://mfprod.operations.dynamics.com";
            DateTimeOffset now = DateTimeOffset.Now;
            string lstMnth = now.AddMonths(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
            try
            {
                LogInfo($"\r\n{Now}: Customer Items ServiceDetail running.");

                // When the timer should have no due-time, then do the work once now.
                using PeriodicTimer timer = new(TimeSpan.FromMinutes(period));
                do
                {
                    int count = Interlocked.Increment(ref _executionCount);

                    string url = $"{resource}/data/CustomerItems";

                    string msg = $"{Now}: Customer Items ServiceDetail is working; Count: {count}";
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

                    LogInfo($"\r\n{Now}: Data migration completed.\r\n"
                          + $"{Now}: No. of times api executed : {i}\r\n"
                          + $"{Now}: Task execution time: {elapsedTime}\r\n"
                          + $"{Now}: Next iteration will start after {period} minutes at {DateTimeOffset.Now.AddMinutes(period)}\r\n"
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
                LogInfo($"{Now}: Customer Items ServiceDetail stopped.");
            }
        }

        // Could also be a async method, that can be awaited in ExecuteAsync above
        private async Task<string> DoWork(string resource, string url)
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

        private async Task JsonToDb(string result)
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
                cntxt = scope.ServiceProvider.GetRequiredService<CustomerItemsContext>();

                //if (!await CheckTableExists(cntxt)) return;

                JObject obj = JObject.Parse(result);
                JArray Items = (JArray)obj["value"];

                long updtCnt = 0, addCnt = 0;
                int i = Items.Count;

                var strategy = cntxt.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = await cntxt.Database.BeginTransactionAsync())
                    {
                        foreach (var itm in Items)
                        {
                            string itmJsn;
                            CustomerItemsTestR existingEntity = null;
                            for (int cnt = 1; cnt <= 2; cnt++)
                            {
                                try
                                {
                                    itmJsn = Serialize.ToJson(itm);
                                    CustomerItemsTestR poco = JsonConvert.DeserializeObject<CustomerItemsTestR>(itmJsn);
                                    if (poco is null) continue;

                                    // Find existing entity in the database

                                    if (cntxt.CustomerItemsTestR.Any())
                                        existingEntity = await cntxt.CustomerItemsTestR.AsNoTracking().FirstOrDefaultAsync();

                                    //e => (e.CustVendRelation == poco.CustVendRelation) && (e.DataAreaId == poco.DataAreaId) && (e.FromDate == poco.FromDate) && (e.ItemId == poco.ItemId) && (e.ToDate == poco.ToDate)
                                    if (!cntxt.CustomerItemsTestR.Local.Any(e => (e.CustVendRelation == poco.CustVendRelation) && (e.DataAreaId == poco.DataAreaId) && (e.FromDate == poco.FromDate) && (e.ItemId == poco.ItemId) && (e.ToDate == poco.ToDate)))
                                    {
                                        // Check if the entity exists in the database
                                        if (existingEntity == null) // Add the new entity
                                        {
                                            cntxt.CustomerItemsTestR.Add(poco);
                                            addCnt++;
                                        }
                                        else // Update the existing entity if modified
                                        {
                                            if ((poco.ModifiedDateTime1 != null) && !(existingEntity.ModifiedDateTime1 != null) && (poco.ModifiedDateTime1 > existingEntity.ModifiedDateTime1))
                                            {
                                                cntxt.Entry(existingEntity).CurrentValues.SetValues(poco);
                                                updtCnt++;
                                            }
                                        }
                                    }
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    string inrExMsg = ex.InnerException is null ? string.Empty : $"{ex.InnerException.Message} + \r\n";
                                    LogInfo($"{Now}: Error: {ex?.Message} + \r\n + {inrExMsg} + {ex?.StackTrace}");
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
                            }
                        }
                        msg = $"\r\n{Now}: Success: Saved data successfully.\r\n" +
                              $"{Now}: Total no. of records tracked:{i}\r\n" +
                              $"{Now}: Total no. of records added: {addCnt}\r\n" +
                              $"{Now}: Total no. of records updated: {updtCnt}\r\n";

                        LogInfo(msg);
                    }
                });
            }
            catch (Exception ex)
            {
                LogInfo($"{Now} : Error: {ex?.Message} + \r\n {ex?.StackTrace}");
            }
        }
        private async Task<bool> CheckTableExists(CustomerItemsContext cntxt)
        {
            for (int i = 0; i < 3; i++)
            {

                try
                {
                    // Try to access the poco table
                    var testQuery = await cntxt.CustomerItemsTestR.FirstOrDefaultAsync();
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

        private async Task ApplyMigration(CustomerItemsContext cntxt)
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

    }
}