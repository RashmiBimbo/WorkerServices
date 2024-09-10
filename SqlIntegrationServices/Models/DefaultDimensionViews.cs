using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("DefaultDimension", "DisplayValue")]
public abstract partial class DefaultDimensionViewsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    public long DefaultDimension { get; set; }

    [Key]
    [StringLength(255)]
    public string DisplayValue { get; set; } = null!;

    public int? BackingEntityType { get; set; }

    public long? DimensionAttributeId { get; set; }

    public long? EntityInstance { get; set; }

    public int? KeyAttribute { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    public int? NameAttribute { get; set; }

    [StringLength(2000)]
    public string? ReportColumnName { get; set; }
}

public partial class DefaultDimensionViewsTest : DefaultDimensionViewsBase {}

public partial class DefaultDimensionViews : DefaultDimensionViewsBase {}
