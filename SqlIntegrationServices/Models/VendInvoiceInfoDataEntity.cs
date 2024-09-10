using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "RecId1", "TableRefId1")]
public abstract partial class VendInvoiceInfoDataEntityBase
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
    public long RecId1 { get; set; }

    [Key]
    [StringLength(255)]
    public string TableRefId1 { get; set; } = null!;

    public int? AddressRefTableId { get; set; }

    public long? AdvanceApplicationId { get; set; }

    [StringLength(2000)]
    public string? Approved { get; set; }

    [StringLength(2000)]
    public string? BatchAdministration { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CashDisc { get; set; }

    [StringLength(2000)]
    public string? CashDiscCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CashDiscPercent { get; set; }

    [StringLength(2000)]
    public string? changedManually { get; set; }

    [StringLength(2000)]
    public string? closed { get; set; }

    [StringLength(2000)]
    public string? CountyOrigDest { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CreditCorrection { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? DefaultDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DocumentNum { get; set; }

    [StringLength(2000)]
    public string? DocumentOrigin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDateTime { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? EndDisc { get; set; }

    [StringLength(2000)]
    public string? EnterpriseNumber { get; set; }

    [StringLength(2000)]
    public string? ErrorInvalidDistribution { get; set; }

    [StringLength(2000)]
    public string? EUROTriangulation { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRateSecondary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FixedDueDate { get; set; }

    [StringLength(2000)]
    public string? FixedExchRate { get; set; }

    [StringLength(2000)]
    public string? Hold { get; set; }

    [StringLength(2000)]
    public string? IgnoreCalculatedSalesTax { get; set; }

    [StringLength(2000)]
    public string? InclTax { get; set; }

    public long? IntrastatCommodity { get; set; }

    [StringLength(2000)]
    public string? InventDimId { get; set; }

    [StringLength(2000)]
    public string? InventLocationId { get; set; }

    [StringLength(2000)]
    public string? InventSiteId { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceLineNum { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceReleaseDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceRoundOff { get; set; }

    [StringLength(2000)]
    public string? InvoiceType { get; set; }

    [StringLength(2000)]
    public string? LastMatchVariance { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineNum { get; set; }

    [StringLength(2000)]
    public string? LineType { get; set; }

    [StringLength(2000)]
    public string? ListCode { get; set; }

    [StringLength(2000)]
    public string? Log { get; set; }

    [StringLength(2000)]
    public string? MarkupGroup { get; set; }

    [StringLength(2000)]
    public string? MatchStatus { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultiLnDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultiLnPercent { get; set; }

    [StringLength(2000)]
    public string? Num { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroup { get; set; }

    [StringLength(2000)]
    public string? OrderAccount { get; set; }

    [StringLength(2000)]
    public string? OrderAccount1 { get; set; }

    [StringLength(2000)]
    public string? Ordering { get; set; }

    [StringLength(2000)]
    public string? OrigCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? OrigPurchId { get; set; }

    [StringLength(2000)]
    public string? OrigStateId { get; set; }

    public byte[]? PackedExtensions { get; set; }

    [StringLength(2000)]
    public string? ParmId { get; set; }

    [StringLength(2000)]
    public string? ParmId1 { get; set; }

    [StringLength(2000)]
    public string? ParmJobStatus { get; set; }

    [StringLength(2000)]
    public string? Payment { get; set; }

    [StringLength(2000)]
    public string? PaymentSched { get; set; }

    [StringLength(2000)]
    public string? PaymId { get; set; }

    [StringLength(2000)]
    public string? PaymMode { get; set; }

    [StringLength(2000)]
    public string? PaymSpec { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PDSCalculatedUnitPrice { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWReceiveNow { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWRemainAfter { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWRemainBefore { get; set; }

    [StringLength(2000)]
    public string? PerformFullInvoiceMatching { get; set; }

    [StringLength(2000)]
    public string? Port { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceUnit { get; set; }

    [StringLength(2000)]
    public string? ProcessingAdvanced { get; set; }

    public long? ProcurementCategory { get; set; }

    [StringLength(2000)]
    public string? PSAIsFinal { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PSAReleaseAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PSAReleasePercent { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PSARetainageAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PSARetainageBalance { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PSARetainagePercent { get; set; }

    public long? PurchaseLineLineNumber { get; set; }

    [StringLength(2000)]
    public string? PurchId { get; set; }

    public long? PurchLineRecId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchMarkup { get; set; }

    [StringLength(2000)]
    public string? PurchName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchPrice { get; set; }

    [StringLength(2000)]
    public string? PurchUnit { get; set; }

    public long? ReasonTableRef { get; set; }

    public bool? ReCalculate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReceiveNow { get; set; }

    [StringLength(2000)]
    public string? ReleaseDateComment { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainAfter { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainAfterInvent { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainBefore { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainBeforeInventPhysical { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyExchangeRate { get; set; }

    [StringLength(2000)]
    public string? RequestStatus { get; set; }

    [StringLength(2000)]
    public string? SettleVoucher { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDateTime { get; set; }

    [StringLength(2000)]
    public string? StatProcId { get; set; }

    [StringLength(2000)]
    public string? Storno { get; set; }

    [StringLength(2000)]
    public string? TableRefId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Tax1099Amount { get; set; }

    public long? Tax1099BoxDetail { get; set; }

    public long? Tax1099Fields { get; set; }

    [StringLength(2000)]
    public string? Tax1099State { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Tax1099StateAmount { get; set; }

    [StringLength(2000)]
    public string? TaxGroup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxRoundOff { get; set; }

    [StringLength(2000)]
    public string? TransactionCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? Transport { get; set; }

    [StringLength(2000)]
    public string? VarianceApproved { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VarianceApprovedDateTime { get; set; }

    [StringLength(2000)]
    public string? VarianceComment { get; set; }

    [StringLength(2000)]
    public string? VATNum { get; set; }

    [StringLength(2000)]
    public string? VendBankAccountID { get; set; }

    [StringLength(2000)]
    public string? VendInvoiceGroup { get; set; }

    [StringLength(2000)]
    public string? VendInvoiceSaveStatus { get; set; }

    [StringLength(2000)]
    public string? VendorRequestedWorkerEmail { get; set; }

    [StringLength(2000)]
    public string? VendPaymentGroup { get; set; }
}

public partial class VendInvoiceInfoDataEntityTest : VendInvoiceInfoDataEntityBase {}

public partial class VendInvoiceInfoDataEntity : VendInvoiceInfoDataEntityBase {}
