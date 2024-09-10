using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "DGNo", "InventSiteId", "TransDate")]
public abstract partial class PoweConsumptions_1Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(55)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(55)]
    public string DGNo { get; set; } = null!;

    [Key]
    [StringLength(55)]
    public string InventSiteId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DGPowerConsKWH { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ElectPowerConsKWH { get; set; }

    [StringLength(2000)]
    public string? SolarKWH { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class PoweConsumptions_1Test : PoweConsumptions_1Base {}

public partial class PoweConsumptions_1 : PoweConsumptions_1Base {}
