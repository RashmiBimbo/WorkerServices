using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CPF", "CRC")]
public abstract partial class AccountantsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string CPF { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string CRC { get; set; } = null!;

    [StringLength(2000)]
    public string? AccountantName { get; set; }

    [StringLength(2000)]
    public string? AddressBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? AddressCityName { get; set; }

    [StringLength(2000)]
    public string? AddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? AddressCounty { get; set; }

    [StringLength(2000)]
    public string? AddressDescription { get; set; }

    [StringLength(2000)]
    public string? AddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? AddressIsPrivate { get; set; }

    [StringLength(2000)]
    public string? AddressState { get; set; }

    [StringLength(2000)]
    public string? AddressStreet { get; set; }

    [StringLength(2000)]
    public string? AddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? AddressZipCode { get; set; }

    [StringLength(2000)]
    public string? AddressZipCodeName { get; set; }

    [StringLength(2000)]
    public string? CNPJ { get; set; }

    [StringLength(2000)]
    public string? CRCCountryRegionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CRCExpirationDate { get; set; }

    [StringLength(2000)]
    public string? CRCIssuerState { get; set; }

    [StringLength(2000)]
    public string? EmailCountryRegionCode { get; set; }

    [StringLength(2000)]
    public string? EmailDescription { get; set; }

    [StringLength(2000)]
    public string? EmailIsInstantMessage { get; set; }

    [StringLength(2000)]
    public string? EmailIsPrivate { get; set; }

    [StringLength(2000)]
    public string? EmailLocator { get; set; }

    [StringLength(2000)]
    public string? EmailLocatorExtension { get; set; }

    public long? EmailPrivateForParty { get; set; }

    [StringLength(2000)]
    public string? PhoneCountryRegionCode { get; set; }

    [StringLength(2000)]
    public string? PhoneDescription { get; set; }

    [StringLength(2000)]
    public string? PhoneIsInstantMessage { get; set; }

    [StringLength(2000)]
    public string? PhoneIsMobilePhone { get; set; }

    [StringLength(2000)]
    public string? PhoneIsPrivate { get; set; }

    [StringLength(2000)]
    public string? PhoneLocator { get; set; }

    [StringLength(2000)]
    public string? PhoneLocatorExtension { get; set; }

    public long? PhonePrivateForParty { get; set; }
}

public partial class AccountantsTest : AccountantsBase { }

public partial class Accountants : AccountantsBase { }
