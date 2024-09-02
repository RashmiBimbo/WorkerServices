using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("Chapter", "CountryExtension", "dataAreaId", "Heading", "StatisticalSuffix", "Subheading")]
public partial class HSNCodes
{
    [StringLength(2000)]
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

    public long? RecIdCopy1 { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
