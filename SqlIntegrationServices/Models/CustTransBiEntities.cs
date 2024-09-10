using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "SourceKey")]
public abstract partial class CustTransBiEntitiesBase
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
    public long SourceKey { get; set; }

    public long? AccountingEvent { get; set; }

    [StringLength(2000)]
    public string? AccountNum { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AmountCur { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AmountMST { get; set; }

    [StringLength(2000)]
    public string? Approved { get; set; }

    public long? Approver { get; set; }

    [StringLength(2000)]
    public string? BankCentralBankPurposeCode { get; set; }

    [StringLength(2000)]
    public string? BankCentralBankPurposeText { get; set; }

    public long? BankLCExportLine { get; set; }

    [StringLength(2000)]
    public string? BankRemittanceFileId { get; set; }

    [StringLength(2000)]
    public string? BillOfExchangeID { get; set; }

    public int? BillOfExchangeSeqNum { get; set; }

    [StringLength(2000)]
    public string? BillOfExchangeStatus { get; set; }

    [StringLength(2000)]
    public string? CancelledPayment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CashDiscBaseDate { get; set; }

    [StringLength(2000)]
    public string? CashDiscCode { get; set; }

    [StringLength(2000)]
    public string? CashPayment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Closed { get; set; }

    [StringLength(2000)]
    public string? CollectionLetter { get; set; }

    [StringLength(2000)]
    public string? CollectionLetterCode { get; set; }

    [StringLength(2000)]
    public string? CompanyBankAccountId { get; set; }

    [StringLength(2000)]
    public string? ControlNum { get; set; }

    [StringLength(2000)]
    public string? Correct { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? CustAutomationExclude { get; set; }

    [StringLength(2000)]
    public string? CustAutomationPredictionSent { get; set; }

    [StringLength(2000)]
    public string? CustAutomationPredunningSent { get; set; }

    public long? CustBillingClassification { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CustExchAdjustmentRealized { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CustExchAdjustmentUnrealized { get; set; }

    [StringLength(2000)]
    public string? DeliveryMode { get; set; }

    public long? DirectDebitMandate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DocumentNum { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [StringLength(2000)]
    public string? EUROTriangulation { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchAdjustment { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchAdjustmentReporting { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExchRateSecond { get; set; }

    [StringLength(2000)]
    public string? FixedExchRate { get; set; }

    [StringLength(2000)]
    public string? Interest { get; set; }

    [StringLength(2000)]
    public string? Invoice { get; set; }

    [StringLength(2000)]
    public string? InvoiceType_IT { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastExchAdj { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LastExchAdjRate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
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
    public string? MCRPaymOrderID { get; set; }

    public long? OffsetRecid { get; set; }

    [StringLength(2000)]
    public string? OrderAccount { get; set; }

    [StringLength(2000)]
    public string? PaymId { get; set; }

    [StringLength(2000)]
    public string? PaymMethod { get; set; }

    [StringLength(2000)]
    public string? PaymMode { get; set; }

    [StringLength(2000)]
    public string? PaymReference { get; set; }

    [StringLength(2000)]
    public string? PaymSchedId { get; set; }

    [StringLength(2000)]
    public string? PaymSpec { get; set; }

    [StringLength(2000)]
    public string? PaymTermId { get; set; }

    [StringLength(2000)]
    public string? PostingProfile { get; set; }

    [StringLength(2000)]
    public string? PostingProfileClose { get; set; }

    [StringLength(2000)]
    public string? Prepayment { get; set; }

    public long? ReasonRefRecId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyCrossRate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyExchRate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyExchRateSecondary { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingExchAdjustmentRealized { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingExchAdjustmentUnrealized { get; set; }

    [StringLength(2000)]
    public string? RetailCustTrans { get; set; }

    [StringLength(2000)]
    public string? RetailStoreId { get; set; }

    [StringLength(2000)]
    public string? RetailTerminalId { get; set; }

    [StringLength(2000)]
    public string? RetailTransactionId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SettleAmountCur { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SettleAmountMST { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SettleAmountReporting { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SettleAmount_MX { get; set; }

    [StringLength(2000)]
    public string? Settlement { get; set; }

    [StringLength(2000)]
    public string? SysCreatedBy { get; set; }

    public long? SysCreatedTransactionId { get; set; }

    [StringLength(2000)]
    public string? SysDataAreaId { get; set; }

    [StringLength(2000)]
    public string? SysModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SysModifiedDateTime { get; set; }

    public long? SysModifiedTransactionId { get; set; }

    public int? SysRecVersion { get; set; }

    [StringLength(2000)]
    public string? TaxInvoiceSalesId { get; set; }

    [StringLength(2000)]
    public string? ThirdPartyBankAccountId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? TransType { get; set; }

    [StringLength(2000)]
    public string? Txt { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }
}

public partial class CustTransBiEntitiesTest : CustTransBiEntitiesBase {}

public partial class CustTransBiEntities : CustTransBiEntitiesBase {}
