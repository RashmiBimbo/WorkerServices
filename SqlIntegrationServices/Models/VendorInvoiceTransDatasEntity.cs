using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("AccountNum", "DataAreaId", "RecId1")]
public abstract partial class VendorInvoiceTransDatasEntityBase
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
    [Column("dataAreaId")]
    [StringLength(255)]
    public string DataAreaId { get; set; } = null!;

    [Key]
    public long RecId1 { get; set; }

    public long? AdvanceApplicationId { get; set; }

    [Column("AgreementLine_PSN")]
    public long? AgreementLinePsn { get; set; }

    [Column("AssessableValue_IN", TypeName = "decimal(28, 16)")]
    public decimal? AssessableValueIn { get; set; }

    [Column("CompanyLocation_IN")]
    public long? CompanyLocationIn { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [Column("CreditNoteDate_IN", TypeName = "datetime")]
    public DateTime? CreditNoteDateIn { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [Column("CustomsTariffCodeTable_IN")]
    public long? CustomsTariffCodeTableIn { get; set; }

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

    [Column("DSA_IN")]
    [StringLength(2000)]
    public string? DsaIn { get; set; }

    [Column("ExciseRecordType_IN")]
    [StringLength(2000)]
    public string? ExciseRecordTypeIn { get; set; }

    [Column("ExciseTariffCodes_IN")]
    public long? ExciseTariffCodesIn { get; set; }

    [Column("ExciseType_IN")]
    [StringLength(2000)]
    public string? ExciseTypeIn { get; set; }

    [StringLength(2000)]
    public string? ExternalItemId { get; set; }

    [Column("GTAServiceCategory_IN")]
    [StringLength(2000)]
    public string? GtaserviceCategoryIn { get; set; }

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

    [Column("LineAmountMST", TypeName = "decimal(28, 16)")]
    public decimal? LineAmountMst { get; set; }

    [Column("LineAmountMST_W", TypeName = "decimal(28, 16)")]
    public decimal? LineAmountMstW { get; set; }

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

    [Column("MarkupCode_RU")]
    [StringLength(2000)]
    public string? MarkupCodeRu { get; set; }

    [Column("MaximumRetailPrice_IN", TypeName = "decimal(28, 16)")]
    public decimal? MaximumRetailPriceIn { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultiLnDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultiLnPercent { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [Column("NonRecoverablePercent_IN", TypeName = "decimal(28, 16)")]
    public decimal? NonRecoverablePercentIn { get; set; }

    [Column("numberSequenceGroup")]
    [StringLength(2000)]
    public string? NumberSequenceGroup { get; set; }

    [StringLength(2000)]
    public string? OrigCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? OrigPurchId { get; set; }

    [StringLength(2000)]
    public string? OrigStateId { get; set; }

    public byte[]? PackedExtensions { get; set; }

    [StringLength(2000)]
    public string? PartDelivery { get; set; }

    [Column("PdsCWQty", TypeName = "decimal(28, 16)")]
    public decimal? PdsCwqty { get; set; }

    [Column("PdsCWQtyPhysical", TypeName = "decimal(28, 16)")]
    public decimal? PdsCwqtyPhysical { get; set; }

    [StringLength(2000)]
    public string? Port { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceUnit { get; set; }

    public long? ProcurementCategory { get; set; }

    [Column("PSAReleaseAmount", TypeName = "decimal(28, 16)")]
    public decimal? PsareleaseAmount { get; set; }

    [Column("PSARetainageAmount", TypeName = "decimal(28, 16)")]
    public decimal? PsaretainageAmount { get; set; }

    public long? PurchaseLineLineNumber { get; set; }

    [Column("PurchCommitmentLine_PSN")]
    public long? PurchCommitmentLinePsn { get; set; }

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

    [Column("RBOPackageLineNum", TypeName = "decimal(28, 16)")]
    public decimal? RbopackageLineNum { get; set; }

    [StringLength(2000)]
    public string? ReadyForPayment { get; set; }

    public long? ReasonTableRef { get; set; }

    [Column("RegistrationPostalAddress_IN")]
    public long? RegistrationPostalAddressIn { get; set; }

    [StringLength(2000)]
    public string? RetailPackageId { get; set; }

    [Column("ReverseCharge_W")]
    [StringLength(2000)]
    public string? ReverseChargeW { get; set; }

    [Column("SalesTaxFormTypes_IN")]
    public long? SalesTaxFormTypesIn { get; set; }

    [Column("ServiceCodeTable_IN")]
    public long? ServiceCodeTableIn { get; set; }

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

    [Column("TaxWithholdLineNum_IN", TypeName = "decimal(28, 16)")]
    public decimal? TaxWithholdLineNumIn { get; set; }

    [Column("TaxWithholdVoucher_IN")]
    [StringLength(2000)]
    public string? TaxWithholdVoucherIn { get; set; }

    [StringLength(2000)]
    public string? TaxWriteCode { get; set; }

    [Column("TCSGroup_IN")]
    [StringLength(2000)]
    public string? TcsgroupIn { get; set; }

    [Column("TDSGroup_IN")]
    [StringLength(2000)]
    public string? TdsgroupIn { get; set; }

    [StringLength(2000)]
    public string? TransactionCode { get; set; }

    [StringLength(2000)]
    public string? Transport { get; set; }

    [Column("VATAmount_IN", TypeName = "decimal(28, 16)")]
    public decimal? VatamountIn { get; set; }

    [Column("VATDeferred_IN", TypeName = "decimal(28, 16)")]
    public decimal? VatdeferredIn { get; set; }

    [Column("VATExpense_IN", TypeName = "decimal(28, 16)")]
    public decimal? VatexpenseIn { get; set; }

    [Column("VATGoodsType_IN")]
    [StringLength(2000)]
    public string? VatgoodsTypeIn { get; set; }

    [Column("VendorLocation_IN")]
    public long? VendorLocationIn { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Weight { get; set; }
}

public partial class VendorInvoiceTransDatasEntityTest : VendorInvoiceTransDatasEntityBase {}

public partial class VendorInvoiceTransDatasEntity : VendorInvoiceTransDatasEntityBase {}
