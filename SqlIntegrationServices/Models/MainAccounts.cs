using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("ChartOfAccounts", "MainAccountId")]
public abstract partial class MainAccountsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string ChartOfAccounts { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string MainAccountId { get; set; } = null!;

    [StringLength(2000)]
    public string? AccountCategoryDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActiveFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActiveTo { get; set; }

    [StringLength(2000)]
    public string? AdjustmentMethod { get; set; }

    [StringLength(2000)]
    public string? BalanceControl { get; set; }

    public long? ChartOfAccountsRecId { get; set; }

    [StringLength(2000)]
    public string? Closing { get; set; }

    [StringLength(2000)]
    public string? DebitCreditDefault { get; set; }

    [StringLength(2000)]
    public string? DebitCreditRequirement { get; set; }

    [StringLength(2000)]
    public string? DefaultConsolidationAccount { get; set; }

    [StringLength(255)]
    public string? DefaultCurrency { get; set; }

    [StringLength(2000)]
    public string? DoNotAllowManualEntry { get; set; }

    [StringLength(255)]
    public string? ExchangeAdjustmentRateType { get; set; }

    [StringLength(2000)]
    public string? FinancialReportingCurrencyTranslationType { get; set; }

    [StringLength(2000)]
    public string? FinancialReportingExchangeRateType { get; set; }

    [StringLength(2000)]
    public string? ForeignCurrencyRevaluation { get; set; }

    [StringLength(2000)]
    public string? InflationAdjustment { get; set; }

    [StringLength(2000)]
    public string? IsSuspended { get; set; }

    [StringLength(2000)]
    public string? MainAccountCategory { get; set; }

    public long? MainAccountRecId { get; set; }

    [StringLength(2000)]
    public string? MainAccountType { get; set; }

    [StringLength(2000)]
    public string? MandatoryPaymentReference { get; set; }

    [StringLength(2000)]
    public string? Monetary { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? OffsetAccountDisplayValue { get; set; }

    [StringLength(2000)]
    public string? OpeningAccountId { get; set; }

    [StringLength(2000)]
    public string? ParentMainAccountId { get; set; }

    [StringLength(2000)]
    public string? PostingType { get; set; }

    [StringLength(2000)]
    public string? RepomoType { get; set; }

    [StringLength(2000)]
    public string? ReportingAccountType { get; set; }

    [StringLength(2000)]
    public string? ReportingExchangeAdjustmentRateType { get; set; }

    [StringLength(2000)]
    public string? SRUCode { get; set; }

    [StringLength(2000)]
    public string? User { get; set; }

    [StringLength(2000)]
    public string? ValidateCurrency { get; set; }

    [StringLength(2000)]
    public string? ValidatePostingType { get; set; }

    [StringLength(2000)]
    public string? ValidateUser { get; set; }

    [StringLength(2000)]
    public string? DoNotAllowManualEntryLegalEntity { get; set; }
}

public partial class MainAccountsTest : MainAccountsBase {}

public partial class MainAccounts : MainAccountsBase {}
