using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[Keyless]
public abstract partial class OvenPngMaintEntitiesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [StringLength(255)]
    public string OvenType { get; set; } = null!;

    public DateTime TransDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? BoilerRunningHour { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DieselFuelConsLt { get; set; }

    [StringLength(2000)]
    public string? ItemGroupId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTime1 { get; set; }

    public long? Partition1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PLCHMRun { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PNGFuelConsSCM { get; set; }

    [StringLength(2000)]
    public string? ProdZone { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Rate { get; set; }

    public long? RecId1 { get; set; }

    public int? RecVersion1 { get; set; }
}

public partial class OvenPngMaintEntitiesTest : OvenPngMaintEntitiesBase { }

public partial class OvenPngMaintEntities : OvenPngMaintEntitiesBase { }
