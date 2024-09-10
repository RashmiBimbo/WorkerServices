using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "VehicleCode")]
public abstract partial class VehicleCodeMastersBase
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
    public string VehicleCode { get; set; } = null!;

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? VehicleCapacity { get; set; }

    [StringLength(2000)]
    public string? VehicleRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? VehicleRouteID { get; set; }

    [StringLength(2000)]
    public string? VehicleType { get; set; }
}

public partial class VehicleCodeMastersTest : VehicleCodeMastersBase {}

public partial class VehicleCodeMasters : VehicleCodeMastersBase {}
