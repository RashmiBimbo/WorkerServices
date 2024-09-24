using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "JournalBatchNumber", "LineNumber")]
public abstract partial class VendInvoiceJournalLinesBase
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
    public string? AccountDisplayValue { get; set; }

    [StringLength(2000)]
    public string? AccountType { get; set; }

    [StringLength(2000)]
    public string? Approved { get; set; }

    [StringLength(2000)]
    public string? ApproverNumber { get; set; }

    [StringLength(2000)]
    public string? AssetId { get; set; }

    [StringLength(2000)]
    public string? AssetTransType { get; set; }

    [StringLength(2000)]
    public string? BankAccountId { get; set; }

    [StringLength(255)]
    public string? BookId { get; set; }

    [StringLength(2000)]
    public string? CashDiscount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CashDiscountAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscountDate { get; set; }

    [StringLength(2000)]
    public string? ChineseVoucher { get; set; }

    [StringLength(255)]
    public string? ChineseVoucherType { get; set; }

    [StringLength(255)]
    public string? Company { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Credit { get; set; }

    [StringLength(255)]
    public string? Currency { get; set; }

    [StringLength(2000)]
    public string? CustVendBankAccountId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Debit { get; set; }

    [StringLength(2000)]
    public string? DefaultDimensionDisplayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryDate { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? Document { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRateSecond { get; set; }

    [StringLength(2000)]
    public string? FullPrimaryRemittanceAddress { get; set; }

    [StringLength(2000)]
    public string? GSTHSTTaxType { get; set; }

    [StringLength(2000)]
    public string? Invoice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceDate { get; set; }

    [StringLength(2000)]
    public string? InvoiceDeclarationId { get; set; }

    [StringLength(2000)]
    public string? IsWithholdingTaxCalculate { get; set; }

    [StringLength(255)]
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
    public string? PaymId { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressCity { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressCountry { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressCountryISOCode { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressCounty { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressDescription { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressDistrictName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemittanceAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressLocationId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemittanceAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressState { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressStreet { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressTimeZone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RemittanceAddressValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RemittanceAddressValidTo { get; set; }

    [StringLength(2000)]
    public string? RemittanceAddressZipCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyExchRate { get; set; }

    [StringLength(2000)]
    public string? SalesTaxCode { get; set; }

    [StringLength(255)]
    public string? SalesTaxGroup { get; set; }

    public long? Tax1099Fields { get; set; }

    [StringLength(2000)]
    public string? TaxExemptNumber { get; set; }

    [StringLength(2000)]
    public string? TermsOfPayment { get; set; }

    [StringLength(2000)]
    public string? TransactionType { get; set; }

    [StringLength(2000)]
    public string? TypeOfOperation { get; set; }

    [StringLength(2000)]
    public string? UUID { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }
}

public partial class VendInvoiceJournalLinesTest : VendInvoiceJournalLinesBase { }

public partial class VendInvoiceJournalLines : VendInvoiceJournalLinesBase { }
