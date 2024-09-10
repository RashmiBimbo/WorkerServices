using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("Location_LocationId", "ValidFrom")]
public abstract partial class LogisticsPostalAddresssBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string Location_LocationId { get; set; } = null!;

    [Key]
    public DateTime ValidFrom { get; set; }

    [StringLength(2000)]
    public string? Address { get; set; }

    [StringLength(2000)]
    public string? Apartment_RU { get; set; }

    [StringLength(2000)]
    public string? BuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? Building_RU { get; set; }

    [StringLength(2000)]
    public string? City { get; set; }

    [StringLength(2000)]
    public string? CityKana_JP { get; set; }

    [StringLength(2000)]
    public string? City_FK1_Name { get; set; }

    [StringLength(2000)]
    public string? City_FK2_Name { get; set; }

    [StringLength(2000)]
    public string? City_FK_Name { get; set; }

    [StringLength(2000)]
    public string? City_Name { get; set; }

    [StringLength(2000)]
    public string? CountryRegionId { get; set; }

    [StringLength(2000)]
    public string? County { get; set; }

    [StringLength(2000)]
    public string? DirPartyTable_PrivateForParty_PartyNumber { get; set; }

    [StringLength(2000)]
    public string? DistrictName { get; set; }

    [StringLength(2000)]
    public string? District_FK1_Name { get; set; }

    [StringLength(2000)]
    public string? District_FK2_Name { get; set; }

    [StringLength(2000)]
    public string? District_FK_Name { get; set; }

    [StringLength(2000)]
    public string? District_Name { get; set; }

    [StringLength(2000)]
    public string? House_RU_CountryRegion { get; set; }

    [StringLength(2000)]
    public string? House_RU_County { get; set; }

    [StringLength(2000)]
    public string? House_RU_Name { get; set; }

    [StringLength(2000)]
    public string? House_RU_State { get; set; }

    [StringLength(2000)]
    public string? IsPrivate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Longitude { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? PostBox { get; set; }

    [StringLength(2000)]
    public string? State { get; set; }

    [StringLength(2000)]
    public string? Street { get; set; }

    [StringLength(2000)]
    public string? StreetKana_JP { get; set; }

    [StringLength(2000)]
    public string? StreetNumber { get; set; }

    [StringLength(2000)]
    public string? Street_FK_CountryRegion { get; set; }

    [StringLength(2000)]
    public string? Street_FK_County { get; set; }

    [StringLength(2000)]
    public string? Street_FK_Description { get; set; }

    [StringLength(2000)]
    public string? Street_FK_Name { get; set; }

    [StringLength(2000)]
    public string? Street_FK_State { get; set; }

    [StringLength(2000)]
    public string? Street_RU_CountryRegion { get; set; }

    [StringLength(2000)]
    public string? Street_RU_County { get; set; }

    [StringLength(2000)]
    public string? Street_RU_Description { get; set; }

    [StringLength(2000)]
    public string? Street_RU_Name { get; set; }

    [StringLength(2000)]
    public string? Street_RU_State { get; set; }

    [StringLength(2000)]
    public string? TimeZone { get; set; }

    public DateTime? ValidTo { get; set; }

    [StringLength(2000)]
    public string? ZipCode { get; set; }

    [StringLength(2000)]
    public string? ZipCode_ZipCode { get; set; }
}

public partial class LogisticsPostalAddresssTest : LogisticsPostalAddresssBase {}

public partial class LogisticsPostalAddresss : LogisticsPostalAddresssBase {}
