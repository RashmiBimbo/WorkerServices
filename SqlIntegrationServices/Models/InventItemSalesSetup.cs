using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventDimId", "ItemId")]
public abstract partial class InventItemSalesSetupBase
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
    public string InventDimId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    public int? ATPApplyDemandTimeFence { get; set; }

    public int? ATPApplySupplyTimeFence { get; set; }

    public int? ATPBackwardDemandTimeFence { get; set; }

    public int? ATPBackwardSupplyTimeFence { get; set; }

    public bool? ATPInclPlannedOrders { get; set; }

    public int? ATPTimeFence { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? DeliveryDateControlType { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? HighestQty { get; set; }

    [StringLength(2000)]
    public string? InventDimIdDefault { get; set; }

    public int? LeadTime { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LowestQty { get; set; }

    [StringLength(2000)]
    public string? MandatoryInventLocation { get; set; }

    [StringLength(2000)]
    public string? MandatoryInventSite { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MultipleQty { get; set; }

    [StringLength(2000)]
    public string? Override { get; set; }

    [StringLength(2000)]
    public string? OverrideDefaultStorageDimensions { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesLeadTime { get; set; }

    public long? Sequence { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? StandardQty { get; set; }

    [StringLength(2000)]
    public string? Stopped { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class InventItemSalesSetupTest : InventItemSalesSetupBase {}

public partial class InventItemSalesSetup : InventItemSalesSetupBase {}
