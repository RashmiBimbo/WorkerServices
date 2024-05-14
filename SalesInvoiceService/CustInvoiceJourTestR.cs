using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesInvoiceService
{
    public partial class CustInvoiceJourTestR
    {
        [Key]
        [JsonProperty("@odata.etag", NullValueHandling = NullValueHandling.Ignore)]
        public string? Etag { get; set; }

        [DefaultValue("")]
        [JsonProperty("dataAreaId")]
        public string dataAreaId { get; set; }

        [DefaultValue("")]
        [JsonProperty("InvoiceNumber")]
        public string InvoiceNumber { get; set; }

        // Use the Column attribute to specify the column data type
        //[JsonConverter(typeof(ParseStringConverter<DateTimeOffset>))]
        [Column(TypeName = "datetime")]
        [JsonProperty("InvoiceDate")]
        public DateTime InvoiceDate { get; set; }

        [DefaultValue("")]
        [JsonProperty("LedgerVoucher", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string LedgerVoucher { get; set; }

        [DefaultValue("")]
        [JsonProperty("InvoiceAddressCountryRegionISOCode")]
        public string InvoiceAddressCountryRegionISOCode { get; set; }

        [JsonProperty("InvoiceAddressZipCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressZipCode { get; set; }

        [JsonProperty("TotalTaxAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalTaxAmount { get; set; }

        [JsonProperty("InvoiceAddressStreetNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressStreetNumber { get; set; }

        [JsonProperty("TotalDiscountCustomerGroupCode", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalDiscountCustomerGroupCode { get; set; }

        [JsonProperty("InvoiceAddressStreet", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressStreet { get; set; }

        [JsonProperty("TotalChargeAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalChargeAmount { get; set; }

        [JsonProperty("TotalDiscountAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalDiscountAmount { get; set; }

        [JsonProperty("CurrencyCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? CurrencyCode { get; set; }

        [JsonProperty("SalesOrderNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesOrderNumber { get; set; }

        [JsonProperty("DeliveryTermsCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? DeliveryTermsCode { get; set; }

        [JsonProperty("ContactPersonId", NullValueHandling = NullValueHandling.Ignore)]
        public string? ContactPersonId { get; set; }

        [JsonProperty("SalesOrderResponsiblePersonnelNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesOrderResponsiblePersonnelNumber { get; set; }

        [JsonProperty("PaymentTermsName", NullValueHandling = NullValueHandling.Ignore)]
        public string? PaymentTermsName { get; set; }

        [JsonProperty("DeliveryModeCode", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(ParseStringConverter<long>))]
        public string? DeliveryModeCode { get; set; }

        [JsonProperty("InvoiceCustomerAccountNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceCustomerAccountNumber { get; set; }

        [JsonProperty("InvoiceAddressCity", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressCity { get; set; }

        [JsonProperty("InvoiceHeaderTaxAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? InvoiceHeaderTaxAmount { get; set; }

        [JsonProperty("InvoiceAddressState", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressState { get; set; }

        [JsonProperty("InvoiceAddressCountryRegionId", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressCountryRegionId { get; set; }

        [JsonProperty("CustomersOrderReference", NullValueHandling = NullValueHandling.Ignore)]
        public string? CustomersOrderReference { get; set; }

        [JsonProperty("TotalInvoiceAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalInvoiceAmount { get; set; }

        [JsonProperty("SalesOrderOriginCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesOrderOriginCode { get; set; }

        [JsonProperty("SupervisorCodeBak", NullValueHandling = NullValueHandling.Ignore)]
        public string? SupervisorCodeBak { get; set; }

        //[JsonConverter(typeof(ParseStringConverter<DateTimeOffset>))]

        // Use the Column attribute to specify the column data type
        [Column(TypeName = "datetime")]
        [JsonProperty("DemandDateJour", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DemandDateJour { get; set; }

        [JsonProperty("ModifiedDateTime1", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(ParseStringConverter<DateTime>))]

        // Use the Column attribute to specify the column data type
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDateTime1 { get; set; }

        [JsonProperty("SalesId_CT", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesId_CT { get; set; }

        [JsonProperty("RouteCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? RouteCode { get; set; }

        [JsonProperty("IRNNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? IRNNumber { get; set; }

        [JsonProperty("ReturnReasonCodeId", NullValueHandling = NullValueHandling.Ignore)]
        public string? ReturnReasonCodeId { get; set; }

        [JsonProperty("PackerName", NullValueHandling = NullValueHandling.Ignore)]
        public string? PackerName { get; set; }

        [JsonProperty("SalesType", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesType { get; set; }

        [JsonProperty("InvoiceId_CT", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceId_CT { get; set; }

        [JsonProperty("PackerCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? PackerCode { get; set; }

        [JsonProperty("IsSample", NullValueHandling = NullValueHandling.Ignore)]
        public string? IsSample { get; set; }

        [JsonProperty("LoaderName", NullValueHandling = NullValueHandling.Ignore)]
        public string? LoaderName { get; set; }

        [JsonProperty("DriverName", NullValueHandling = NullValueHandling.Ignore)]
        public string? DriverName { get; set; }

        [JsonProperty("OrderId", NullValueHandling = NullValueHandling.Ignore)]
        public string? OrderId { get; set; }

        [JsonProperty("SupervisorCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? SupervisorCode { get; set; }

        [JsonProperty("OrderAccount", NullValueHandling = NullValueHandling.Ignore)]
        public string? OrderAccount { get; set; }

        [JsonProperty("VehicleTag", NullValueHandling = NullValueHandling.Ignore)]
        public string? VehicleTag { get; set; }

        [JsonProperty("VehicleCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? VehicleCode { get; set; }

        [JsonProperty("SalespersonCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalespersonCode { get; set; }

        [JsonProperty("IsReturn", NullValueHandling = NullValueHandling.Ignore)]
        public string? IsReturn { get; set; }

        [JsonProperty("PORefID", NullValueHandling = NullValueHandling.Ignore)]
        public string? PORefID { get; set; }

        [JsonProperty("LoaderCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? LoaderCode { get; set; }

        [JsonProperty("DriverCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? DriverCode { get; set; }

        [JsonProperty("DeliveryName", NullValueHandling = NullValueHandling.Ignore)]
        public string? DeliveryName { get; set; }

        [JsonProperty("RecId1", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(ParseStringConverter<long>))]
        public long? RecId1 { get; set; }

        [JsonProperty("SalesStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesStatus { get; set; }

        [JsonProperty("IsProcessed", NullValueHandling = NullValueHandling.Ignore)]
        public string? IsProcessed { get; set; }

        [JsonProperty("DeliveryAddressName", NullValueHandling = NullValueHandling.Ignore)]
        public string? DeliveryAddressName { get; set; }

        [JsonProperty("SalesId", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesId { get; set; }

        [JsonProperty("IsProcess_CT", NullValueHandling = NullValueHandling.Ignore)]
        public string? IsProcess_CT { get; set; }

        [JsonProperty("AmountMST", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(ParseStringConverter<double>))]
        public decimal? AmountMST { get; set; }

        [JsonProperty("ParentReference", NullValueHandling = NullValueHandling.Ignore)]
        public string? ParentReference { get; set; }
    }

    public partial class CustInvoiceJourTestR
    {
        public static CustInvoiceJourTestR FromJson(string json) => JsonConvert.DeserializeObject<CustInvoiceJourTestR>(json, Converter.Settings);
    }

}

