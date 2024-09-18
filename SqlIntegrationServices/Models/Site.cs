using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "SiteId")]
public abstract partial class SiteBase
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
    public string SiteId { get; set; } = null!;

    [StringLength(2000)]
    public string? DefaultInventoryStatusId { get; set; }

    [StringLength(255)]
    public string? FiscalEstablishmentId { get; set; }

    [StringLength(2000)]
    public string? FormattedPrimaryAddress { get; set; }

    [StringLength(2000)]
    public string? InventSiteDefaultDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? IsPrimaryAddressAssigned { get; set; }

    [StringLength(2000)]
    public string? IsReceivingWarehouseOverrideAllowed { get; set; }

    [StringLength(2000)]
    public string? OrderEntryDeadlineGroupId { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressCity { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressCityInKana { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressDistrictName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PrimaryAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressLocationRoles { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressLocationSalesTaxGroupCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PrimaryAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressStateId { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressStreet { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressStreetInKana { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? SiteName { get; set; }

    [StringLength(2000)]
    public string? SiteTimezone { get; set; }

    [StringLength(255)]
    public string? TaxBranchCode { get; set; }

    [StringLength(2000)]
    public string? WillMasterPlannedIntraSiteMovementsUseTransferJournals { get; set; }
}

public partial class SiteTest : SiteBase { }

public partial class Site : SiteBase { }
