using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class GeneralJournalEntryEntitiesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string JournalNumber { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? AccountingDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AcknowledgementDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DocumentNumber { get; set; }

    [StringLength(2000)]
    public string? JournalCategory { get; set; }

    [StringLength(2000)]
    public string? LedgerPostingJournal { get; set; }

    [StringLength(2000)]
    public string? LedgerPostingJournalDataAreaId { get; set; }

    [StringLength(2000)]
    public string? PostingLayer { get; set; }

    public long? RecId1 { get; set; }

    public long? SubledgerJournalEntry { get; set; }

    [StringLength(2000)]
    public string? SubledgerVoucher { get; set; }

    [StringLength(2000)]
    public string? SubledgerVoucherDataAreaId { get; set; }

    public long? TransferId { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class GeneralJournalEntryEntitiesTest : GeneralJournalEntryEntitiesBase { }

public partial class GeneralJournalEntryEntities : GeneralJournalEntryEntitiesBase { }
