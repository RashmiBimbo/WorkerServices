using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[Keyless]
public abstract partial class OvenPngProdTables_1Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [StringLength(255)]
    public string InventSiteId { get; set; } = null!;

    [StringLength(255)]
    public string OvenType { get; set; } = null!;

    public DateTime TransDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ActualChangeoverMinute { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ChangeOverNoBrown { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ChangeOverNoWhite { get; set; }

    [StringLength(2000)]
    public string? ItemGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MechDTMinute { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? OperationDowntimeMinute { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProdLossTimeMinute { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SchdDTMinute { get; set; }

    public int? Shift { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdChangeoverMinuteBrown { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdChangeoverMinuteWhite { get; set; }
}

public partial class OvenPngProdTables_1Test : OvenPngProdTables_1Base { }

public partial class OvenPngProdTables_1 : OvenPngProdTables_1Base { }
