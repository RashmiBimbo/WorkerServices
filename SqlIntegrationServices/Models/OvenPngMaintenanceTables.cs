using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventSiteId", "OvenType", "TransDate")]
public abstract partial class OvenPngMaintenanceTablesBase
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
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string OvenType { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? BoilerRunningHour { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DieselFuelConsLt { get; set; }

    [StringLength(2000)]
    public string? ItemGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PLCHMRun { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PNGFuelConsSCM { get; set; }

    [StringLength(2000)]
    public string? ProdZone { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Rate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LDOLTR { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LPGSCM { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class OvenPngMaintenanceTablesTest : OvenPngMaintenanceTablesBase {}

public partial class OvenPngMaintenanceTables : OvenPngMaintenanceTablesBase {}
