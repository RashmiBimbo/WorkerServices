using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using static System.DateTime;

namespace SalesOrderWorker;

public class SalesOrderWorker : BackgroundService
{
    private int _executionCount;
    private readonly ILogger<SalesOrderWorker> logger;
    private readonly SalesOrderContext cntxt;
    string msg, logFile;

    public SalesOrderWorker(ILogger<SalesOrderWorker> logger, SalesOrderContext cntxt)
    {
        logFile = AppDomain.CurrentDomain.BaseDirectory + "SalesOrderWorker_Log.txt";
        if (!File.Exists(logFile))
            File.Create(logFile);
        this.logger = logger;
        this.cntxt = cntxt;
    }

    private static DateTimeOffset? TryCastDTO(dynamic itm)
    {
        try
        {
            string itmString = itm?.ToString(); // Convert itm to string
            return DateTimeOffset.TryParse(itmString, out DateTimeOffset dto) ? dto : null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex?.ToString()}");
            return null;
        }
    }

    private void LogInfo(string msg)
    {
        logger.LogInformation(msg);
        File.AppendAllText(logFile, "\r\n" + msg);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        LogInfo($"Timed Hosted Service started running at {DateTime.Now}.");

        // When the timer should have no due-time, then do the work once now.

        using PeriodicTimer timer = new(TimeSpan.FromSeconds(5));

        try
        {
            do
            {
                string msg = $"Data migration started at: {DateTime.Now}";
                File.AppendAllText(logFile, "\r\n" + msg);
                logger.LogInformation(msg);

                var startTime = DateTimeOffset.Now;

                await DoWork();

                var endTime = DateTimeOffset.Now;
                var elapsedTime = endTime - startTime;
                LogInfo($"Task execution time: {elapsedTime}");
            }
            while (await timer.WaitForNextTickAsync(stoppingToken));
        }
        catch (Exception ex)
        {
            LogInfo($"Error: {ex?.ToString()}");
            LogInfo($"Timed Hosted Service is stopping at {DateTime.Now}.");
        }
    }

    // Could also be a async method, that can be awaited in ExecuteAsync above
    private async Task DoWork()
    {
        int count = Interlocked.Increment(ref _executionCount);
        LogInfo($"Timed Hosted Service is working. Count: {count}, Time: {DateTime.Now}");

        string resource = "https://modernuat.sandbox.operations.dynamics.com";
        string source = "SalesOrderHeadersV2";
        string restUrl = $"{resource}/data/{source}";
        string result = Emp;
        for (int cnt = 1; cnt <= 2; cnt++)
        {
            result = await Common.GetJson(resource, restUrl);
            if (!IsEmpty(result))
                break;
            else if (cnt < 2)
            {
                LogInfo("Getting JSON failed! Retrying...");
            }
            await JsonToDb(result);
        }
    }

    private static async Task<string?> GetJson()
    {
        string? result = null;
        string clientId = "f59652f6-fd73-411b-ba47-5002f217eff9";
        string clientSecret = "R1Z8Q~-nETEjRazu1X4qxi6C1~PTJsCkz-y~ccid";
        string tenantId = "cc53a9a2-48fc-49e7-8f12-ef5a565cbcbe";
        string authority = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
        string resource = "https://modernuat.sandbox.operations.dynamics.com";

        string source = "SalesOrderHeadersV2";
        string url = $"{resource}/data/{source}";

        using var client = new HttpClient();
        var content = new FormUrlEncodedContent(
        [
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("resource", resource)
        ]);

        try
        {
            var tokenResponse = await client.PostAsync(authority, content);
            tokenResponse.EnsureSuccessStatusCode();

            var tokenJson = await tokenResponse.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(tokenJson);

            if (token != null && !string.IsNullOrEmpty(token.AccessToken))
            {
                string apiUrl = url;
                using HttpClient httpClient = new();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                httpClient.Timeout = TimeSpan.FromMinutes(5.0);

                var response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex?.ToString()}");
            return null;
        }
    }

    private async Task JsonToDb(string result)
    {
        if (IsEmpty(result))
        {
            LogInfo($"Error: The response JSON string is empty");
            return;
        }
        //List<SalesOrderTestPoco> pocoList = [];
        try
        {
            JObject obj = JObject.Parse(result);
            var Items = obj["value"];
            long updtCnt = 0, addCnt = 0;

            foreach (var itm in Items)
            {
                string itmJsn;
                for (int cnt = 1; cnt <= 2; cnt++)
                {
                    try
                    {
                        itmJsn = Serialize.ToJson(itm);
                        SalesOrderTestPoco poco = JsonConvert.DeserializeObject<SalesOrderTestPoco>(itmJsn);
                        SalesOrderTestPoco? existingEntity = cntxt.Set<SalesOrderTestPoco>().Find(poco.OdataEtag);
                        SalesOrderTestPoco? rcrd = await cntxt.SalesOrderTestPoco.FirstOrDefaultAsync(e => e.OdataEtag == poco.OdataEtag);

                        if (existingEntity != null)
                        // Update the existing entity
                        {
                            cntxt.Entry(rcrd).CurrentValues.SetValues(existingEntity);
                            updtCnt++;
                        }
                        else
                        // Add the new entity
                        {
                            cntxt.Set<SalesOrderTestPoco>().Add(poco);
                            addCnt++;
                        }
                        //pocoList.Add(poco);
                        break;
                    }
                    catch (Exception ex)
                    {
                        LogInfo($"Error: {ex?.ToString()}");
                    }
                }
            }
            try
            {
                // Try to access the poco table
                var testQuery = await cntxt.SalesOrderTestPoco.FirstOrDefaultAsync();
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
                    LogInfo($"Error: {ex?.ToString()}");
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
                    LogInfo($"Error: {ex?.ToString()}");
                    return;
                }
            }
            LogInfo("Success: Data migarted successfully.");
        }
        catch (Exception ex)
        {
            LogInfo($"Error: {ex?.ToString()}");
        }
    }
    //private async Task JsonToDb(string result)
    //{
    //    if (string.IsNullOrWhiteSpace(result))
    //    {
    //        return;
    //    }
    //    try
    //    {
    //        JObject obj = JObject.Parse(result);
    //        var Items = obj["value"];
    //        List<SalesOrderTestPoco> pocoList = [];

    //        foreach (var itm in Items)
    //        {
    //            SalesOrderTestPoco poco = await CreatePoco(itm, (Uri)((JProperty)obj.First).Value);
    //            cntxt.Attach(poco);
    //            cntxt.Entry(poco).State = EntityState.Modified;
    //            pocoList.Add(poco);
    //        }
    //        try
    //        {
    //            // Try to access the SalesOrderTestPoco table
    //            var testQuery = await cntxt.SalesOrderTestPoco.FirstOrDefaultAsync();
    //        }
    //        catch (Exception)
    //        {
    //            // If an exception occurs, the table doesn't exist
    //            // Apply migrations to create it
    //            try
    //            {
    //                await cntxt.Database.MigrateAsync();
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine($"Error: {ex?.ToString()}");
    //                return;
    //            }
    //        }
    //        await cntxt.AddRangeAsync(pocoList);

    //        // await cntxt.AddRangeAsync(entities);
    //        await cntxt.SaveChangesAsync();
    //        Console.WriteLine("Success: Saved data successfully.");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error: {ex?.ToString()}");
    //    }
    //}

    private async Task<SalesOrderTestPoco> CreatePoco(dynamic itm, Uri odataContext)
    {
        SalesOrderTestPoco JsonPoco = null;
        try
        {
            JsonPoco = new();
            //JsonPoco.OdataContext = odataContext;
            JsonPoco.DataAreaId = itm["dataAreaId"]?.ToString();
            JsonPoco.SalesOrderNumber = itm["SalesOrderNumber"]?.ToString();
            JsonPoco.CustomerRequisitionNumber = itm["CustomerRequisitionNumber"]?.ToString();
            JsonPoco.SalesOrderProcessingStatus = itm["SalesOrderProcessingStatus"]?.ToString();
            //SalesOrderTestPoco.OrderTotalAmount = ToInt64(itm["OrderTotalAmount"]?.ToString());

            long.TryParse(itm["DeliveryAddressZipCode"]?.ToString(), out long ota);
            JsonPoco.OrderTotalAmount = ota;
            JsonPoco.IntrastatPortId = itm["IntrastatPortId"]?.ToString();
            JsonPoco.ContactPersonId = itm["ContactPersonId"]?.ToString();
            JsonPoco.CustomersOrderReference = itm["CustomersOrderReference"]?.ToString();
            JsonPoco.SkipCreateAutoCharges = itm["SkipCreateAutoCharges"]?.ToString();
            //SalesOrderTestPoco.TotalDiscountPercentage = ToInt64(itm["TotalDiscountPercentage"]?.ToString());

            long.TryParse(itm["DeliveryAddressZipCode"]?.ToString(), out ota);
            JsonPoco.OrderTotalAmount = ota;

            JsonPoco.CustomerPaymentFineCode = itm["CustomerPaymentFineCode"]?.ToString();
            JsonPoco.IsSalesProcessingStopped = itm["IsSalesProcessingStopped"]?.ToString();
            JsonPoco.InventoryReservationMethod = itm["InventoryReservationMethod"]?.ToString();
            JsonPoco.IntrastatTransportModeCode = itm["IntrastatTransportModeCode"]?.ToString();
            JsonPoco.InvoiceCustomerAccountNumber = itm["InvoiceCustomerAccountNumber"]?.ToString();
            JsonPoco.URL = itm["URL"]?.ToString();
            JsonPoco.InvoiceAddressCity = itm["InvoiceAddressCity"]?.ToString();
            JsonPoco.BankSpecificSymbol = itm["BankSpecificSymbol"]?.ToString();
            JsonPoco.BaseDocumentNumber = itm["BaseDocumentNumber"]?.ToString();
            JsonPoco.IsFinalUser = itm["IsFinalUser"]?.ToString();
            JsonPoco.CFPSCode = itm["CFPSCode"]?.ToString();
            JsonPoco.InvoiceAddressStreet = itm["InvoiceAddressStreet"]?.ToString();
            JsonPoco.InvoiceAddressCountyId = itm["InvoiceAddressCountyId"]?.ToString();
            JsonPoco.DeliveryAddressCountryRegionId = itm["DeliveryAddressCountryRegionId"]?.ToString();
            JsonPoco.IsServiceDeliveryAddressBased = itm["IsServiceDeliveryAddressBased"]?.ToString();
            JsonPoco.InvoiceAddressDistrictName = itm["InvoiceAddressDistrictName"]?.ToString();
            JsonPoco.InvoiceAddressTimeZone = TryCastDTO(itm["InvoiceAddressTimeZone"].Value);
            JsonPoco.FiscalOperationPresenceType = itm["FiscalOperationPresenceType"]?.ToString();
            JsonPoco.MultilineDiscountCustomerGroupCode = itm["MultilineDiscountCustomerGroupCode"]?.ToString();
            JsonPoco.IsOwnEntryCertificateIssued = itm["IsOwnEntryCertificateIssued"]?.ToString();
            JsonPoco.DeliveryAddressCountyId = itm["DeliveryAddressCountyId"]?.ToString();
            JsonPoco.DefaultShippingWarehouseId = itm["DefaultShippingWarehouseId"]?.ToString();
            JsonPoco.DeliveryAddressLocationId = itm["DeliveryAddressLocationId"]?.ToString();
            JsonPoco.CustomerPaymentMethodName = itm["CustomerPaymentMethodName"]?.ToString();
            JsonPoco.SalesUnitId = itm["SalesUnitId"]?.ToString();
            JsonPoco.DefaultLedgerDimensionDisplayValue = itm["DefaultLedgerDimensionDisplayValue"]?.ToString();
            JsonPoco.DeliveryAddressCountryRegionISOCode = itm["DeliveryAddressCountryRegionISOCode"]?.ToString();
            JsonPoco.AreTotalsCalculated = itm["AreTotalsCalculated"]?.ToString();
            JsonPoco.TaxExemptNumber = itm["TaxExemptNumber"]?.ToString();
            JsonPoco.DeliveryAddressDescription = itm["DeliveryAddressDescription"]?.ToString();

            //SalesOrderTestPoco.DeliveryAddressLongitude = ToInt64(itm["DeliveryAddressLongitude"]?.ToString());
            long.TryParse(itm["DeliveryAddressLongitude"]?.ToString(), out ota);
            JsonPoco.DeliveryAddressLongitude = ota;

            JsonPoco.DefaultShippingSiteId = itm["DefaultShippingSiteId"]?.ToString();
            JsonPoco.CashDiscountCode = itm["CashDiscountCode"]?.ToString();
            JsonPoco.DeliveryReasonCode = itm["DeliveryReasonCode"]?.ToString();
            JsonPoco.TotalDiscountCustomerGroupCode = itm["TotalDiscountCustomerGroupCode"]?.ToString();
            JsonPoco.CampaignId = itm["CampaignId"]?.ToString();

            //SalesOrderTestPoco.OrderTotalDiscountAmount = ToInt64(itm["OrderTotalDiscountAmount"]?.ToString());
            long.TryParse(itm["OrderTotalDiscountAmount"]?.ToString(), out ota);
            JsonPoco.OrderTotalDiscountAmount = ota;

            JsonPoco.PaymentTermsName = itm["PaymentTermsName"]?.ToString();
            JsonPoco.ShippingCarrierServiceGroupId = itm["ShippingCarrierServiceGroupId"]?.ToString();
            JsonPoco.CIPEcode = itm["CIPEcode"]?.ToString();
            JsonPoco.RequestedReceiptDate = TryCastDTO(itm["RequestedReceiptDate"].Value);
            JsonPoco.ConfirmedReceiptDate = TryCastDTO(itm["ConfirmedReceiptDate"].Value);
            JsonPoco.BaseDocumentDate = TryCastDTO(itm["BaseDocumentDate"].Value);
            JsonPoco.EInvoiceDimensionAccountCode = itm["EInvoiceDimensionAccountCode"]?.ToString();
            JsonPoco.OrderingCustomerAccountNumber = itm["OrderingCustomerAccountNumber"]?.ToString();

            //SalesOrderTestPoco.OrderTotalChargesAmount = ToInt64(itm["OrderTotalChargesAmount"]?.ToString());
            long.TryParse(itm["OrderTotalChargesAmount"]?.ToString(), out ota);
            JsonPoco.OrderTotalChargesAmount = ota;

            JsonPoco.SalesRebateCustomerGroupId = itm["SalesRebateCustomerGroupId"]?.ToString();
            JsonPoco.TransportationBrokerId = itm["TransportationBrokerId"]?.ToString();
            JsonPoco.DirectDebitMandateId = itm["DirectDebitMandateId"]?.ToString();
            JsonPoco.CreditNoteReasonCode = itm["CreditNoteReasonCode"]?.ToString();
            JsonPoco.IntrastatStatisticsProcedureCode = itm["IntrastatStatisticsProcedureCode"]?.ToString();
            JsonPoco.TMACustomerGroupId = itm["TMACustomerGroupId"]?.ToString();
            JsonPoco.ArePricesIncludingSalesTax = itm["ArePricesIncludingSalesTax"]?.ToString();
            JsonPoco.IsExportSale = itm["IsExportSale"]?.ToString();
            JsonPoco.InvoicePaymentAttachmentType = itm["InvoicePaymentAttachmentType"]?.ToString();

            //SalesOrderTestPoco.ReportingCurrencyFixedExchangeRate = ToInt64(itm["ReportingCurrencyFixedExchangeRate"]?.ToString());
            long.TryParse(itm["ReportingCurrencyFixedExchangeRate"]?.ToString(), out ota);
            JsonPoco.ReportingCurrencyFixedExchangeRate = ota;

            JsonPoco.IsDeliveryAddressPrivate = itm["IsDeliveryAddressPrivate"]?.ToString();
            JsonPoco.DeliveryAddressCity = itm["DeliveryAddressCity"]?.ToString();
            JsonPoco.DeliveryAddressStreet = itm["DeliveryAddressStreet"]?.ToString();
            JsonPoco.NumberSequenceGroupId = itm["NumberSequenceGroupId"]?.ToString();

            //SalesOrderTestPoco.OrderTotalTaxAmount = ToInt64(itm["OrderTotalTaxAmount"]?.ToString());
            long.TryParse(itm["OrderTotalTaxAmount"]?.ToString(), out ota);
            JsonPoco.OrderTotalTaxAmount = ota;

            JsonPoco.DeliveryTermsCode = itm["DeliveryTermsCode"]?.ToString();
            JsonPoco.ChargeCustomerGroupId = itm["ChargeCustomerGroupId"]?.ToString();
            JsonPoco.WillAutomaticInventoryReservationConsiderBatchAttributes = itm["Will.AutomaticInventoryReservationConsiderBatchAttributes"]?.ToString();
            JsonPoco.SalesTaxGroupCode = itm["SalesTaxGroupCode"]?.ToString();
            JsonPoco.IsInvoiceAddressPrivate = itm["IsInvoiceAddressPrivate"]?.ToString();
            JsonPoco.ThirdPartySalesDigitalPlatformCNPJ = itm["ThirdPartySalesDigitalPlatformCNPJ"]?.ToString();

            //SalesOrderTestPoco.OrderHeaderTaxAmount = ToInt64(itm["OrderHeaderTaxAmount"]?.ToString());
            long.TryParse(itm["OrderHeaderTaxAmount"]?.ToString(), out ota);
            JsonPoco.OrderHeaderTaxAmount = ota;

            JsonPoco.FiscalDocumentOperationTypeId = itm["FiscalDocumentOperationTypeId"]?.ToString();
            JsonPoco.OrderCreationDateTime = TryCastDTO(itm["OrderCreationDateTime"].Value);
            JsonPoco.SalesOrderOriginCode = itm["SalesOrderOriginCode"]?.ToString();
            JsonPoco.ServiceFiscalInformationCode = itm["ServiceFiscalInformationCode"]?.ToString();
            JsonPoco.DeliveryAddressStateId = itm["DeliveryAddressStateId"]?.ToString();
            JsonPoco.FulfillmentPolicyName = itm["FulfillmentPolicyName"]?.ToString();
            JsonPoco.CommissionSalesRepresentativeGroupId = itm["CommissionSalesRepresentativeGroupId"]?.ToString();
            JsonPoco.CustomerPostingProfileId = itm["CustomerPostingProfileId"]?.ToString();
            JsonPoco.CustomerTransactionSettlementType = itm["CustomerTransactionSettlementType"]?.ToString();
            JsonPoco.BaseDocumentItemNumber = itm["BaseDocumentItemNumber"]?.ToString();
            JsonPoco.TransportationDocumentLineId = (Guid)itm["TransportationDocumentLineId"];
            JsonPoco.DeliveryAddressStreetInKana = itm["DeliveryAddressStreetInKana"]?.ToString();
            JsonPoco.CustomerPaymentFinancialInterestCode = itm["CustomerPaymentFinancialInterestCode"]?.ToString();
            JsonPoco.PaymentScheduleName = itm["PaymentScheduleName"]?.ToString();
            JsonPoco.InvoiceAddressStreetNumber = itm["InvoiceAddressStreetNumber"]?.ToString();
            JsonPoco.SalesOrderStatus = itm["SalesOrderStatus"]?.ToString();
            JsonPoco.PaymentTermsBaseDate = TryCastDTO(itm["PaymentTermsBaseDate"].Value);
            JsonPoco.ShippingCarrierId = itm["ShippingCarrierId"]?.ToString();
            JsonPoco.InvoiceAddressPostBox = itm["InvoiceAddressPostBox"]?.ToString();
            JsonPoco.ConfirmedShippingDate = TryCastDTO(itm["ConfirmedShippingDate"].Value);
            JsonPoco.TenderCode = itm["TenderCode"]?.ToString();
            JsonPoco.DeliveryAddressDunsNumber = itm["DeliveryAddressDunsNumber"]?.ToString();
            JsonPoco.IsEntryCertificateRequired = itm["IsEntryCertificateRequired"]?.ToString();
            JsonPoco.ThirdPartySalesDigitalPlatform = itm["ThirdPartySalesDigitalPlatform"]?.ToString();
            JsonPoco.DeliveryAddressDistrictName = itm["DeliveryAddressDistrictName"]?.ToString();
            JsonPoco.SalesOrderPromisingMethod = itm["SalesOrderPromisingMethod"]?.ToString();

            //SalesOrderTestPoco.DeliveryModeCode = ToInt64(itm["DeliveryModeCode"]?.ToString());
            long.TryParse(itm["DeliveryModeCode"]?.ToString(), out ota);
            JsonPoco.DeliveryModeCode = ota;

            //SalesOrderTestPoco.BaseDocumentLineNumber = ToInt64(itm["BaseDocumentLineNumber"]?.ToString());
            long.TryParse(itm["BaseDocumentLineNumber"]?.ToString(), out ota);
            JsonPoco.BaseDocumentLineNumber = ota;

            JsonPoco.TransportationModeId = itm["TransportationModeId"]?.ToString();
            JsonPoco.SalesOrderName = itm["SalesOrderName"]?.ToString();
            JsonPoco.DeliveryAddressStreetNumber = itm["DeliveryAddressStreetNumber"]?.ToString();

            //SalesOrderTestPoco.InvoiceAddressLongitude = ToInt64(itm["InvoiceAddressLongitude"]?.ToString());
            long.TryParse(itm["InvoiceAddressLongitude"]?.ToString(), out ota);
            JsonPoco.InvoiceAddressLongitude = ota;

            //SalesOrderTestPoco.InvoiceAddressLatitude = ToInt64(itm["InvoiceAddressLatitude"]?.ToString());
            long.TryParse(itm["InvoiceAddressLatitude"]?.ToString(), out ota);
            JsonPoco.InvoiceAddressLatitude = ota;
            JsonPoco.BaseDocumentType = itm["BaseDocumentType"]?.ToString();
            JsonPoco.SalesOrderPoolId = itm["SalesOrderPoolId"]?.ToString();
            JsonPoco.FormattedInvoiceAddress = itm["FormattedInvoiceAddress"]?.ToString();
            JsonPoco.CustomerPaymentMethodSpecificationName = itm["CustomerPaymentMethodSpecificationName"]?.ToString();
            JsonPoco.CurrencyCode = itm["CurrencyCode"]?.ToString();
            JsonPoco.FormattedDelveryAddress = itm["FormattedDelveryAddress"]?.ToString();
            JsonPoco.BankConstantSymbol = itm["BankConstantSymbol"]?.ToString();
            JsonPoco.PriceCustomerGroupCode = itm["PriceCustomerGroupCode"]?.ToString();
            JsonPoco.DeliveryAddressTimeZone = TryCastDTO(itm["DeliveryAddressTimeZone"]);
            JsonPoco.FullRunCTPStatus = itm["FullRunCTPStatus"]?.ToString();
            JsonPoco.Email = itm["Email"]?.ToString();
            JsonPoco.InvoiceAddressCityInKana = itm["InvoiceAddressCityInKana"]?.ToString();
            JsonPoco.InvoiceAddressCountryRegionISOCode = itm["InvoiceAddressCountryRegionISOCode"]?.ToString();
            JsonPoco.TransportationTemplateId = itm["TransportationTemplateId"]?.ToString();
            JsonPoco.IsConsolidatedInvoiceTarget = itm["IsConsolidatedInvoiceTarget"]?.ToString();
            JsonPoco.OrderOrAgreementCode = itm["OrderOrAgreementCode"]?.ToString();
            JsonPoco.TransportationRoutePlanId = itm["TransportationRoutePlanId"]?.ToString();
            JsonPoco.FixedDueDate = TryCastDTO(itm["FixedDueDate"].Value);
            JsonPoco.DeliveryAddressName = itm["DeliveryAddressName"]?.ToString();
            JsonPoco.ExportReason = itm["ExportReason"]?.ToString();

            //SalesOrderTestPoco.FixedExchangeRate = ToInt64(itm["FixedExchangeRate"]?.ToString());
            long.TryParse(itm["FixedExchangeRate"]?.ToString(), out ota);
            JsonPoco.FixedExchangeRate = ota;

            JsonPoco.IntrastatTransactionCode = itm["IntrastatTransactionCode"]?.ToString();
            JsonPoco.InvoiceAddressStreetInKana = itm["InvoiceAddressStreetInKana"]?.ToString();
            JsonPoco.InvoiceBuildingCompliment = itm["InvoiceBuildingCompliment"]?.ToString();
            JsonPoco.InvoiceAddressZipCode = itm["InvoiceAddressZipCode"]?.ToString();

            //SalesOrderTestPoco.TotalDiscountAmount = ToInt64(itm["TotalDiscountAmount"]?.ToString());
            long.TryParse(itm["TotalDiscountAmount"]?.ToString(), out ota);
            JsonPoco.TotalDiscountAmount = ota;

            JsonPoco.ShippingCarrierServiceId = itm["ShippingCarrierServiceId"]?.ToString();
            JsonPoco.IsOneTimeCustomer = itm["IsOneTimeCustomer"]?.ToString();
            long.TryParse(itm["DeliveryAddressZipCode"]?.ToString(), out ota);
            JsonPoco.DeliveryAddressZipCode = ota;
            JsonPoco.OrderTakerPersonnelNumber = itm["OrderTakerPersonnelNumber"]?.ToString();
            JsonPoco.DeliveryAddressCityInKana = itm["DeliveryAddressCityInKana"]?.ToString();
            JsonPoco.DeliveryAddressPostBox = itm["DeliveryAddressPostBox"]?.ToString();
            JsonPoco.IsDeliveryAddressOrderSpecific = itm["IsDeliveryAddressOrderSpecific"]?.ToString();
            JsonPoco.InvoiceAddressStateId = itm["InvoiceAddressStateId"]?.ToString();
            JsonPoco.RequestedShippingDate = TryCastDTO(itm["RequestedShippingDate"].Value);

            long.TryParse(itm["DeliveryAddressLatitude"]?.ToString(), out ota);
            JsonPoco.DeliveryAddressLatitude = ota;

            JsonPoco.DeliveryBuildingCompliment = itm["DeliveryBuildingCompliment"]?.ToString();
            JsonPoco.InvoiceAddressCountryRegionId = itm["InvoiceAddressCountryRegionId"]?.ToString();
            JsonPoco.IsEInvoiceDimensionAccountCodeSpecifiedPerLine = itm["IsEInvoiceDimensionAccountCodeSpecifiedPerLine"]?.ToString();
            JsonPoco.InvoiceType = itm["InvoiceType"]?.ToString();
            JsonPoco.EUSalesListCode = itm["EUSalesListCode"]?.ToString();
            JsonPoco.ProjectId = itm["ProjectId"]?.ToString();
            JsonPoco.OverrideSalesTax = itm["OverrideSalesTax"]?.ToString();
            JsonPoco.QuotationNumber = itm["QuotationNumber"]?.ToString();
            JsonPoco.OrderResponsiblePersonnelNumber = itm["OrderResponsiblePersonnelNumber"]?.ToString();
            JsonPoco.CommissionCustomerGroupId = itm["CommissionCustomerGroupId"]?.ToString();
            JsonPoco.LanguageId = itm["LanguageId"]?.ToString();
            JsonPoco.LineDiscountCustomerGroupCode = itm["LineDiscountCustomerGroupCode"]?.ToString();
            JsonPoco.ShippingCarrierCustomerAccountNumber = itm["ShippingCarrierCustomerAccountNumber"]?.ToString();
            JsonPoco.SubBillCreatedFromSubscriptionBilling = itm["SubBillCreatedFromSubscriptionBilling"]?.ToString();
            JsonPoco.RevRecReallocationId = itm["RevRecReallocationId"]?.ToString();
            JsonPoco.RevRecFollowOriginalPricingMethod = itm["RevRecFollowOriginalPricingMethod"]?.ToString();
            JsonPoco.RevRecMultipleSOReallocation = itm["RevRecMultipleSOReallocation"]?.ToString();

            //SalesOrderTestPoco.RevRecLatestReverseJournal = ToInt64(itm["RevRecLatestReverseJournal"]?.ToString());
            long.TryParse(itm["DeliveryAddressZipCode"]?.ToString(), out ota);
            JsonPoco.RevRecLatestReverseJournal = ota;

            JsonPoco.RevRecContractEndDate = TryCastDTO(itm["RevRecContractEndDate"].Value);
            JsonPoco.RevRecContractEndDate = TryCastDTO(itm["RevRecContractEndDate"].Value);
            JsonPoco.RevRecContractStartDate = TryCastDTO(itm["RevRecContractStartDate"].Value);
            JsonPoco.SkipGlobalUnifiedPricingCalculation = itm["SkipGlobalUnifiedPricingCalculation"]?.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex?.ToString()}");
        }
        return JsonPoco;
    }

    private SalesOrderTestPoco Method(string sampleJsn)
    {
        SalesOrderTestPoco JsonPoco = new();
        JObject sampleJsnObj = (JObject)JsonConvert.DeserializeObject(sampleJsn);
        Uri odata = new Uri(sampleJsnObj.First.First?.ToString());
        //JsonPoco.OdataContext = odata;
        for (int i = 0; i < ((JContainer)((JProperty)sampleJsnObj.Last).Value).Count; i++)
        {
            Dictionary<string, string> jsnObj = [];
            //var child = new System.Collections.Generic.ICollectionDebugView<Newtonsoft.Json.Linq.JToken>(sampleJsnObj.ChildrenTokens).Items[1]
            jsnObj.Add(sampleJsnObj.First.Path, sampleJsnObj.First.First?.ToString());
            for (int j = 0; j < ((JContainer)((JContainer)((JContainer)sampleJsnObj.Last).First).First).Count; j++)
            {

            }

        }
        return JsonPoco;
    }

    private string PrepareJson(string inputStr)
    {
        string jsn = Emp;
        try
        {
            inputStr = inputStr.Replace("\r\n", null);
            string[] strs = inputStr.Split(",", 2);
            string odata = strs[0].Replace("{  ", Emp);
            string props = Replace(strs[1], "", ["  \"value\": [    ", "  ]}",]);

            jsn = "[" + string.Join(",", props.Split("},").Select(str => !IsEmpty(str) ? str.Replace("}", "") + "," + odata + "}" : null)) + "]";
            return jsn;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    private string Replace(string input, string replace = "", params string[] strs)
    {
        try
        {
            return string.Join(replace, input.Split(strs, StringSplitOptions.None));
        }
        catch (Exception ex)
        {
            return input;
        }
    }

    private async Task JsonToDB()
    {
        string clientId = "f59652f6-fd73-411b-ba47-5002f217eff9";
        string clientSecret = "R1Z8Q~-nETEjRazu1X4qxi6C1~PTJsCkz-y~ccid";
        string tenantId = "cc53a9a2-48fc-49e7-8f12-ef5a565cbcbe";
        string authority = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
        string resource = "https://modernuat.sandbox.operations.dynamics.com";

        string source = "SalesOrderHeadersV2";
        string url = $"{resource}/data/{source}";

        using var client = new HttpClient();
        var content = new FormUrlEncodedContent(
        [
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("resource", resource)
        ]);

        try
        {
            var tokenResponse = await client?.PostAsync(authority, content);
            tokenResponse.EnsureSuccessStatusCode();
            var tokenJson = await tokenResponse?.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(tokenJson);

            if (token != null && !string.IsNullOrEmpty(token.AccessToken))
            {
                string apiUrl = url;

                //?
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                httpClient.Timeout = TimeSpan.FromMinutes(5.0);

                var response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("Failed to retrieve access token.");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Request Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async Task<bool> CheckTableExists(SalesOrderContext cntxt)
    {
        for (int i = 0; i < 3; i++)
        {
            try
            {
                // Try to access the poco table
                var testQuery = await cntxt.SalesOrderTestPoco.FirstOrDefaultAsync();
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

    private async Task ApplyMigration(SalesOrderContext cntxt)
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