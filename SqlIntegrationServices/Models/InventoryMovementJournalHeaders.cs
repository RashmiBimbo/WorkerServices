using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "JournalNumber")]
public abstract partial class InventoryMovementJournalHeadersBase
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
    public string JournalNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AreLinesDeletedAfterPosting { get; set; }

    [StringLength(2000)]
    public string? DefaultInventorySiteId { get; set; }

    [StringLength(2000)]
    public string? DefaultWarehouseId { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? IsPosted { get; set; }

    [StringLength(2000)]
    public string? JournalNameId { get; set; }

    public DateTime? PostedDateTime { get; set; }

    [StringLength(2000)]
    public string? PostedUserId { get; set; }

    [StringLength(2000)]
    public string? PostingDetailLevel { get; set; }

    [StringLength(2000)]
    public string? ReservationMode { get; set; }

    [StringLength(2000)]
    public string? VoucherNumberAllocationRule { get; set; }

    [StringLength(2000)]
    public string? VoucherNumberSelectionRule { get; set; }

    [StringLength(2000)]
    public string? VoucherNumberSequenceCode { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class InventoryMovementJournalHeadersTest : InventoryMovementJournalHeadersBase { }

public partial class InventoryMovementJournalHeaders : InventoryMovementJournalHeadersBase { }
