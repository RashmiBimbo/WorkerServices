using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InvoiceDate", "InvoiceNumber", "LineCreationSequenceNumber")]
public abstract partial class SalesInvoiceLinesBase
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
    [Column(TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InvoiceNumber { get; set; } = null!;

    [Key]
    public int LineCreationSequenceNumber { get; set; }

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

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InvoicedQuantity { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineTotalChargeAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineTotalDiscountAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
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

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SalesPrice { get; set; }

    [StringLength(2000)]
    public string? SalesUnitSymbol { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class SalesInvoiceLinesTest : SalesInvoiceLinesBase {}

public partial class SalesInvoiceLines : SalesInvoiceLinesBase {}
