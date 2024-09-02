using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "InventSiteId", "Shift", "TransDate")]
public partial class ProdManpowerTranss
{
    [StringLength(2000)]
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
    public string Shift { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    public int? BunPlantLab { get; set; }

    public int? DispatchLabour { get; set; }

    public int? DispatchSup { get; set; }

    public int? Establishment { get; set; }

    public int? Hygiene { get; set; }

    public int? PackingLabour { get; set; }

    public int? PlantHead { get; set; }

    public int? PlantLabour { get; set; }

    public int? ProdMgr { get; set; }

    public int? RotiPlantLabour { get; set; }

    public int? RotiPlantSupervisor { get; set; }

    public long? RuskLabour { get; set; }

    public int? Security { get; set; }

    public int? SupervisorBun { get; set; }

    public int? SupervisorsBr { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CakePlant { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SBGLabour { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
