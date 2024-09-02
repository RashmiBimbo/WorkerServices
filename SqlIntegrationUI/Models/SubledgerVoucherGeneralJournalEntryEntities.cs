using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("RecId1", "Voucher")]
public partial class SubledgerVoucherGeneralJournalEntryEntities
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    public long RecId1 { get; set; }

    [Key]
    [StringLength(255)]
    public string Voucher { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? AccountingDate { get; set; }

    public long? GeneralJournalEntry { get; set; }

    public long? Partition1 { get; set; }

    public int? RecVersion1 { get; set; }

    public long? SubledgerJournalEntry { get; set; }

    public long? TransferId { get; set; }

    [StringLength(2000)]
    public string? VoucherDataAreaId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
