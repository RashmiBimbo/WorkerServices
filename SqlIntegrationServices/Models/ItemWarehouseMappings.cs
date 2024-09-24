using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventLocationId", "ItemId")]
[Index("dataAreaId", "ItemId", Name = "idx_dataAreaIdItemId")]
public abstract partial class ItemWarehouseMappingsBase
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
    public string InventLocationId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [StringLength(2000)]
    public string? Include { get; set; }

    [StringLength(2000)]
    public string? ItemName { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class ItemWarehouseMappingsTest : ItemWarehouseMappingsBase { }

public partial class ItemWarehouseMappings : ItemWarehouseMappingsBase { }
