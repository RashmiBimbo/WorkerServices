using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("AccountNum", "dataAreaId", "RecId1")]
public partial class VendorInvoiceTransDatasEntity
{
    [StringLength(2000)]
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
    public long RecId1 { get; set; }

    public long? AdvanceApplicationId { get; set; }

    public long? AgreementLine_PSN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AssessableValue_IN { get; set; }

    public long? CompanyLocation_IN { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreditNoteDate_IN { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    public long? CustomsTariffCodeTable_IN { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    public long? DeliveryPostalAddress { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? DestCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? DestCounty { get; set; }

    [StringLength(2000)]
    public string? DestState { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DiscAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DiscPercent { get; set; }

    [StringLength(2000)]
    public string? DSA_IN { get; set; }

    [StringLength(2000)]
    public string? ExciseRecordType_IN { get; set; }

    public long? ExciseTariffCodes_IN { get; set; }

    [StringLength(2000)]
    public string? ExciseType_IN { get; set; }

    [StringLength(2000)]
    public string? ExternalItemId { get; set; }

    [StringLength(2000)]
    public string? GTAServiceCategory_IN { get; set; }

    [StringLength(2000)]
    public string? InterCompanyInventTransId { get; set; }

    [StringLength(2000)]
    public string? InternalInvoiceId { get; set; }

    public long? IntrastatCommodity { get; set; }

    [StringLength(2000)]
    public string? IntrastatDispatchId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InventDate { get; set; }

    [StringLength(2000)]
    public string? InventDimId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InventQty { get; set; }

    [StringLength(2000)]
    public string? InventRefId { get; set; }

    [StringLength(2000)]
    public string? InventRefTransId { get; set; }

    [StringLength(2000)]
    public string? InventRefType { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceDate { get; set; }

    [StringLength(2000)]
    public string? InvoiceId { get; set; }

    [StringLength(2000)]
    public string? IsPwp { get; set; }

    [StringLength(2000)]
    public string? ItemCodeId { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmountMST { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmountMST_W { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmountTax { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineNum { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LinePercent { get; set; }

    [StringLength(2000)]
    public string? LineType { get; set; }

    [StringLength(2000)]
    public string? MarkupCode_RU { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MaximumRetailPrice_IN { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultiLnDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultiLnPercent { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? NonRecoverablePercent_IN { get; set; }

    [StringLength(2000)]
    public string? numberSequenceGroup { get; set; }

    [StringLength(2000)]
    public string? OrigCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? OrigPurchId { get; set; }

    [StringLength(2000)]
    public string? OrigStateId { get; set; }

    public byte[]? PackedExtensions { get; set; }

    [StringLength(2000)]
    public string? PartDelivery { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWQty { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWQtyPhysical { get; set; }

    [StringLength(2000)]
    public string? Port { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceUnit { get; set; }

    public long? ProcurementCategory { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PSAReleaseAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PSARetainageAmount { get; set; }

    public long? PurchaseLineLineNumber { get; set; }

    public long? PurchCommitmentLine_PSN { get; set; }

    [StringLength(2000)]
    public string? PurchId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchMarkup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchPrice { get; set; }

    [StringLength(2000)]
    public string? PurchUnit { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Qty { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyPhysical { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RBOPackageLineNum { get; set; }

    [StringLength(2000)]
    public string? ReadyForPayment { get; set; }

    public long? ReasonTableRef { get; set; }

    public long? RegistrationPostalAddress_IN { get; set; }

    [StringLength(2000)]
    public string? RetailPackageId { get; set; }

    [StringLength(2000)]
    public string? ReverseCharge_W { get; set; }

    public long? SalesTaxFormTypes_IN { get; set; }

    public long? ServiceCodeTable_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SettleTax1099Amount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SettleTax1099StateAmount { get; set; }

    public long? SourceDocumentLine { get; set; }

    [StringLength(2000)]
    public string? StatProcId { get; set; }

    [StringLength(2000)]
    public string? StockedProduct { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Tax1099Amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Tax1099Date { get; set; }

    public long? Tax1099Fields { get; set; }

    [StringLength(2000)]
    public string? Tax1099Num { get; set; }

    public long? Tax1099RecId { get; set; }

    [StringLength(2000)]
    public string? Tax1099State { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Tax1099StateAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxAmount { get; set; }

    [StringLength(2000)]
    public string? TaxAutogenerated { get; set; }

    [StringLength(2000)]
    public string? TaxGroup { get; set; }

    [StringLength(2000)]
    public string? TaxItemGroup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxWithholdLineNum_IN { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdVoucher_IN { get; set; }

    [StringLength(2000)]
    public string? TaxWriteCode { get; set; }

    [StringLength(2000)]
    public string? TCSGroup_IN { get; set; }

    [StringLength(2000)]
    public string? TDSGroup_IN { get; set; }

    [StringLength(2000)]
    public string? TransactionCode { get; set; }

    [StringLength(2000)]
    public string? Transport { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VATAmount_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VATDeferred_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VATExpense_IN { get; set; }

    [StringLength(2000)]
    public string? VATGoodsType_IN { get; set; }

    public long? VendorLocation_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Weight { get; set; }
}
