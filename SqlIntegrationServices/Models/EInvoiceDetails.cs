using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InvoiceId", "Irn")]
public abstract partial class EInvoiceDetailsBase
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
    public string InvoiceId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string Irn { get; set; } = null!;

    [StringLength(2000)]
    public string? AckDate { get; set; }

    [StringLength(2000)]
    public string? AckNo { get; set; }

    [StringLength(2000)]
    public string? AXDocumentNo { get; set; }

    [StringLength(2000)]
    public string? ClearTaxResponse { get; set; }

    [StringLength(2000)]
    public string? ErrorDetails { get; set; }

    [StringLength(2000)]
    public string? InfoMsg { get; set; }

    [StringLength(2000)]
    public string? JsonData { get; set; }

    [StringLength(2000)]
    public string? SignedQRCode { get; set; }

    [StringLength(2000)]
    public string? Status { get; set; }

    [StringLength(2000)]
    public string? Success { get; set; }
}

public partial class EInvoiceDetailsTest : EInvoiceDetailsBase {}

public partial class EInvoiceDetails : EInvoiceDetailsBase {}
