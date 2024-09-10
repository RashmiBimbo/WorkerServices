using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("AccountCode", "AccountRelation", "AgreementHeaderExt_RU_AgreementId", "Currency", "dataAreaId", "FromDate", "InventDimId", "ItemCode", "ItemRelation", "QuantityAmountFrom", "relation", "UnitId")]
public abstract partial class PriceDiscTablesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string AccountCode { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string AccountRelation { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string AgreementHeaderExt_RU_AgreementId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string Currency { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime FromDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InventDimId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemCode { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemRelation { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal QuantityAmountFrom { get; set; }

    [Key]
    [StringLength(255)]
    public string relation { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string UnitId { get; set; } = null!;

    [StringLength(2000)]
    public string? Agreement { get; set; }

    [StringLength(2000)]
    public string? AllocateMarkup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Amount { get; set; }

    [StringLength(2000)]
    public string? CalendarDays { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    public int? DeliveryTime { get; set; }

    [StringLength(2000)]
    public string? DisregardLeadTime { get; set; }

    [StringLength(2000)]
    public string? FormType { get; set; }

    [StringLength(2000)]
    public string? GenericCurrency { get; set; }

    public int? InventBaileeFreeDays_RU { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Markup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MaximumRetailPrice_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MCRFixedAmountCur { get; set; }

    [StringLength(2000)]
    public string? MCRMerchandisingEventID { get; set; }

    [StringLength(2000)]
    public string? MCRPriceDiscGroupType { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? Module { get; set; }

    [StringLength(2000)]
    public string? NewGroupId { get; set; }

    [StringLength(2000)]
    public string? PDSCalculationId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Percent1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Percent2 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceUnit { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QuantityAmountTo { get; set; }

    [StringLength(2000)]
    public string? SearchAgain { get; set; }

    [StringLength(2000)]
    public string? TaxItemGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }
}

public partial class PriceDiscTablesTest : PriceDiscTablesBase {}

public partial class PriceDiscTables : PriceDiscTablesBase {}
