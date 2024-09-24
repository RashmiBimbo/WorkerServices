using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventSiteId", "ItemId")]
[Index("InventSiteId", "ItemId", Name = "IDX_InventSiteIdItemId")]
[Index("ItemId", "dataAreaId", "InventSiteId", Name = "IX_ItemCrateMappings_ItemId_dataAreaId_InventSiteId")]
[Index("ItemId", Name = "idx_ItemId")]
public abstract partial class ItemCrateMappingsBase
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
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [StringLength(2000)]
    public string? BasketType { get; set; }

    public int? Capacity { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? ItemName { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? PackingType { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CrateBI { get; set; }
}

public partial class ItemCrateMappingsTest : ItemCrateMappingsBase { }

public partial class ItemCrateMappings : ItemCrateMappingsBase { }
