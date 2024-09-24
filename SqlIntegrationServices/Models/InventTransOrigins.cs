using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventTransId", "ItemId", "ReferenceId")]
public abstract partial class InventTransOriginsBase
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
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ReferenceId { get; set; } = null!;

    [StringLength(2000)]
    public string? IsExcludedFromInventoryValue { get; set; }

    [StringLength(2000)]
    public string? ItemInventDimId { get; set; }

    public long? Party { get; set; }

    public long? RecId1 { get; set; }

    [StringLength(2000)]
    public string? ReferenceCategory { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class InventTransOriginsTest : InventTransOriginsBase { }

public partial class InventTransOrigins : InventTransOriginsBase { }
