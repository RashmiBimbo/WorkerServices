using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("AccountNum", "dataAreaId", "InvoiceDate", "InvoiceId", "LedgerVoucher", "PurchId")]
public abstract partial class VendInvoiceJournalDatasEntityBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string AccountNum { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InvoiceId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string LedgerVoucher { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string PurchId { get; set; } = null!;

    public long? BankLCImportLine { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CashDisc { get; set; }

    [StringLength(2000)]
    public string? CashDiscCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CashDiscPercent { get; set; }

    [StringLength(2000)]
    public string? CostLedgerVoucher { get; set; }

    [StringLength(2000)]
    public string? CountryRegionId { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    public long? DeliveryPostalAddress { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? DlvMode { get; set; }

    [StringLength(2000)]
    public string? DlvTerm { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DocumentNum { get; set; }

    [StringLength(2000)]
    public string? DocumentOrigin { get; set; }

    [StringLength(2000)]
    public string? DriverName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? EndDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? EndDiscMST { get; set; }

    [StringLength(2000)]
    public string? EnterpriseNumber { get; set; }

    [StringLength(2000)]
    public string? EUSalesList { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRateSecondary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FixedDueDate { get; set; }

    [StringLength(2000)]
    public string? InclTax { get; set; }

    [StringLength(2000)]
    public string? IntentLetterId_IT { get; set; }

    [StringLength(2000)]
    public string? InterCompanyCompanyId { get; set; }

    [StringLength(2000)]
    public string? InterCompanyLedgerVoucher { get; set; }

    [StringLength(2000)]
    public string? InterCompanyPosted { get; set; }

    [StringLength(2000)]
    public string? InterCompanySalesId { get; set; }

    [StringLength(2000)]
    public string? InternalInvoiceId { get; set; }

    [StringLength(2000)]
    public string? IntrastatDispatch { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceAmountMST { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceRoundOff { get; set; }

    [StringLength(2000)]
    public string? InvoiceType { get; set; }

    [StringLength(2000)]
    public string? ItemBuyerGroupId { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? Listcode { get; set; }

    [StringLength(2000)]
    public string? LoaderName { get; set; }

    public long? LogisticsElectronicAddress { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? numberSequenceGroup { get; set; }

    [StringLength(2000)]
    public string? OperationType_MX { get; set; }

    [StringLength(2000)]
    public string? OrderAccount { get; set; }

    public byte[]? PackedExtensions { get; set; }

    [StringLength(2000)]
    public string? PackerName { get; set; }

    [StringLength(2000)]
    public string? ParmId { get; set; }

    public long? Partition1 { get; set; }

    [StringLength(2000)]
    public string? PaymDayId { get; set; }

    [StringLength(2000)]
    public string? Payment { get; set; }

    [StringLength(2000)]
    public string? PaymentSched { get; set; }

    [StringLength(2000)]
    public string? PaymId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PlafondDate_IT { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [StringLength(2000)]
    public string? Prepayment { get; set; }

    [StringLength(2000)]
    public string? Proforma { get; set; }

    [StringLength(2000)]
    public string? ProjectReference { get; set; }

    public long? PurchAgreementHeader_PSN { get; set; }

    [StringLength(2000)]
    public string? PurchaseType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PurchReceiptDate_W { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Qty { get; set; }

    public long? ReasonTableRef_BR { get; set; }

    public long? RecId1 { get; set; }

    public int? RecVersion1 { get; set; }

    public long? RemittanceAddress { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyExchangeRate { get; set; }

    [StringLength(2000)]
    public string? ReturnItemNum { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReverseChargeAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReverseCharge_UK { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesBalance { get; set; }

    public long? SourceDocumentHeader { get; set; }

    public long? SourceDocumentLine { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SumLineDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SumMarkup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SumMarkupMST { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SumTax { get; set; }

    [StringLength(2000)]
    public string? TaxGroup { get; set; }

    [StringLength(2000)]
    public string? TaxInvoicePurchId { get; set; }

    [StringLength(2000)]
    public string? TaxPrintOnInvoice { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxRoundOff { get; set; }

    [StringLength(2000)]
    public string? TaxSetoffVoucher_IN { get; set; }

    [StringLength(2000)]
    public string? TaxSpecifyByLine { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxWithholdAmount_IN { get; set; }

    public long? TransportationDocument { get; set; }

    [StringLength(2000)]
    public string? Triangulation { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VATAmount_IN { get; set; }

    [StringLength(2000)]
    public string? VATNum { get; set; }

    [StringLength(2000)]
    public string? VehicleCode { get; set; }

    [StringLength(2000)]
    public string? VehicleTag { get; set; }

    [StringLength(2000)]
    public string? VendGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VendInvoiceDate { get; set; }

    public long? VendInvoiceDeclaration_IS { get; set; }

    [StringLength(2000)]
    public string? VendInvoiceGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VendorDocDate { get; set; }

    [StringLength(2000)]
    public string? VendorDocument { get; set; }

    [StringLength(2000)]
    public string? VendorRequestedWorkerEmail { get; set; }

    [StringLength(2000)]
    public string? VendPaymentGroup { get; set; }

    [StringLength(2000)]
    public string? VendReference { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Volume { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Weight { get; set; }
}

public partial class VendInvoiceJournalDatasEntityTest : VendInvoiceJournalDatasEntityBase { }

public partial class VendInvoiceJournalDatasEntity : VendInvoiceJournalDatasEntityBase { }
