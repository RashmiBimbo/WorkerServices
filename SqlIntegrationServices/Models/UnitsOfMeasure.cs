using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class UnitsOfMeasureBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string UnitSymbol { get; set; } = null!;

    public int? DecimalPrecision { get; set; }

    [StringLength(2000)]
    public string? FixedUnitSymbolAssignment { get; set; }

    [StringLength(2000)]
    public string? IsBaseUnit { get; set; }

    [StringLength(2000)]
    public string? IsFixedUnitSymbolAssigned { get; set; }

    [StringLength(2000)]
    public string? IsSystemUnit { get; set; }

    [StringLength(2000)]
    public string? NationalCode { get; set; }

    [StringLength(2000)]
    public string? SystemOfUnits { get; set; }

    [StringLength(2000)]
    public string? UnitClass { get; set; }

    [StringLength(2000)]
    public string? UnitDescription { get; set; }
}

public partial class UnitsOfMeasureTest : UnitsOfMeasureBase {}

public partial class UnitsOfMeasure : UnitsOfMeasureBase {}
