using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class InvIRNDataDatasBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string InvoiceId { get; set; } = null!;

    public DateTime? AcknowledgementDateTime { get; set; }

    [StringLength(2000)]
    public string? AcknowledgementNum { get; set; }

    public DateTime? CancelDateTime { get; set; }

    [StringLength(2000)]
    public string? CancelReason { get; set; }

    [StringLength(2000)]
    public string? CancelRemarks { get; set; }

    [StringLength(2000)]
    public string? ConsolidatedEwayBillNo { get; set; }

    public DateTime? ConsolidatedEWayDateTime { get; set; }

    [StringLength(2000)]
    public string? DataAreaIdCopy1 { get; set; }

    [StringLength(2000)]
    public string? EwayBillNo { get; set; }

    public DateTime? EWayDateTime { get; set; }

    public DateTime? EWayValidDateTime { get; set; }

    [StringLength(2000)]
    public string? EWBCancelReason { get; set; }

    [StringLength(2000)]
    public string? EWBCancelRemarks { get; set; }

    [StringLength(2000)]
    public string? EWBUpdateRemarks { get; set; }

    [StringLength(2000)]
    public string? GSTIN { get; set; }

    [StringLength(2000)]
    public string? IsCancelled { get; set; }

    [StringLength(2000)]
    public string? IsEWBCancelled { get; set; }

    [StringLength(2000)]
    public string? IsInvalid { get; set; }

    [StringLength(2000)]
    public string? LedgerVoucher { get; set; }

    public long? ParentRecId { get; set; }

    public int? ParentTableId { get; set; }

    public long? PartitionCopy1 { get; set; }

    public long? RecIdCopy1 { get; set; }

    public int? RecVersionCopy1 { get; set; }

    [StringLength(2000)]
    public string? SignedInvoice { get; set; }

    [StringLength(2000)]
    public string? SignedIRN { get; set; }

    [StringLength(2000)]
    public string? SignedQR { get; set; }

    [StringLength(2000)]
    public string? Status { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class InvIRNDataDatasTest : InvIRNDataDatasBase { }

public partial class InvIRNDataDatas : InvIRNDataDatasBase { }
