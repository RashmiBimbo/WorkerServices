using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("AccountRelation", "dataAreaId", "FromDate", "ItemRelation", "ToDate")]
[Index("dataAreaId", "ItemRelation", "FromDate", "ToDate", Name = "idx_dataAreaIdItemRelationFromDateToDate")]
public abstract partial class SuppItemsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string AccountRelation { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime FromDate { get; set; }

    [Key]
    [StringLength(255)]
    public string ItemRelation { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime ToDate { get; set; }

    [StringLength(2000)]
    public string? AccountCode { get; set; }

    [StringLength(2000)]
    public string? InventDimId { get; set; }

    [StringLength(2000)]
    public string? ItemCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MinimumQty { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultipleQty { get; set; }

    [StringLength(2000)]
    public string? SuppItemFree { get; set; }

    [StringLength(2000)]
    public string? SuppItemId { get; set; }

    [StringLength(2000)]
    public string? SuppItemInventDimId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SuppItemQty { get; set; }

    [StringLength(2000)]
    public string? UnitId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class SuppItemsTest : SuppItemsBase { }

public partial class SuppItems : SuppItemsBase { }
