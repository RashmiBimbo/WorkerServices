using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "HeaderReference")]
public abstract partial class VendorInvoiceHeadersBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string HeaderReference { get; set; } = null!;

    [StringLength(2000)]
    public string? AccessKey { get; set; }

    [StringLength(2000)]
    public string? ApprovePostingWithMatchingDiscrepancies { get; set; }

    [StringLength(2000)]
    public string? ApproverPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? BankAccount { get; set; }

    [StringLength(2000)]
    public string? BankConstantSymbol { get; set; }

    [StringLength(2000)]
    public string? BankSpecificSymbol { get; set; }

    [StringLength(36)]
    public string? BusinessDocumentSubmissionId_W { get; set; }

    [StringLength(2000)]
    public string? CarrierName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CashDiscount { get; set; }

    [StringLength(2000)]
    public string? CashDiscountCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscountDate { get; set; }

    [StringLength(2000)]
    public string? CFPSCode { get; set; }

    [StringLength(2000)]
    public string? ChargesGroup { get; set; }

    [StringLength(2000)]
    public string? Comment { get; set; }

    [StringLength(2000)]
    public string? CountyOrigDest { get; set; }

    [StringLength(2000)]
    public string? CreditCorrection { get; set; }

    [StringLength(2000)]
    public string? CTeType { get; set; }

    [StringLength(2000)]
    public string? Currency { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [StringLength(2000)]
    public string? DeliveryFreightChargeTerms { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    [StringLength(2000)]
    public string? DeliveryPackingName { get; set; }

    [StringLength(2000)]
    public string? DeliveryStateRegistered { get; set; }

    [StringLength(2000)]
    public string? DeliveryTransportBrand { get; set; }

    [StringLength(2000)]
    public string? DeliveryVehicleNumber { get; set; }

    [StringLength(2000)]
    public string? DimensionDisplayValue { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? DiscountPercentage { get; set; }

    [StringLength(2000)]
    public string? DocumentNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    public DateTime? EndDateTime { get; set; }

    [StringLength(2000)]
    public string? EnterpriseNumber { get; set; }

    [StringLength(2000)]
    public string? ErrorInvalidDistribution { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ExchangeRate { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentModel { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentOperationTypeId { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentSeries { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentSpecie { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentTypeId { get; set; }

    [StringLength(2000)]
    public string? FiscalEstablishmentId { get; set; }

    [StringLength(2000)]
    public string? FiscalOperationPresenceType { get; set; }

    [StringLength(2000)]
    public string? FixedRate { get; set; }

    [StringLength(2000)]
    public string? FreightedBy { get; set; }

    [StringLength(2000)]
    public string? GSTImportDeclarationNumber { get; set; }

    [StringLength(2000)]
    public string? GSTInvoiceType { get; set; }

    [StringLength(2000)]
    public string? IgnoreCalculatedSalesTax { get; set; }

    [StringLength(2000)]
    public string? ImportDeclarationNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ImportedAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ImportedSalesTax { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceDate { get; set; }

    [StringLength(2000)]
    public string? InvoiceDescription { get; set; }

    [StringLength(2000)]
    public string? InvoiceGroup { get; set; }

    [StringLength(2000)]
    public string? InvoiceNumber { get; set; }

    public DateTime? InvoicePaymentReleaseDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceReceivedDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InvoiceRoundOff { get; set; }

    [StringLength(2000)]
    public string? InvoiceSeries { get; set; }

    [StringLength(2000)]
    public string? IsApproved { get; set; }

    [StringLength(2000)]
    public string? IsBatch { get; set; }

    [StringLength(2000)]
    public string? IsElectronicInvoiceForService { get; set; }

    [StringLength(2000)]
    public string? IsFinalUser { get; set; }

    [StringLength(2000)]
    public string? IsOnHold { get; set; }

    [StringLength(2000)]
    public string? IsPricesIncludeSalesTax { get; set; }

    [StringLength(2000)]
    public string? ListCode { get; set; }

    [StringLength(2000)]
    public string? Log { get; set; }

    [StringLength(2000)]
    public string? MethodOfPayment { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroup { get; set; }

    [StringLength(2000)]
    public string? PaymentGroupCode { get; set; }

    [StringLength(2000)]
    public string? PaymentId { get; set; }

    [StringLength(2000)]
    public string? PaymentSchedule { get; set; }

    [StringLength(2000)]
    public string? PaymentSpecification { get; set; }

    [StringLength(2000)]
    public string? Port { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [StringLength(2000)]
    public string? PSNBankAccountId { get; set; }

    [StringLength(2000)]
    public string? PSNCardHolderName { get; set; }

    [StringLength(2000)]
    public string? PSNCardNumberDigits { get; set; }

    [StringLength(2000)]
    public string? PSNPostingDefinitionCode { get; set; }

    [StringLength(2000)]
    public string? PSNPurchasingCardTransactionType { get; set; }

    [StringLength(2000)]
    public string? PSNReferenceInvoiceNumber { get; set; }

    [StringLength(2000)]
    public string? PSNVendorAccountForBalancePayoff { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PurchReceiptDate_W { get; set; }

    public bool? Recalculation { get; set; }

    [StringLength(2000)]
    public string? ReleaseDateComment { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReportingCurrencyExchangeRate { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroup { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SalesTaxRounding { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SecondaryExchangeRate { get; set; }

    [StringLength(2000)]
    public string? ServiceCodeOnDeliveryAddress { get; set; }

    [StringLength(2000)]
    public string? SettleVoucher { get; set; }

    [StringLength(2000)]
    public string? Site { get; set; }

    public DateTime? StartDateTime { get; set; }

    [StringLength(2000)]
    public string? StatisticsProcedure { get; set; }

    [StringLength(2000)]
    public string? TaxExemptNumber { get; set; }

    [StringLength(2000)]
    public string? TermsOfPayment { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TotalDiscount { get; set; }

    [StringLength(2000)]
    public string? TransactionCode { get; set; }

    [StringLength(2000)]
    public string? Transport { get; set; }

    [StringLength(2000)]
    public string? Triangulation { get; set; }

    [StringLength(2000)]
    public string? UUID { get; set; }

    public DateTime? VarianceApprovedDateTime { get; set; }

    [StringLength(2000)]
    public string? VariancePersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? VendorAccount { get; set; }

    [StringLength(2000)]
    public string? VendorInvoiceReviewStatus { get; set; }

    [StringLength(2000)]
    public string? VendorInvoiceType { get; set; }

    [StringLength(2000)]
    public string? VendorName { get; set; }

    [StringLength(2000)]
    public string? VendorPaymentFinancialInterestCode { get; set; }

    [StringLength(2000)]
    public string? VendorPaymentFineCode { get; set; }

    [StringLength(2000)]
    public string? VendorRequestedWorkerEmail { get; set; }

    [StringLength(2000)]
    public string? Warehouse { get; set; }

    [StringLength(2000)]
    public string? HeaderOnlyImport { get; set; }

    [StringLength(2000)]
    public string? PackingslipRange { get; set; }

    [StringLength(2000)]
    public string? PurchIdRange { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesTax { get; set; }

    public long? ElectronicInvoiceFrameworkType_FR { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccountServiceCode_FR { get; set; }

    [StringLength(2000)]
    public string? ProjectManagerServiceCode_FR { get; set; }

    [StringLength(2000)]
    public string? ProjectManager_FR { get; set; }

    [StringLength(2000)]
    public string? DocumentClassificationId { get; set; }

    [StringLength(2000)]
    public string? DocumentClassificationNumber { get; set; }

    [StringLength(2000)]
    public string? DTEDigest { get; set; }

    [StringLength(2000)]
    public string? DTEFileName { get; set; }

    [StringLength(2000)]
    public string? DTEShipmentID { get; set; }

    [StringLength(2000)]
    public string? WithholdingSetID { get; set; }

    [StringLength(2000)]
    public string? InvoiceUUID { get; set; }
}

public partial class VendorInvoiceHeadersTest : VendorInvoiceHeadersBase { }

public partial class VendorInvoiceHeaders : VendorInvoiceHeadersBase { }
