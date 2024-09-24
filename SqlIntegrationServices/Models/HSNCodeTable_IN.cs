using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("Chapter", "CountryExtension", "dataAreaId", "Heading", "StatisticalSuffix", "Subheading")]
public abstract partial class HSNCodeTable_INBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string Chapter { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string CountryExtension { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string Heading { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string StatisticalSuffix { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string Subheading { get; set; } = null!;

    [StringLength(2000)]
    public string? Code { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }
}

public partial class HSNCodeTable_INTest : HSNCodeTable_INBase { }

public partial class HSNCodeTable_IN : HSNCodeTable_INBase { }
