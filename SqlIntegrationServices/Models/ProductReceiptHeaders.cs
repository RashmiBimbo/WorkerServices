using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "RecordId")]
public abstract partial class ProductReceiptHeadersBase
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
    public long RecordId { get; set; }

    [StringLength(2000)]
    public string? AttentionInformation { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCity { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDescription { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDunsNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? DeliveryAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressLocationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? DeliveryAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressName { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStateId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreet { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? DeliveryCityInKana { get; set; }

    [StringLength(2000)]
    public string? DeliveryModeId { get; set; }

    [StringLength(2000)]
    public string? DeliveryStreetInKana { get; set; }

    [StringLength(2000)]
    public string? DeliveryTermsId { get; set; }

    [StringLength(2000)]
    public string? FormattedDeliveryAddress { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressPrivate { get; set; }

    [StringLength(2000)]
    public string? OrderVendorAccountNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProductReceiptDate { get; set; }

    [StringLength(2000)]
    public string? ProductReceiptNumber { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderNumber { get; set; }

    [StringLength(2000)]
    public string? RequesterPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class ProductReceiptHeadersTest : ProductReceiptHeadersBase { }

public partial class ProductReceiptHeaders : ProductReceiptHeadersBase { }
