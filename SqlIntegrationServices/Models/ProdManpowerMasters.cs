﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "FromDate", "InventSiteId", "Shift", "ToDate")]
public abstract partial class ProdManpowerMastersBase
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

    public int? SBunPlantLab { get; set; }

    public int? SDispatchLabour { get; set; }

    public int? SDispatchsup { get; set; }

    public int? SEst { get; set; }

    public int? SHygiene { get; set; }

    public int? SPackingLabour { get; set; }

    public int? SPlantHead { get; set; }

    public int? SPlantLabour { get; set; }

    public int? SProdMgr { get; set; }

    public int? SRotiPlantLabour { get; set; }

    public int? SRotiPlantSupervisor { get; set; }

    public int? SSecurity { get; set; }

    public int? SSupervisorsBr { get; set; }

    public int? SSupervisorsBun { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CakePlant { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SBGLabour { get; set; }
}

public partial class ProdManpowerMastersTest : ProdManpowerMastersBase { }

public partial class ProdManpowerMasters : ProdManpowerMastersBase { }
