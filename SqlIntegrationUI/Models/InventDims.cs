using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "inventDimId")]
public partial class InventDims
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string inventDimId { get; set; } = null!;

    [StringLength(2000)]
    public string? configId { get; set; }

    [StringLength(2000)]
    public string? inventBatchId { get; set; }

    [StringLength(2000)]
    public string? InventColorId { get; set; }

    [StringLength(2000)]
    public string? InventDimension1 { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InventDimension10 { get; set; }

    [StringLength(2000)]
    public string? InventDimension2 { get; set; }

    [StringLength(2000)]
    public string? InventDimension3 { get; set; }

    [StringLength(2000)]
    public string? InventDimension4 { get; set; }

    [StringLength(2000)]
    public string? InventDimension5 { get; set; }

    [StringLength(2000)]
    public string? InventDimension6 { get; set; }

    [StringLength(2000)]
    public string? InventDimension7 { get; set; }

    [StringLength(2000)]
    public string? InventDimension8 { get; set; }

    public DateTime? InventDimension9 { get; set; }

    [StringLength(2000)]
    public string? InventLocationId { get; set; }

    [StringLength(2000)]
    public string? inventSerialId { get; set; }

    [StringLength(2000)]
    public string? InventSiteId { get; set; }

    [StringLength(2000)]
    public string? InventSizeId { get; set; }

    [StringLength(2000)]
    public string? InventStatusId { get; set; }

    [StringLength(2000)]
    public string? InventStyleId { get; set; }

    [StringLength(2000)]
    public string? LicensePlateId { get; set; }

    [StringLength(2000)]
    public string? SHA1HashHex { get; set; }

    [StringLength(2000)]
    public string? wMSLocationId { get; set; }

    [StringLength(2000)]
    public string? wMSPalletId { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
