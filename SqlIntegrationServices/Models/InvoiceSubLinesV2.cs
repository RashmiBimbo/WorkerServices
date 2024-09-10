using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InvoiceLineNumber", "InvoiceLineReference", "ProductReceiptNumber", "PurchaseOrder")]
public abstract partial class InvoiceSubLinesV2Base
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
    [Column(TypeName = "decimal(28, 16)")]
    public decimal InvoiceLineNumber { get; set; }

    [Key]
    [StringLength(255)]
    public string InvoiceLineReference { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductReceiptNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string PurchaseOrder { get; set; } = null!;

    public long? PurchaseOrderLineNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchaseQuantity { get; set; }
}

public partial class InvoiceSubLinesV2Test : InvoiceSubLinesV2Base {}

public partial class InvoiceSubLinesV2 : InvoiceSubLinesV2Base {}
