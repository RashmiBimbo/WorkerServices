using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("FromUnitSymbol", "ToUnitSymbol")]
public abstract partial class UnitOfMeasureConversionsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string FromUnitSymbol { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ToUnitSymbol { get; set; } = null!;

    public int? Denominator { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Factor { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InnerOffset { get; set; }

    public int? Numerator { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OuterOffset { get; set; }

    [StringLength(2000)]
    public string? Rounding { get; set; }
}

public partial class UnitOfMeasureConversionsTest : UnitOfMeasureConversionsBase { }

public partial class UnitOfMeasureConversions : UnitOfMeasureConversionsBase { }
