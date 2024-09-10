using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "LineNumber", "TransferOrderNumber")]
[Index("dataAreaId", "TransferOrderNumber", "ShippedQuantity", Name = "idx_dataAreaIdTransferOrderNumberShippedQuantity")]
public abstract partial class TransferOrderLinesBase
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
    [Column(TypeName = "decimal(28, 16)")]
    public decimal LineNumber { get; set; }

    [Key]
    [StringLength(255)]
    public string TransferOrderNumber { get; set; } = null!;

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AllowedOverdeliveryPercentage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AllowedUnderdeliveryPercentage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AssessableValueTransactionCurrency { get; set; }

    public int? ATPBackwardDemandTimeFenceDays { get; set; }

    public int? ATPBackwardSupplyTimeFenceDays { get; set; }

    public int? ATPDelayedDemandOffsetDays { get; set; }

    public int? ATPDelayedSupplyOffsetDays { get; set; }

    public int? ATPTimeFenceDays { get; set; }

    [StringLength(2000)]
    public string? Boxes { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    public long? DefaultDimension { get; set; }

    [StringLength(2000)]
    public string? IntrastatCommodityCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? IntrastatCostAmount { get; set; }

    [StringLength(2000)]
    public string? IntrastatPortId { get; set; }

    [StringLength(2000)]
    public string? IntrastatSpecialMovementCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? IntrastatStatisticalValue { get; set; }

    [StringLength(2000)]
    public string? IntrastatStatisticsProcedureCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransactionCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransportModeCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InventCostPriceCalculated { get; set; }

    [StringLength(2000)]
    public string? InventoryUnitSymbol { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvntCostPrice { get; set; }

    public bool? IsATPIncludingPlannedOrders { get; set; }

    [StringLength(2000)]
    public string? IsAutomaticallyReserved { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    [StringLength(2000)]
    public string? ItemNumber { get; set; }

    [StringLength(2000)]
    public string? ItemSerialNumber { get; set; }

    [StringLength(2000)]
    public string? LineStatus { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MaximumRetailPrice { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? NetAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? NetAmount_IN { get; set; }

    [StringLength(2000)]
    public string? OrderedInventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? OriginCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? OriginCountyId { get; set; }

    [StringLength(2000)]
    public string? OriginStateId { get; set; }

    [StringLength(2000)]
    public string? OutboundShipmentPolicy { get; set; }

    [StringLength(2000)]
    public string? OverrideFEFODateControl { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PlanningPriority { get; set; }

    [StringLength(2000)]
    public string? PriceType { get; set; }

    [StringLength(2000)]
    public string? ProductColorId { get; set; }

    [StringLength(2000)]
    public string? ProductConfigurationId { get; set; }

    [StringLength(2000)]
    public string? ProductSizeId { get; set; }

    [StringLength(2000)]
    public string? ProductStyleId { get; set; }

    [StringLength(2000)]
    public string? ProductVersionId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyReceived { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyShipped { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReceivedCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReceivedQuantity { get; set; }

    [StringLength(2000)]
    public string? ReceivingInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? ReceivingLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? ReceivingTransitInventoryLotId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainingReceivedCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainingReceivedQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainingShippedCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainingShippedQuantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedReceiptDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedShippingDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Retention { get; set; }

    [StringLength(2000)]
    public string? ScrapInventoryLotId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ScrappedCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ScrappedQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ShippedCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ShippedQuantity { get; set; }

    [StringLength(2000)]
    public string? ShippingInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? ShippingLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? ShippingSiteId { get; set; }

    [StringLength(2000)]
    public string? ShippingTransitInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? ShippingWarehouseId { get; set; }

    [StringLength(2000)]
    public string? ShippingWarehouseLocationId { get; set; }

    [StringLength(2000)]
    public string? TaxGroup { get; set; }

    [StringLength(2000)]
    public string? TaxItemGroup { get; set; }

    public int? TOD { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TransferCatchWeightQuantity { get; set; }

    [StringLength(2000)]
    public string? TransferOrderPromisingMethod { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TransferQuantity { get; set; }

    [StringLength(2000)]
    public string? UnitId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? UnitPrice { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? UnitPrice_IN { get; set; }

    [StringLength(2000)]
    public string? VATPriceType { get; set; }

    [StringLength(2000)]
    public string? VATRetentionCode { get; set; }

    [StringLength(2000)]
    public string? WillProductReceivingCrossDockProducts { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesTaxReceipt { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesTaxShipment { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroupCodeReceipt { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroupCodeShipment { get; set; }

    [StringLength(2000)]
    public string? SalesTaxItemGroupCodeReceipt { get; set; }

    [StringLength(2000)]
    public string? SalesTaxItemGroupCodeShipment { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? ItemInventProfile { get; set; }

    [StringLength(2000)]
    public string? ItemInventProfileTo { get; set; }

    [StringLength(2000)]
    public string? BatchNumber { get; set; }

    public DateTime? ExpDate { get; set; }

    public DateTime? MfgDate { get; set; }
}

public partial class TransferOrderLinesTest : TransferOrderLinesBase {}

public partial class TransferOrderLines : TransferOrderLinesBase {}
