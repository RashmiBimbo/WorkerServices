using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class LogisticsAddressCountryRegionBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string CountryRegion { get; set; } = null!;

    [StringLength(2000)]
    public string? AddressFormat { get; set; }

    [StringLength(2000)]
    public string? BrazilCentralBankCountryCode { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? ISOcode { get; set; }

    [StringLength(2000)]
    public string? OKSMCode_RU { get; set; }

    [StringLength(2000)]
    public string? ParentCountryRegion { get; set; }

    [StringLength(2000)]
    public string? TimeZone { get; set; }

    [StringLength(2000)]
    public string? UseZipPlus4 { get; set; }
}

public partial class LogisticsAddressCountryRegionTest : LogisticsAddressCountryRegionBase { }

public partial class LogisticsAddressCountryRegion : LogisticsAddressCountryRegionBase { }
