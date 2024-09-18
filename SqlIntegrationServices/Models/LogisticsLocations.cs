using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class LogisticsLocationsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string LocationId { get; set; } = null!;

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? DunsNumber_FK_DunsNumber { get; set; }

    [StringLength(2000)]
    public string? IsPostalAddress { get; set; }

    [StringLength(2000)]
    public string? LogisticsLocation_FK_LocationId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    public long? RecId1 { get; set; }
}

public partial class LogisticsLocationsTest : LogisticsLocationsBase { }

public partial class LogisticsLocations : LogisticsLocationsBase { }
