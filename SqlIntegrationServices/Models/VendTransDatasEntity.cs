using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("AccountNum", "dataAreaId", "RecId1")]
public abstract partial class VendTransDatasEntityBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string AccountNum { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    public long RecId1 { get; set; }

    public long? AccountingEvent { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AmountCur { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AmountMST { get; set; }

    [StringLength(2000)]
    public string? Approved { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ApprovedDate { get; set; }

    public long? Approver { get; set; }

    [StringLength(2000)]
    public string? Arrival { get; set; }

    [StringLength(2000)]
    public string? BankCentralBankPurposeCode { get; set; }

    [StringLength(2000)]
    public string? BankCentralBankPurposeText { get; set; }

    public long? BankLCImportLine { get; set; }

    [StringLength(2000)]
    public string? BankRemittanceFileId { get; set; }

    [StringLength(2000)]
    public string? Cancel { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscBaseDate { get; set; }

    [StringLength(2000)]
    public string? CashDiscCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Closed { get; set; }

    [StringLength(2000)]
    public string? CompanyBankAccountId { get; set; }

    [StringLength(2000)]
    public string? Correct { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    public long? CreatedTransactionId1 { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DocumentNum { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [StringLength(2000)]
    public string? EUROTriangulation { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ExchAdjustment { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ExchAdjustmentReporting { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ExchRate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ExchRateSecond { get; set; }

    [StringLength(2000)]
    public string? FixedExchRate { get; set; }

    [StringLength(2000)]
    public string? Invoice { get; set; }

    [StringLength(2000)]
    public string? InvoiceProject { get; set; }

    public DateTime? InvoiceReleaseDate { get; set; }

    [StringLength(2000)]
    public string? JournalNum { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastExchAdj { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LastExchAdjRate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LastExchAdjRateReporting { get; set; }

    [StringLength(2000)]
    public string? LastExchAdjVoucher { get; set; }

    [StringLength(2000)]
    public string? LastSettleAccountNum { get; set; }

    [StringLength(2000)]
    public string? LastSettleCompany { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastSettleDate { get; set; }

    [StringLength(2000)]
    public string? LastSettleVoucher { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    public long? ModifiedTransactionId1 { get; set; }

    public long? OffsetRecid { get; set; }

    public byte[]? PackedExtensions { get; set; }

    public long? Partition1 { get; set; }

    [StringLength(2000)]
    public string? PaymId { get; set; }

    [StringLength(2000)]
    public string? PaymMode { get; set; }

    [StringLength(2000)]
    public string? PaymReference { get; set; }

    [StringLength(2000)]
    public string? PaymSpec { get; set; }

    [StringLength(2000)]
    public string? PaymTermId { get; set; }

    [StringLength(2000)]
    public string? PostingChangeVoucher { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [StringLength(2000)]
    public string? PostingProfileApprove { get; set; }

    [StringLength(2000)]
    public string? PostingProfileCancel { get; set; }

    [StringLength(2000)]
    public string? PostingProfileClose { get; set; }

    [StringLength(2000)]
    public string? PostingProfileReOpen { get; set; }

    [StringLength(2000)]
    public string? Prepayment { get; set; }

    [StringLength(2000)]
    public string? PromissoryNoteID { get; set; }

    public int? PromissoryNoteSeqNum { get; set; }

    [StringLength(2000)]
    public string? PromissoryNoteStatus { get; set; }

    [StringLength(2000)]
    public string? RBOVendTrans { get; set; }

    public long? ReasonRefRecId { get; set; }

    public int? RecVersion1 { get; set; }

    [StringLength(2000)]
    public string? ReleaseDateComment { get; set; }

    public long? RemittanceAddress { get; set; }

    public long? RemittanceLocation { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReportingCurrencyAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReportingCurrencyCrossRate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReportingCurrencyExchRate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReportingCurrencyExchRateSecondary { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReportingExchAdjustmentRealized { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReportingExchAdjustmentUnrealized { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SettleAmountCur { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SettleAmountMST { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SettleAmountReporting { get; set; }

    [StringLength(2000)]
    public string? Settlement { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SettleTax1099Amount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SettleTax1099StateAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Tax1099Amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Tax1099Date { get; set; }

    public long? Tax1099Fields { get; set; }

    [StringLength(2000)]
    public string? Tax1099Num { get; set; }

    public long? Tax1099RecId { get; set; }

    [StringLength(2000)]
    public string? Tax1099State { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Tax1099StateAmount { get; set; }

    [StringLength(2000)]
    public string? TaxInvoicePurchId { get; set; }

    [StringLength(2000)]
    public string? ThirdPartyBankAccountId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? TransType { get; set; }

    [StringLength(2000)]
    public string? Txt { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? VendExchAdjustmentRealized { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? VendExchAdjustmentUnrealized { get; set; }

    [StringLength(2000)]
    public string? VendPaymentGroup { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }
}

public partial class VendTransDatasEntityTest : VendTransDatasEntityBase { }

public partial class VendTransDatasEntity : VendTransDatasEntityBase { }
