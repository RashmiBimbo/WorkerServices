using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "FromDate", "InventSiteId", "ItemId", "OvenType", "ToDate")]
public abstract partial class ProdOvenTypesBase
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
    public DateTime FromDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string OvenType { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime ToDate { get; set; }

    public int? ProdStdCapacity { get; set; }
}

public partial class ProdOvenTypesTest : ProdOvenTypesBase { }

public partial class ProdOvenTypes : ProdOvenTypesBase { }
