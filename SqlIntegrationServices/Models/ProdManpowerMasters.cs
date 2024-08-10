using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("DataAreaId", "FromDate", "InventSiteId", "Shift", "ToDate")]
public abstract partial class ProdManpowerMastersBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [Column("dataAreaId")]
    [StringLength(255)]
    public string DataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime FromDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string Shift { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime ToDate { get; set; }

    public long? RuskLabour { get; set; }

    [Column("SBunPlantLab")]
    public int? SbunPlantLab { get; set; }

    [Column("SDispatchLabour")]
    public int? SdispatchLabour { get; set; }

    [Column("SDispatchsup")]
    public int? Sdispatchsup { get; set; }

    [Column("SEst")]
    public int? Sest { get; set; }

    [Column("SHygiene")]
    public int? Shygiene { get; set; }

    [Column("SPackingLabour")]
    public int? SpackingLabour { get; set; }

    [Column("SPlantHead")]
    public int? SplantHead { get; set; }

    [Column("SPlantLabour")]
    public int? SplantLabour { get; set; }

    [Column("SProdMgr")]
    public int? SprodMgr { get; set; }

    [Column("SRotiPlantLabour")]
    public int? SrotiPlantLabour { get; set; }

    [Column("SRotiPlantSupervisor")]
    public int? SrotiPlantSupervisor { get; set; }

    [Column("SSecurity")]
    public int? Ssecurity { get; set; }

    [Column("SSupervisorsBr")]
    public int? SsupervisorsBr { get; set; }

    [Column("SSupervisorsBun")]
    public int? SsupervisorsBun { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CakePlant { get; set; }

    [Column("SBGLabour", TypeName = "decimal(28, 16)")]
    public decimal? Sbglabour { get; set; }
}

public partial class ProdManpowerMastersTest : ProdManpowerMastersBase {}

public partial class ProdManpowerMasters : ProdManpowerMastersBase {}
