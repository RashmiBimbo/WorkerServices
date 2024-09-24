using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CountryRegionId", "State")]
public abstract partial class AddressStatesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string CountryRegionId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string State { get; set; } = null!;

    [StringLength(2000)]
    public string? BrazilStateCode { get; set; }

    [StringLength(2000)]
    public string? DefaultStateForCountryRegion { get; set; }

    [StringLength(2000)]
    public string? IntrastatCode { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? StateCode_IN { get; set; }

    [StringLength(2000)]
    public string? TimeZone { get; set; }
}

public partial class AddressStatesTest : AddressStatesBase { }

public partial class AddressStates : AddressStatesBase { }
