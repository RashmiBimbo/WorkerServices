using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventSiteId", "OvenType", "TransDate")]
public abstract partial class OvenPngProdTables_2Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string OvenType { get; set; } = null!;

    [Key]
    public DateTime TransDate { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? ActualChangeoverMinute { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? ChangeOverNoBrown { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? ChangeOverNoWhite { get; set; }

    [StringLength(2000)]
    public string? ItemGroupId { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? MechDTMinute { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? OperationDowntimeMinute { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? ProdLossTimeMinute { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? SchdDTMinute { get; set; }

    public int? Shift { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? StdChangeoverMinuteBrown { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? StdChangeoverMinuteWhite { get; set; }
}

public partial class OvenPngProdTables_2Test : OvenPngProdTables_2Base {}

public partial class OvenPngProdTables_2 : OvenPngProdTables_2Base {}
