using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class ProductsV2Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string ProductNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AreIdenticalConfigurationsAllowed { get; set; }

    [StringLength(255)]
    public string? EngChgProductCategoryDetailsName { get; set; }

    [StringLength(2000)]
    public string? EngChgProductOwnerId { get; set; }

    [StringLength(255)]
    public string? EngChgProductReadinessPolicyName { get; set; }

    [StringLength(255)]
    public string? EngChgProductReleasePolicyName { get; set; }

    [StringLength(2000)]
    public string? HarmonizedSystemCode { get; set; }

    [StringLength(2000)]
    public string? IsAutomaticVariantGenerationEnabled { get; set; }

    [StringLength(2000)]
    public string? IsCatchWeightProduct { get; set; }

    [StringLength(2000)]
    public string? IsProductKit { get; set; }

    [StringLength(2000)]
    public string? IsProductVariantUnitConversionEnabled { get; set; }

    [StringLength(2000)]
    public string? NMFCCode { get; set; }

    [StringLength(255)]
    public string? ProductColorGroupId { get; set; }

    [StringLength(2000)]
    public string? ProductDescription { get; set; }

    [StringLength(2000)]
    public string? ProductDimensionGroupName { get; set; }

    [StringLength(2000)]
    public string? ProductName { get; set; }

    [StringLength(2000)]
    public string? ProductSearchName { get; set; }

    [StringLength(255)]
    public string? ProductSizeGroupId { get; set; }

    [StringLength(255)]
    public string? ProductStyleGroupId { get; set; }

    [StringLength(2000)]
    public string? ProductSubType { get; set; }

    [StringLength(2000)]
    public string? ProductType { get; set; }

    [StringLength(2000)]
    public string? ProductVariantNameNomenclatureName { get; set; }

    [StringLength(2000)]
    public string? ProductVariantNumberNomenclatureName { get; set; }

    public long? RecId1 { get; set; }

    [StringLength(2000)]
    public string? RetailProductCategoryName { get; set; }

    [StringLength(2000)]
    public string? ServiceType { get; set; }

    [StringLength(2000)]
    public string? STCCCode { get; set; }

    [StringLength(2000)]
    public string? StorageDimensionGroupName { get; set; }

    [StringLength(2000)]
    public string? TrackingDimensionGroupName { get; set; }

    [StringLength(2000)]
    public string? VariantConfigurationTechnology { get; set; }

    public int? WarrantyDurationTime { get; set; }

    [StringLength(2000)]
    public string? WarrantyDurationTimeUnit { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? InventLocationId { get; set; }

    [StringLength(2000)]
    public string? IsExportedtoSFTP { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? LeadTime { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? MasterQty { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? Qty { get; set; }

    [StringLength(2000)]
    public string? SiteId { get; set; }

    [StringLength(2000)]
    public string? Unit { get; set; }

    [StringLength(2000)]
    public string? VendAccount { get; set; }
}

public partial class ProductsV2Test : ProductsV2Base {}

public partial class ProductsV2 : ProductsV2Base {}
