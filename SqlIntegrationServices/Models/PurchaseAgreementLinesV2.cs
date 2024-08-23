using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "LineNumber", "PurchaseAgreementId")]
public abstract partial class PurchaseAgreementLinesV2Base
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
    public string PurchaseAgreementId { get; set; } = null!;

    [StringLength(2000)]
    public string? AgreementVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? CommitmentType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CommittedAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CommittedCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CommittedQuantity { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EffectiveDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpirationDate { get; set; }

    [StringLength(2000)]
    public string? InventoryProfileId { get; set; }

    [StringLength(2000)]
    public string? InvoiceVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? IsCommitmentMaximumEnforced { get; set; }

    [StringLength(2000)]
    public string? IsPriceAndDiscountFixed { get; set; }

    [StringLength(2000)]
    public string? ItemNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineDiscountAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineDiscountPercentage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MaximumReleaseAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MinimumReleaseAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceQuantity { get; set; }

    [StringLength(2000)]
    public string? ProcurementProductCategoryName { get; set; }

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

    [StringLength(2000)]
    public string? ProjectActivityNumber { get; set; }

    [StringLength(2000)]
    public string? ProjectCategoryId { get; set; }

    [StringLength(2000)]
    public string? ProjectId { get; set; }

    [StringLength(2000)]
    public string? PurchaseAgreementLegalEntityId { get; set; }

    [StringLength(2000)]
    public string? ReceivingSiteId { get; set; }

    [StringLength(2000)]
    public string? ReceivingWarehouseId { get; set; }

    [StringLength(2000)]
    public string? UnitSymbol { get; set; }

    public long? RecId1 { get; set; }

    [StringLength(2000)]
    public string? ShipCalendarId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class PurchaseAgreementLinesV2Test : PurchaseAgreementLinesV2Base {}

public partial class PurchaseAgreementLinesV2 : PurchaseAgreementLinesV2Base {}
