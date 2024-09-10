using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InvoiceDate", "InvoiceNumber", "LedgerVoucher", "LineCreationSequenceNumber")]
public abstract partial class SalesInvoiceV2LinesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    public DateTime InvoiceDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InvoiceNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string LedgerVoucher { get; set; } = null!;

    [Key]
    public int LineCreationSequenceNumber { get; set; }

    public int? CITOD { get; set; }

    public DateTime? ConfirmedShippingDate { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DimensionNumber { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? DiscAmount { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? DiscPercent { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? HGPercent1 { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? HGPercent2 { get; set; }

    [StringLength(2000)]
    public string? InventorySiteId { get; set; }

    [StringLength(2000)]
    public string? InventoryWarehouseId { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? InvoicedQuantity { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    public long? LedgerDimension { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? LineAmount { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? LineDisc { get; set; }

    [StringLength(2000)]
    public string? LineDiscount { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? LineNum { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? LineTotalChargeAmount { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? LineTotalDiscountAmount { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? LineTotalTaxAmount { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? MultiLnDisc { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? MultiLnPercent { get; set; }

    [StringLength(2000)]
    public string? OrderedInventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? PriceGroupId { get; set; }

    [StringLength(2000)]
    public string? ProductColorId { get; set; }

    [StringLength(2000)]
    public string? ProductConfigurationId { get; set; }

    [StringLength(2000)]
    public string? ProductDescription { get; set; }

    [StringLength(2000)]
    public string? ProductName { get; set; }

    [StringLength(2000)]
    public string? ProductNumber { get; set; }

    [StringLength(2000)]
    public string? ProductSizeId { get; set; }

    [StringLength(2000)]
    public string? ProductStyleId { get; set; }

    [StringLength(2000)]
    public string? ProductVersionId { get; set; }

    public long? RecId1 { get; set; }

    [StringLength(2000)]
    public string? ReturnReasonCodeId { get; set; }

    [StringLength(2000)]
    public string? SalesId { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? SalesPrice { get; set; }

    [StringLength(2000)]
    public string? SalesProductCategoryHierarchyName { get; set; }

    [StringLength(2000)]
    public string? SalesProductCategoryName { get; set; }

    [StringLength(2000)]
    public string? SalesUnitSymbol { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? SumLineDisc { get; set; }
}

public partial class SalesInvoiceV2LinesTest : SalesInvoiceV2LinesBase {}

public partial class SalesInvoiceV2Lines : SalesInvoiceV2LinesBase {}
