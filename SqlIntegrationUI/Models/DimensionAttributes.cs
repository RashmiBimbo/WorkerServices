using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

public partial class DimensionAttributes
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string DimensionName { get; set; } = null!;

    public long? BalancingDimension_PSN { get; set; }

    [StringLength(2000)]
    public string? CopyValuesOnCreate { get; set; }

    [StringLength(2000)]
    public string? DimensionValueMask { get; set; }

    [StringLength(2000)]
    public string? GiveDerivedDimensionsPrecedence { get; set; }

    [StringLength(2000)]
    public string? IsBalancing_PSN { get; set; }

    [StringLength(2000)]
    public string? ReportColumnName { get; set; }

    [StringLength(2000)]
    public string? UseValuesFrom { get; set; }
}
