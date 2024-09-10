﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventTransId", "TaxCode", "TransDate")]
public abstract partial class TaxTranssBase
{
    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventTransId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string TaxCode { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? EmptyTaxBaseForOutgoingTax_W { get; set; }

    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? EUROTriangulation { get; set; }

    [StringLength(2000)]
    public string? ExemptCode { get; set; }

    [StringLength(2000)]
    public string? ExemptTax { get; set; }

    [StringLength(2000)]
    public string? GSTHSTTaxType_CA { get; set; }

    public int? HeadingTableId { get; set; }

    [StringLength(2000)]
    public string? IntracomVAT { get; set; }

    [StringLength(2000)]
    public string? InvoiceId { get; set; }

    [StringLength(2000)]
    public string? JournalNum { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public long? Partition1 { get; set; }

    [StringLength(2000)]
    public string? PostponeVAT { get; set; }

    [StringLength(2000)]
    public string? PrintCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RealizedDate { get; set; }

    public long? RecId1 { get; set; }

    public int? RecVersion1 { get; set; }

    [StringLength(2000)]
    public string? ReverseCharge_W { get; set; }

    [StringLength(2000)]
    public string? ReverseChargeApplies_UK { get; set; }

    [StringLength(2000)]
    public string? Source { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SourceBaseAmountCur { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SourceBaseAmountCurRegulated { get; set; }

    [StringLength(2000)]
    public string? SourceCurrencyCode { get; set; }

    public long? SourceDocumentLine { get; set; }

    public long? SourceRecId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SourceRegulateAmountCur { get; set; }

    public int? SourceTableId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SourceTaxAmountCur { get; set; }

    [StringLength(2000)]
    public string? statementId { get; set; }

    [StringLength(2000)]
    public string? TaxAccountType { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxAmountCur { get; set; }

    [StringLength(2000)]
    public string? TaxAutogenerated { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxBaseAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxBaseAmountCur { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxBaseQty { get; set; }

    public long? TaxBook { get; set; }

    public long? TaxBookSection { get; set; }

    [StringLength(2000)]
    public string? TaxDirection { get; set; }

    [StringLength(2000)]
    public string? TaxGroup { get; set; }

    public long? TaxID { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxInCostPrice { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxInCostPriceCur { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxInCostPriceMST { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxInCostPriceRegulated { get; set; }

    [StringLength(2000)]
    public string? TaxItemGroup { get; set; }

    [StringLength(2000)]
    public string? TaxJurisdictionCode { get; set; }

    [StringLength(2000)]
    public string? TaxObligationCompany { get; set; }

    [StringLength(2000)]
    public string? TaxOrigin { get; set; }

    [StringLength(2000)]
    public string? TaxPeriod { get; set; }

    [StringLength(2000)]
    public string? TaxPrintDetail { get; set; }

    public int? TaxRepCounter { get; set; }

    public long? TaxTransRefRecId { get; set; }

    [StringLength(2000)]
    public string? TaxType_MX { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TaxValue { get; set; }

    [StringLength(2000)]
    public string? UnrealizedTax { get; set; }

    [StringLength(2000)]
    public string? UnrealizedTaxExt { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }
}

public partial class TaxTranssTest : TaxTranssBase {}

public partial class TaxTranss : TaxTranssBase {}