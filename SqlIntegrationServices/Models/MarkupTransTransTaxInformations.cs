using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "LineNum", "TransRecId", "TransTableId")]
public abstract partial class MarkupTransTransTaxInformationsBase
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
    public decimal LineNum { get; set; }

    [Key]
    public long TransRecId { get; set; }

    [Key]
    public int TransTableId { get; set; }

    [StringLength(2000)]
    public string? BankLocation { get; set; }

    [StringLength(2000)]
    public string? BankTaxInformation { get; set; }

    [StringLength(2000)]
    public string? CompanyLocation { get; set; }

    [StringLength(2000)]
    public string? CompanyTaxInformation { get; set; }

    [StringLength(2000)]
    public string? CSTSchedule { get; set; }

    [StringLength(2000)]
    public string? CustomerLocation { get; set; }

    [StringLength(2000)]
    public string? CustomerTaxInformation { get; set; }

    [StringLength(2000)]
    public string? CustomsIECRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? CustomsTariffCode { get; set; }

    [StringLength(2000)]
    public string? CustomsTariffDirection { get; set; }

    [StringLength(2000)]
    public string? Direction { get; set; }

    [StringLength(2000)]
    public string? ExciseCENVATCreditAvailed { get; set; }

    [StringLength(2000)]
    public string? ExciseConsignment { get; set; }

    [StringLength(2000)]
    public string? ExciseDirectSettlement { get; set; }

    [StringLength(2000)]
    public string? ExciseDisposalType { get; set; }

    [StringLength(2000)]
    public string? ExciseDSA { get; set; }

    [StringLength(2000)]
    public string? ExciseECCRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? ExciseIsScrap { get; set; }

    [StringLength(2000)]
    public string? ExciseRecordType { get; set; }

    [StringLength(2000)]
    public string? ExciseTariffCodes { get; set; }

    [StringLength(2000)]
    public string? ExciseType { get; set; }

    [StringLength(2000)]
    public string? Exempt { get; set; }

    [StringLength(2000)]
    public string? GSTINRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? HSNCode { get; set; }

    [StringLength(2000)]
    public string? InclTax { get; set; }

    [StringLength(2000)]
    public string? ITCCategory { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? NonBusinessUsagePercentage { get; set; }

    [StringLength(2000)]
    public string? NonGST { get; set; }

    [StringLength(2000)]
    public string? SalesTaxFormTypes { get; set; }

    [StringLength(2000)]
    public string? SalesTaxRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? ServiceAccountingCode { get; set; }

    [StringLength(2000)]
    public string? ServiceCategory { get; set; }

    [StringLength(2000)]
    public string? ServiceCode { get; set; }

    [StringLength(2000)]
    public string? ServiceTaxConsignmentNoteNum { get; set; }

    [StringLength(2000)]
    public string? ServiceTaxGTAServiceCategory { get; set; }

    [StringLength(2000)]
    public string? ServiceTaxIsRecoverable { get; set; }

    [StringLength(2000)]
    public string? ServiceTaxRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? TANRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? TaxID { get; set; }

    [StringLength(2000)]
    public string? TaxInventVATItemId { get; set; }

    [StringLength(2000)]
    public string? TaxRateType { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdAcknowledgementNumber { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdCountryRegionToRemittance { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdNatureOfAssessee { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdNatureOfRemittance { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdSoftwareDeclReceived { get; set; }

    [StringLength(2000)]
    public string? Type { get; set; }

    [StringLength(2000)]
    public string? VATCommodityCode { get; set; }

    [StringLength(2000)]
    public string? VATGoodsType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VATNonRecoverablePercent { get; set; }

    [StringLength(2000)]
    public string? VATSchedule { get; set; }

    [StringLength(2000)]
    public string? VATTINRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? VendorLocation { get; set; }

    [StringLength(2000)]
    public string? VendorTaxInformation { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CalculatedAmount { get; set; }

    [StringLength(2000)]
    public string? DocumentStatus { get; set; }

    [StringLength(2000)]
    public string? MarkupCode { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? ModuleType { get; set; }

    public long? OrigRecId { get; set; }

    public int? OrigTableId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Posted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Value { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }
}

public partial class MarkupTransTransTaxInformationsTest : MarkupTransTransTaxInformationsBase {}

public partial class MarkupTransTransTaxInformations : MarkupTransTransTaxInformationsBase {}
