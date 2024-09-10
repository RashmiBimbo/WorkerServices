using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventTransId", "InvoiceId", "ItemId", "TaxCode", "TaxDirection", "TransDate", "Voucher")]
public abstract partial class TaxTransInDataEntityBase
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
    public string InventTransId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InvoiceId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string TaxCode { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string TaxDirection { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [Key]
    [StringLength(255)]
    public string Voucher { get; set; } = null!;

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AbatementAmount { get; set; }

    [StringLength(2000)]
    public string? AbatementCertificateNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AbatementPercent { get; set; }

    [StringLength(2000)]
    public string? ApplyExcise { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AssessableValue { get; set; }

    [StringLength(2000)]
    public string? AssetLocation { get; set; }

    [StringLength(2000)]
    public string? BankName { get; set; }

    [StringLength(2000)]
    public string? BatchNumber { get; set; }

    [StringLength(2000)]
    public string? BillOfMaterialJournalNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ChallanDate { get; set; }

    [StringLength(2000)]
    public string? ChallanNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ClaimPercentage { get; set; }

    [StringLength(2000)]
    public string? CompanyAddress { get; set; }

    [StringLength(2000)]
    public string? CompanyName { get; set; }

    public long? CompanyRegistrationNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CreditAmount { get; set; }

    [StringLength(2000)]
    public string? Customer { get; set; }

    [StringLength(2000)]
    public string? CustomerAddress { get; set; }

    public long? CustomerLocation { get; set; }

    public long? CustomerTaxInformation { get; set; }

    public long? CustVendRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DebitAmount { get; set; }

    [StringLength(2000)]
    public string? Exempt { get; set; }

    public long? HSNCodeTable { get; set; }

    [StringLength(2000)]
    public string? InventLocationId { get; set; }

    [StringLength(2000)]
    public string? InventSiteId { get; set; }

    [StringLength(2000)]
    public string? InventStatusId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceAmount { get; set; }

    [StringLength(2000)]
    public string? InvoiceNumber { get; set; }

    public long? InvoiceRefRecID { get; set; }

    [StringLength(2000)]
    public string? JournalInvoice { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? JournalInvoiceAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? JournalInvoiceDate { get; set; }

    [StringLength(2000)]
    public string? JournalType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LoadOnInventoryAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LoadOnInventoryPercent { get; set; }

    [StringLength(2000)]
    public string? Location { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PayableAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PostedTaxAmout { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Quantity { get; set; }

    public long? RefRecId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SalesInvoiceDate { get; set; }

    [StringLength(2000)]
    public string? SalesOrder { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SalesOrderDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesOrderQty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SalesPackingSlipDate { get; set; }

    [StringLength(2000)]
    public string? SalesPackingSlipNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesPackingSlipQuantity { get; set; }

    public long? SalesTaxFormTypes { get; set; }

    [StringLength(2000)]
    public string? Source { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SourceBaseAmountCur { get; set; }

    public long? SourceRecId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SourceRegulateAmountCur { get; set; }

    public int? SourceTableId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SourceTaxAmountCur { get; set; }

    [StringLength(2000)]
    public string? TaxAccountType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxAmount { get; set; }

    public long? TaxComponentTable { get; set; }

    [StringLength(2000)]
    public string? TaxCurrency { get; set; }

    [StringLength(2000)]
    public string? TaxPeriod { get; set; }

    public long? TaxReportHierarchyNode_IN { get; set; }

    [StringLength(2000)]
    public string? TaxType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxValue { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TransactionAmount { get; set; }

    [StringLength(2000)]
    public string? Unit { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Value { get; set; }

    [StringLength(2000)]
    public string? Vendor { get; set; }

    [StringLength(2000)]
    public string? VendorAddress { get; set; }

    [StringLength(2000)]
    public string? VendorCalculationDateType { get; set; }

    public long? VendorLocation { get; set; }

    public long? VendorTaxInformation { get; set; }

    [StringLength(2000)]
    public string? VoucherCurrency { get; set; }

    [StringLength(2000)]
    public string? Warehouse { get; set; }

    public long? TransRecId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class TaxTransInDataEntityTest : TaxTransInDataEntityBase {}

public partial class TaxTransInDataEntity : TaxTransInDataEntityBase {}
