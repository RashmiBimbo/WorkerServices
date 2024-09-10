using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "JournalBatchNumber", "LineNumber")]
public abstract partial class GeneralLedgerCustInvoiceJournalLinesBase
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
    public string JournalBatchNumber { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal LineNumber { get; set; }

    [StringLength(2000)]
    public string? AccountType { get; set; }

    [StringLength(2000)]
    public string? Approved { get; set; }

    [StringLength(2000)]
    public string? ApprovedBy { get; set; }

    [StringLength(2000)]
    public string? BankTransactionType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CashDiscountAmount { get; set; }

    [StringLength(2000)]
    public string? CashDiscountCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscountDate { get; set; }

    [StringLength(2000)]
    public string? ChineseVoucher { get; set; }

    [StringLength(255)]
    public string? ChineseVoucherType { get; set; }

    [StringLength(255)]
    public string? Company { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CreditAmount { get; set; }

    [StringLength(255)]
    public string? Currency { get; set; }

    [StringLength(2000)]
    public string? CustomerAccountDisplayValue { get; set; }

    [StringLength(2000)]
    public string? CustVendBankAccountId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DebitAmount { get; set; }

    [StringLength(2000)]
    public string? DefaultDimensionDisplayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DocumentNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRateSecondary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceDate { get; set; }

    [StringLength(2000)]
    public string? InvoiceId { get; set; }

    [StringLength(2000)]
    public string? IsWithholdingCalculationEnabled { get; set; }

    [StringLength(2000)]
    public string? ItemSalesTaxGroup { get; set; }

    [StringLength(2000)]
    public string? ItemWithholdingTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? Listcode { get; set; }

    [StringLength(2000)]
    public string? MethodOfPayment { get; set; }

    [StringLength(2000)]
    public string? OffsetAccountDisplayValue { get; set; }

    [StringLength(2000)]
    public string? OffsetAccountType { get; set; }

    [StringLength(255)]
    public string? OffsetCompany { get; set; }

    [StringLength(2000)]
    public string? OffsetTransactionText { get; set; }

    [StringLength(2000)]
    public string? PaymentSpecification { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [StringLength(2000)]
    public string? ReasonCode { get; set; }

    [StringLength(2000)]
    public string? ReasonComment { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyExchRate { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroup { get; set; }

    [StringLength(2000)]
    public string? TaxExemptNumber { get; set; }

    [StringLength(2000)]
    public string? TermsOfPayment { get; set; }

    [StringLength(2000)]
    public string? TransactionText { get; set; }

    [StringLength(2000)]
    public string? TransactionType { get; set; }

    [StringLength(2000)]
    public string? TypeOfOperation { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesTax { get; set; }
}

public partial class GeneralLedgerCustInvoiceJournalLinesTest : GeneralLedgerCustInvoiceJournalLinesBase {}

public partial class GeneralLedgerCustInvoiceJournalLines : GeneralLedgerCustInvoiceJournalLinesBase {}
