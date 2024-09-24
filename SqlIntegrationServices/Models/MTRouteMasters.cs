using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "RouteId")]
[Index("RouteId", Name = "idx_Route")]
public abstract partial class MTRouteMastersBase
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
    public string RouteId { get; set; } = null!;

    [StringLength(2000)]
    public string? Active { get; set; }

    public int? Capacity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CoverageDistance { get; set; }

    [StringLength(2000)]
    public string? CoverageTime { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? FromCity { get; set; }

    [StringLength(2000)]
    public string? FromDP { get; set; }

    [StringLength(2000)]
    public string? InventSiteId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    public int? Priority { get; set; }

    [StringLength(2000)]
    public string? ToCity { get; set; }

    [StringLength(2000)]
    public string? ToDP { get; set; }

    [StringLength(2000)]
    public string? WarehouseId { get; set; }

    public int? RouteTiming { get; set; }
}

public partial class MTRouteMastersTest : MTRouteMastersBase { }

public partial class MTRouteMasters : MTRouteMastersBase { }
