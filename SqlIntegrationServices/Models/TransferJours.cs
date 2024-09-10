using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "TransferId", "VoucherId")]
public abstract partial class TransferJoursBase
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
    public string TransferId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string VoucherId { get; set; } = null!;

    [StringLength(2000)]
    public string? AutoReceiveQty { get; set; }

    [StringLength(2000)]
    public string? BillOfLadingId_RU { get; set; }

    [StringLength(2000)]
    public string? CargoDescription_RU { get; set; }

    [StringLength(2000)]
    public string? CargoPacking_RU { get; set; }

    [StringLength(2000)]
    public string? CarrierCode_RU { get; set; }

    [StringLength(2000)]
    public string? CarrierType_RU { get; set; }

    public DateTime? CreatedTime { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode_RU { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryDate_RU { get; set; }

    [StringLength(2000)]
    public string? DlvModeId { get; set; }

    [StringLength(2000)]
    public string? DlvTermId { get; set; }

    [StringLength(2000)]
    public string? DriverContact_RU { get; set; }

    [StringLength(2000)]
    public string? DriverName_RU { get; set; }

    [StringLength(2000)]
    public string? DrivingLicenseNum_RU { get; set; }

    [StringLength(2000)]
    public string? FreightSlipType { get; set; }

    [StringLength(2000)]
    public string? FreightZoneId { get; set; }

    [StringLength(2000)]
    public string? FromAddressName { get; set; }

    [StringLength(2000)]
    public string? IntrastatDispatch { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdFrom { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdTo { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdTransit { get; set; }

    [StringLength(2000)]
    public string? IsProcessed { get; set; }

    public int? IsProcessedCT { get; set; }

    [StringLength(2000)]
    public string? IsReversed { get; set; }

    [StringLength(2000)]
    public string? LicenseCardNum_RU { get; set; }

    [StringLength(2000)]
    public string? LicenseCardRegNum_RU { get; set; }

    [StringLength(2000)]
    public string? LicenseCardSeries_RU { get; set; }

    [StringLength(2000)]
    public string? LicenseCardType_RU { get; set; }

    [StringLength(2000)]
    public string? Numbering_W { get; set; }

    [StringLength(2000)]
    public string? Num_LT { get; set; }

    [StringLength(2000)]
    public string? OffSessionId_RU { get; set; }

    [StringLength(2000)]
    public string? PartyAccountNum_RU { get; set; }

    [StringLength(2000)]
    public string? PriceGroupId_RU { get; set; }

    public long? RecId1 { get; set; }

    [StringLength(2000)]
    public string? Return_RU { get; set; }

    [StringLength(2000)]
    public string? ReversedTransferId { get; set; }

    [StringLength(2000)]
    public string? Storno_RU { get; set; }

    [StringLength(2000)]
    public string? ToAddressName { get; set; }

    [StringLength(2000)]
    public string? TrackingId { get; set; }

    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? TransferType_IN { get; set; }

    [StringLength(2000)]
    public string? TransferType_RU { get; set; }

    [StringLength(2000)]
    public string? TransportationType_RU { get; set; }

    [StringLength(2000)]
    public string? TransportInvoiceType_RU { get; set; }

    [StringLength(2000)]
    public string? UpdateType { get; set; }

    [StringLength(2000)]
    public string? VehicleModel_RU { get; set; }

    [StringLength(2000)]
    public string? VehiclePlateNum_RU { get; set; }

    [StringLength(2000)]
    public string? WaybillNum_RU { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    public DateTime? CreatedDateTimeCopy1 { get; set; }

    [StringLength(2000)]
    public string? CanceledShipment { get; set; }

    public long? CanceledShipmentJournalRecId { get; set; }

    public long? RecIdCopy1 { get; set; }
}

public partial class TransferJoursTest : TransferJoursBase {}

public partial class TransferJours : TransferJoursBase {}
