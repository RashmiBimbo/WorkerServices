using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;

namespace SalesInvoiceService
{

    public class SalesInvoiceWorker : BackgroundService
    {
        private int _executionCount;
        private readonly ILogger<SalesInvoiceWorker> logger;
        private readonly SalesInvoiceContext cntxt;
        string msg, logFile;

        public SalesInvoiceWorker(ILogger<SalesInvoiceWorker> logger, SalesInvoiceContext cntxt)
        {
            this.logger = logger;
            this.cntxt = cntxt;
            logFile = AppDomain.CurrentDomain.BaseDirectory + "SalesOrderWorker_Log.txt";
            if (!File.Exists(logFile))
                File.Create(logFile);
        }

        private void LogInfo(string msg)
        {
            logger.LogInformation(msg);
            File.AppendAllText(logFile, "\r\n" + msg);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                logger.LogInformation("Timed Hosted Service running.");
                File.AppendAllText(logFile, "\r\n" + "Timed Hosted Service running.");

                // When the timer should have no due-time, then do the work once now.
                using PeriodicTimer timer = new(TimeSpan.FromMinutes(30));
                do
                {
                    string msg = $"Data migration started at: {DateTime.Now}";
                    File.AppendAllText(logFile, "\r\n" + msg);
                    logger.LogInformation(msg);

                    var startTime = DateTimeOffset.Now;

                    await DoWork();

                    var endTime = DateTimeOffset.Now;
                    var elapsedTime = endTime - startTime;

                    LogInfo($"Task execution time: {elapsedTime}"
                        + $"Data migration completed at : {DateTime.Now}"
                    + "\r\n**********************************************\r\n");
                }
                while (await timer.WaitForNextTickAsync(stoppingToken));
            }
            catch (Exception ex)
            {
                logger.LogInformation($"Error: {ex?.ToString()}");
                File.AppendAllText(logFile, "\r\n" + $"Error: {ex?.ToString()}");
                logger.LogInformation("Timed Hosted Service is stopping.");
                File.AppendAllText(logFile, "\r\n" + "Timed Hosted Service is stopping.");
            }
        }

        // Could also be a async method, that can be awaited in ExecuteAsync above
        private async Task DoWork()
        {
            int count = Interlocked.Increment(ref _executionCount);
            msg = $"Timed Hosted Service is working. Count: {count}, Time: {DateTime.Now}";
            logger.LogInformation(msg);
            File.AppendAllText(logFile, "\r\n" + msg);

            string result = string.Empty;

            string resource = "https://mfprod.operations.dynamics.com";
            DateTimeOffset now = DateTimeOffset.Now;
            string lstMnth = now.AddMonths(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
            string restUrl = $"data/SalesInvoiceHeadersV2?$filter=dataAreaId eq 'BBI' and InvoiceDate ge {lstMnth} and InvoiceDate le {now:yyyy-MM-ddTHH:mm:ssZ} &cross-company=true";
            for (int cnt = 1; cnt <= 2; cnt++)
            {
                result = await GetJson(resource, restUrl);
                if (!string.IsNullOrWhiteSpace(result))
                    break;
                else if (cnt < 2)
                {
                    logger.LogInformation("Getting JSON failed! Retrying...");
                    File.AppendAllText(logFile, "\r\n" + "Getting JSON failed! Retrying...");
                }
            }
            await JsonToDb(result);
        }

        private async Task JsonToDb(string result)
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine($"Error: The response JSON string is empty. Returning...");
                File.AppendAllText(logFile, "\r\n" + "Error: The response JSON string is empty. Returning...");
                return;
            }
            //List<CustInvoiceJourTestR> pocoList = [];
            try
            {
                JObject obj = JObject.Parse(result);
                var Items = obj["value"];
                long updtCnt = 0, addCnt = 0;
                int i = 0;
                foreach (var itm in Items)
                {
                    //if (i > 5) break;
                    string itmJsn;
                    for (int cnt = 1; cnt <= 2; cnt++)
                    {
                        try
                        {
                            itmJsn = Serialize.ToJson(itm);
                            CustInvoiceJourTestR poco = JsonConvert.DeserializeObject<CustInvoiceJourTestR>(itmJsn);
                            CustInvoiceJourTestR? existingEntity = cntxt.Set<CustInvoiceJourTestR>().Find(poco?.Etag);
                            CustInvoiceJourTestR? rcrd = await cntxt.CustInvoiceJourTestR.FirstOrDefaultAsync(e => e.Etag == poco.Etag);
                            if (rcrd is not null) rcrd.ModifiedDateTime1 = DateTime.Now;
                            if (rcrd == null && existingEntity == null) // Add the new entity                                
                            {
                                cntxt.Set<CustInvoiceJourTestR>().Add(poco);
                                addCnt++;
                            }
                            else
                            //if (rcrd?.ModifiedDateTime1 != existingEntity?.ModifiedDateTime1) // Update the existing entity if modified 
                            if (rcrd != null && existingEntity != null && rcrd.ModifiedDateTime1 != existingEntity.ModifiedDateTime1) // Update the existing entity if modified 
                            {
                                cntxt.Entry(rcrd).CurrentValues.SetValues(existingEntity);
                                updtCnt++;
                            }
                            //pocoList.Add(poco);
                            break;
                        }
                        catch (Exception ex)
                        {
                            logger.LogInformation($"Error: {ex?.ToString()}");
                            File.AppendAllText(logFile, "\r\n" + $"Error: {ex?.ToString()}");
                            if (cnt < 2)
                            {
                                logger.LogInformation("Saving entity failed. Retrying...");
                                File.AppendAllText(logFile, "\r\n" + "Saving entity failed. Retrying...");
                            }
                        }
                    }
                    i++;
                }
                try
                {
                    // Try to access the poco table
                    var testQuery = await cntxt.CustInvoiceJourTestR.FirstOrDefaultAsync();
                }
                catch (Exception)
                {
                    // If an exception occurs, the table doesn't exist, Apply migrations to create it
                    try
                    {
                        await cntxt.Database.MigrateAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex?.ToString()}");
                        File.AppendAllText(logFile, "\r\n" + $"Error: {ex?.ToString()}");
                        return;
                    }
                }
                for (int cnt = 1; cnt <= 2; cnt++)
                {
                    try
                    {
                        await cntxt.SaveChangesAsync();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex?.ToString()}");
                        File.AppendAllText(logFile, "\r\n" + $"Error: {ex?.ToString()}");
                        if (cnt < 2)
                        {
                            string msg = "Saving chnages failed! Retrying...";
                            logger.LogInformation(msg);
                            File.AppendAllText(logFile, "\r\n" + msg);
                        }
                        return;
                    }
                }
                msg = "Success: Saved data successfully.\r\n" +
                    $"Total no. of records updated: {updtCnt}\r\n" +
                    $"Total no. of records added: {addCnt}\r\n";
                Console.WriteLine(msg);
                File.AppendAllText(logFile, "\r\n" + msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex?.ToString()}");
                File.AppendAllText(logFile, "\r\n" + $"Error: {ex?.ToString()}");
            }
        }

        private async Task<CustInvoiceJourTestR> CreatePoco(dynamic itm, Uri odataContext)
        {
            CustInvoiceJourTestR CustInvoicePoco = new();
            try
            {
                CustInvoicePoco.Etag = itm["@odata.etag"]?.Value;
                CustInvoicePoco.ParentReference = itm["ParentReference"]?.Value;
                CustInvoicePoco.dataAreaId = itm["DataAreaId"]?.Value;
                CustInvoicePoco.InvoiceDate = TryCastDTO(itm["InvoiceDate"]?.Value);
                CustInvoicePoco.InvoiceNumber = itm["InvoiceNumber"]?.Value;
                CustInvoicePoco.LedgerVoucher = itm["LedgerVoucher"]?.Value;
                CustInvoicePoco.ContactPersonId = itm["ContactPersonId"]?.Value;
                CustInvoicePoco.CurrencyCode = itm["CurrencyCode"]?.Value;
                CustInvoicePoco.CustomersOrderReference = itm["CustomersOrderReference"]?.Value;
                CustInvoicePoco.DeliveryAddressName = itm["DeliveryAddressName"]?.Value;
                CustInvoicePoco.DeliveryModeCode = TryCastLong(itm["DeliveryModeCode"]?.Value);
                CustInvoicePoco.DeliveryName = itm["DeliveryName"]?.Value;
                CustInvoicePoco.DeliveryTermsCode = itm["DeliveryTermsCode"]?.Value;
                CustInvoicePoco.DemandDateJour = TryCastDTO(itm["DemandDateJour"]?.Value);
                CustInvoicePoco.DriverCode = itm["DriverCode"]?.Value;
                CustInvoicePoco.DriverName = itm["DriverName"]?.Value;
                CustInvoicePoco.InvoiceAddressCity = itm["InvoiceAddressCity"]?.Value;
                CustInvoicePoco.InvoiceAddressCountryRegionId = itm["InvoiceAddressCountryRegionId"]?.Value;
                CustInvoicePoco.InvoiceAddressCountryRegionISOCode = itm["InvoiceAddressCountryRegionISOCode"]?.Value;
                CustInvoicePoco.InvoiceAddressState = itm["InvoiceAddressState"]?.Value;
                CustInvoicePoco.InvoiceAddressStreet = itm["InvoiceAddressStreet"]?.Value;
                CustInvoicePoco.InvoiceAddressStreetNumber = itm["InvoiceAddressStreetNumber"]?.Value;
                CustInvoicePoco.InvoiceAddressZipCode = itm["InvoiceAddressZipCode"]?.Value;
                CustInvoicePoco.InvoiceCustomerAccountNumber = itm["InvoiceCustomerAccountNumber"]?.Value;
                CustInvoicePoco.InvoiceHeaderTaxAmount = TryCastDbl(itm["InvoiceHeaderTaxAmount"]?.Value);
                CustInvoicePoco.InvoiceId_CT = itm["InvoiceId_CT"]?.Value;
                CustInvoicePoco.IRNNumber = itm["IRNNumber"]?.Value;
                CustInvoicePoco.IsProcessed = itm["IsProcessed"]?.Value;
                CustInvoicePoco.IsProcess_CT = itm["IsProcess_CT"]?.Value;
                CustInvoicePoco.IsReturn = itm["IsReturn"]?.Value;
                CustInvoicePoco.IsSample = itm["IsSample"]?.Value;
                CustInvoicePoco.LoaderCode = itm["LoaderCode"]?.Value;
                CustInvoicePoco.LoaderName = itm["LoaderName"]?.Value;
                CustInvoicePoco.OrderAccount = itm["OrderAccount"]?.Value;
                CustInvoicePoco.PackerCode = itm["PackerCode"]?.Value;
                CustInvoicePoco.PackerName = itm["PackerName"]?.Value;
                CustInvoicePoco.PaymentTermsName = itm["PaymentTermsName"]?.Value;
                CustInvoicePoco.PORefID = itm["PORefID"]?.Value;
                CustInvoicePoco.RecId1 = itm["RecId1"]?.Value;
                CustInvoicePoco.SalesId = itm["SalesId"]?.Value;
                CustInvoicePoco.SalesId_CT = itm["SalesId_CT"]?.Value;
                CustInvoicePoco.SalesOrderNumber = itm["SalesOrderNumber"]?.Value;
                CustInvoicePoco.SalesOrderOriginCode = itm["SalesOrderOriginCode"]?.Value;
                CustInvoicePoco.SalesOrderResponsiblePersonnelNumber = itm["SalesOrderResponsiblePersonnelNumber"]?.Value;
                CustInvoicePoco.SalesStatus = itm["SalesStatus"]?.Value;
                CustInvoicePoco.SalesType = itm["SalesType"]?.Value;
                CustInvoicePoco.TotalChargeAmount = TryCastDbl(itm["TotalChargeAmount"]?.Value);
                CustInvoicePoco.TotalDiscountAmount = itm["TotalDiscountAmount"]?.Value;
                CustInvoicePoco.TotalDiscountCustomerGroupCode = TryCastDbl(itm["TotalDiscountCustomerGroupCode"]?.Value);
                CustInvoicePoco.TotalInvoiceAmount = TryCastDbl(itm["TotalInvoiceAmount"]?.Value);
                CustInvoicePoco.TotalTaxAmount = TryCastDbl(itm["TotalTaxAmount"]?.Value);
                CustInvoicePoco.VehicleCode = itm["VehicleCode"]?.Value;
                CustInvoicePoco.VehicleTag = itm["VehicleTag"]?.Value;
                CustInvoicePoco.ModifiedDateTime1 = TryCastDTO(itm["ModifiedDateTime1"]?.Value);
                CustInvoicePoco.ReturnReasonCodeId = itm["ReturnReasonCodeId"]?.Value;
                CustInvoicePoco.RouteCode = itm["RouteCode"]?.Value;
                CustInvoicePoco.SalespersonCode = itm["SalespersonCode"]?.Value;
                CustInvoicePoco.SupervisorCode = itm["SupervisorCode"]?.Value;
                CustInvoicePoco.SupervisorCodeBak = itm["SupervisorCodeBak"]?.Value;
                CustInvoicePoco.AmountMST = TryCastDbl(itm["AmountMST"]?.Value);
                CustInvoicePoco.OrderId = itm["OrderId"]?.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex?.ToString()}");
            }
            return CustInvoicePoco;
        }
    }
}
