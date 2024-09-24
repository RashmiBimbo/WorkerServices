using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InvoiceDate", "InvoiceNumber", "LedgerVoucher", "LineCreationSequenceNumber")]
public abstract partial class CustInvoiceTrans_1Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(50)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Key]
    [StringLength(50)]
    public string InvoiceNumber { get; set; } = null!;

    [Key]
    [StringLength(50)]
    public string LedgerVoucher { get; set; } = null!;

    [Key]
    public int LineCreationSequenceNumber { get; set; }

    public int? CITOD { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedShippingDate { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DimensionNumber { get; set; }

    [StringLength(2000)]
    public string? InventorySiteId { get; set; }

    [StringLength(2000)]
    public string? InventoryWarehouseId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoicedQuantity { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineTotalChargeAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineTotalDiscountAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineTotalTaxAmount { get; set; }

    [StringLength(2000)]
    public string? OrderedInventoryStatusId { get; set; }

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
    public string? SalesId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesPrice { get; set; }

    [StringLength(2000)]
    public string? SalesProductCategoryHierarchyName { get; set; }

    [StringLength(2000)]
    public string? SalesProductCategoryName { get; set; }

    [StringLength(2000)]
    public string? SalesUnitSymbol { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineNum { get; set; }

    public long? LedgerDimension { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DiscAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DiscPercent { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? HGPercent1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? HGPercent2 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultiLnDisc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultiLnPercent { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SumLineDisc { get; set; }

    [StringLength(2000)]
    public string? ReturnReasonCodeId { get; set; }
}

public partial class CustInvoiceTrans_1Test : CustInvoiceTrans_1Base { }

public partial class CustInvoiceTrans_1 : CustInvoiceTrans_1Base { }
