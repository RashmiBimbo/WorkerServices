using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "GeneralJournalAccountEntryRecId")]
public abstract partial class GeneralJournalAccountEntryV2Entities_TBase
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
    public long GeneralJournalAccountEntryRecId { get; set; }

    [StringLength(2000)]
    public string? AccountDisplayValue { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AccountingCurrencyAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AccountingDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AcknowledgementDate { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DocumentNumber { get; set; }

    public long? GeneralJournalEntry { get; set; }

    [StringLength(2000)]
    public string? IsCorrection { get; set; }

    [StringLength(2000)]
    public string? IsCredit { get; set; }

    [StringLength(2000)]
    public string? JournalCategory { get; set; }

    [StringLength(2000)]
    public string? JournalNumber { get; set; }

    [StringLength(2000)]
    public string? LedgerAccount { get; set; }

    [StringLength(2000)]
    public string? LedgerName { get; set; }

    public long? MainAccount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? PostingLayer { get; set; }

    [StringLength(2000)]
    public string? PostingType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportingCurrencyAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TransactionCurrencyAmount { get; set; }

    [StringLength(2000)]
    public string? TransactionCurrencyCode { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }
}

public partial class GeneralJournalAccountEntryV2Entities_TTest : GeneralJournalAccountEntryV2Entities_TBase { }

public partial class GeneralJournalAccountEntryV2Entities_T : GeneralJournalAccountEntryV2Entities_TBase { }
