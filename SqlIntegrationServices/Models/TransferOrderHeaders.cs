using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "TransferOrderNumber")]
public abstract partial class TransferOrderHeadersBase
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
    public string TransferOrderNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AreLinesAutomaticallyReservedByDefault { get; set; }

    public int? ATPBackwardDemandTimeFenceDays { get; set; }

    public int? ATPBackwardSupplyTimeFenceDays { get; set; }

    public int? ATPDelayedDemandOffsetDays { get; set; }

    public int? ATPDelayedSupplyOffsetDays { get; set; }

    public int? ATPTimeFenceDays { get; set; }

    [StringLength(2000)]
    public string? CreateCFDIPackingSlip { get; set; }

    [StringLength(2000)]
    public string? DeliveryModeCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryTermsCode { get; set; }

    [StringLength(2000)]
    public string? DriverCode { get; set; }

    [StringLength(2000)]
    public string? FormattedReceivingAddress { get; set; }

    [StringLength(2000)]
    public string? FormattedShippingAddress { get; set; }

    [StringLength(2000)]
    public string? IntrastatPortId { get; set; }

    [StringLength(2000)]
    public string? IntrastatSpecialMovementCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatStatisticsProcedureCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransactionCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransportModeCode { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdFrom { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdTo { get; set; }

    [StringLength(2000)]
    public string? IRNnumber { get; set; }

    public bool? IsATPIncludingPlannedOrders { get; set; }

    [StringLength(2000)]
    public string? IsProcessed { get; set; }

    [StringLength(2000)]
    public string? IsProcess_CT { get; set; }

    [StringLength(2000)]
    public string? IsReceivingAddressPrivate { get; set; }

    [StringLength(2000)]
    public string? IsReversed { get; set; }

    [StringLength(2000)]
    public string? IsShippingAddressPrivate { get; set; }

    [StringLength(2000)]
    public string? LoaderCode { get; set; }

    [StringLength(2000)]
    public string? OverrideFEFODateControl { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressCity { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressCityInKana { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressDescription { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressDunsNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReceivingAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressLocationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReceivingAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressName { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressStateId { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressStreet { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressStreetInKana { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? ReceivingAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? ReceivingBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? ReceivingContactPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? ReceivingWarehouseId { get; set; }

    public long? RecId1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedReceiptDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedShippingDate { get; set; }

    [StringLength(2000)]
    public string? ReversalRemarks { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressCity { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressCityInKana { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressDescription { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressDunsNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ShippingAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressLocationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ShippingAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressName { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressStateId { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressStreet { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressStreetInKana { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? ShippingAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? ShippingBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierId { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierServiceGroupId { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierServiceId { get; set; }

    [StringLength(2000)]
    public string? ShippingContactPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? ShippingFreightCompany { get; set; }

    [StringLength(2000)]
    public string? ShippingFreightZone { get; set; }

    [StringLength(2000)]
    public string? ShippingWarehouseId { get; set; }

    [StringLength(2000)]
    public string? SupBread { get; set; }

    [StringLength(2000)]
    public string? SupBun { get; set; }

    [StringLength(2000)]
    public string? TransferId_CT { get; set; }

    [StringLength(2000)]
    public string? TransferOrderIsEnhancedStockTransfer { get; set; }

    [StringLength(2000)]
    public string? TransferOrderPromisingMethod { get; set; }

    [StringLength(2000)]
    public string? TransferOrderStatus { get; set; }

    [StringLength(2000)]
    public string? TransferOrderStockTransferPriceType { get; set; }

    [StringLength(2000)]
    public string? TransitWarehouseId { get; set; }

    [StringLength(2000)]
    public string? TransportationModeId { get; set; }

    [StringLength(2000)]
    public string? VehicleCode { get; set; }

    [StringLength(2000)]
    public string? VehicleTag { get; set; }

    [StringLength(2000)]
    public string? VendAccount { get; set; }

    [StringLength(2000)]
    public string? Vendor_Reference { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? AcknowledgementNum { get; set; }
}

public partial class TransferOrderHeadersTest : TransferOrderHeadersBase {}

public partial class TransferOrderHeaders : TransferOrderHeadersBase {}
