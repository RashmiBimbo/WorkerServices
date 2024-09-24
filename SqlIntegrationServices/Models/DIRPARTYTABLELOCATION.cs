using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("LocationId", "PartyNumber", "ValidFrom")]
public abstract partial class DIRPARTYTABLELOCATIONBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string LocationId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string PartyNumber { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime ValidFrom { get; set; }

    [StringLength(2000)]
    public string? Address { get; set; }

    [StringLength(2000)]
    public string? Apartment_RU { get; set; }

    [StringLength(2000)]
    public string? AttentionToAddressLine { get; set; }

    [StringLength(2000)]
    public string? BuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? Building_RU { get; set; }

    [StringLength(2000)]
    public string? City { get; set; }

    [StringLength(2000)]
    public string? CityInKana { get; set; }

    [StringLength(2000)]
    public string? CountryRegionId { get; set; }

    [StringLength(2000)]
    public string? CountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? County { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? DistrictName { get; set; }

    [StringLength(2000)]
    public string? DunsNumber { get; set; }

    [StringLength(2000)]
    public string? IsLocationOwner { get; set; }

    [StringLength(2000)]
    public string? IsPrimary { get; set; }

    [StringLength(2000)]
    public string? IsPrimaryTaxRegistration { get; set; }

    [StringLength(2000)]
    public string? IsPrivate { get; set; }

    [StringLength(2000)]
    public string? IsPrivatePostalAddress { get; set; }

    [StringLength(2000)]
    public string? IsRoleBusiness { get; set; }

    [StringLength(2000)]
    public string? IsRoleDelivery { get; set; }

    [StringLength(2000)]
    public string? IsRoleHome { get; set; }

    [StringLength(2000)]
    public string? IsRoleInvoice { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Longitude { get; set; }

    [StringLength(2000)]
    public string? PostBox { get; set; }

    [StringLength(2000)]
    public string? Roles { get; set; }

    [StringLength(2000)]
    public string? State { get; set; }

    [StringLength(2000)]
    public string? Street { get; set; }

    [StringLength(2000)]
    public string? StreetInKana { get; set; }

    [StringLength(2000)]
    public string? StreetNumber { get; set; }

    [StringLength(2000)]
    public string? TimeZone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidTo { get; set; }

    [StringLength(2000)]
    public string? ZipCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AssignmentDate { get; set; }
}

public partial class DIRPARTYTABLELOCATIONTest : DIRPARTYTABLELOCATIONBase { }

public partial class DIRPARTYTABLELOCATION : DIRPARTYTABLELOCATIONBase { }
