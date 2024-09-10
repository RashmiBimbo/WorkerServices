using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "TransferId", "VoucherId")]
public abstract partial class InventTransferJoursBase
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

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode_RU { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryDate_RU { get; set; }

    [StringLength(2000)]
    public string? DirPerson_FK1_PartyNumber { get; set; }

    [StringLength(2000)]
    public string? DirPerson_FK2_PartyNumber { get; set; }

    [StringLength(2000)]
    public string? DirPerson_FK_PartyNumber { get; set; }

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
    public string? FromContactPerson_PersonnelNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromLogisticsPostalAddress_ValidFrom { get; set; }

    [StringLength(2000)]
    public string? IntrastatDispatch { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdFrom { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdTo { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdTransit { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LadingPostalAddress_RU_ValidFrom { get; set; }

    [StringLength(2000)]
    public string? LicenseCardNum_RU { get; set; }

    [StringLength(2000)]
    public string? LicenseCardRegNum_RU { get; set; }

    [StringLength(2000)]
    public string? LicenseCardSeries_RU { get; set; }

    [StringLength(2000)]
    public string? LicenseCardType_RU { get; set; }

    [StringLength(2000)]
    public string? Location1_LocationId { get; set; }

    [StringLength(2000)]
    public string? Location2_LocationId { get; set; }

    [StringLength(2000)]
    public string? Location3_LocationId { get; set; }

    [StringLength(2000)]
    public string? Location_LocationId { get; set; }

    [StringLength(2000)]
    public string? Numbering_W { get; set; }

    [StringLength(2000)]
    public string? Num_LT { get; set; }

    [StringLength(2000)]
    public string? OffSessionId_RU { get; set; }

    public byte[]? PackedExtensions { get; set; }

    [StringLength(2000)]
    public string? PartyAccountNum_RU { get; set; }

    [StringLength(2000)]
    public string? PartyAgreementHeaderExt_RU_AgreementId { get; set; }

    [StringLength(2000)]
    public string? PriceGroupId_RU { get; set; }

    [StringLength(2000)]
    public string? Return_RU { get; set; }

    [StringLength(2000)]
    public string? Storno_RU { get; set; }

    [StringLength(2000)]
    public string? ToAddressName { get; set; }

    [StringLength(2000)]
    public string? ToContactPerson_PersonnelNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToLogisticsPostalAddress_ValidFrom { get; set; }

    [StringLength(2000)]
    public string? TrackingId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? TransferType_RU { get; set; }

    [StringLength(2000)]
    public string? TransportationType_RU { get; set; }

    [StringLength(2000)]
    public string? TransportInvoiceType_RU { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UnladingPostalAddress_RU_ValidFrom { get; set; }

    [StringLength(2000)]
    public string? UpdatedByWorker_PersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? UpdateType { get; set; }

    [StringLength(2000)]
    public string? VehicleModel_RU { get; set; }

    [StringLength(2000)]
    public string? VehiclePlateNum_RU { get; set; }

    [StringLength(2000)]
    public string? WaybillNum_RU { get; set; }
}

public partial class InventTransferJoursTest : InventTransferJoursBase {}

public partial class InventTransferJours : InventTransferJoursBase {}
