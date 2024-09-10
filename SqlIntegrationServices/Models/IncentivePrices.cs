using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("AccountNum", "dataAreaId", "FromDate", "ItemId", "RouteCode", "ToDate")]
public abstract partial class IncentivePricesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string AccountNum { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime FromDate { get; set; }

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string RouteCode { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime ToDate { get; set; }

    [StringLength(2000)]
    public string? CustomerName { get; set; }

    [StringLength(2000)]
    public string? ItemName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MonthlyDisc { get; set; }

    [StringLength(2000)]
    public string? RouteName { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class IncentivePricesTest : IncentivePricesBase {}

public partial class IncentivePrices : IncentivePricesBase {}
