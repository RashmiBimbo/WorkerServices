using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("BOMId", "dataAreaId", "FromQuantity", "IsActive", "ManufacturedItemNumber", "ProductColorId", "ProductConfigurationId", "ProductionSiteId", "ProductSizeId", "ProductStyleId", "ValidFromDate")]
public abstract partial class BillOfMaterialsVersionsV2Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string BOMId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal FromQuantity { get; set; }

    [Key]
    [StringLength(255)]
    public string IsActive { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ManufacturedItemNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductColorId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductConfigurationId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductionSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductSizeId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductStyleId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime ValidFromDate { get; set; }

    [StringLength(2000)]
    public string? ApproverPersonnelNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CatchWeightSize { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FromCatchWeightQuantity { get; set; }

    [StringLength(2000)]
    public string? IsApproved { get; set; }

    [StringLength(2000)]
    public string? IsSelectedForDesigner { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidToDate { get; set; }

    [StringLength(2000)]
    public string? VersionName { get; set; }
}

public partial class BillOfMaterialsVersionsV2Test : BillOfMaterialsVersionsV2Base {}

public partial class BillOfMaterialsVersionsV2 : BillOfMaterialsVersionsV2Base {}
