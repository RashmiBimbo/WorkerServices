using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "VehicleTag")]
public abstract partial class VehicleTagMasterBase
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
    public string VehicleTag { get; set; } = null!;

    [StringLength(2000)]
    public string? DepotID { get; set; }

    public int? TimeOfDepart { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VehicleCapacity { get; set; }

    [StringLength(2000)]
    public string? VehicleTagID { get; set; }

    [StringLength(2000)]
    public string? VehicleTagName { get; set; }
}

public partial class VehicleTagMasterTest : VehicleTagMasterBase { }

public partial class VehicleTagMaster : VehicleTagMasterBase { }
