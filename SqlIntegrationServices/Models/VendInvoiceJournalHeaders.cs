using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "JournalBatchNumber")]
public abstract partial class VendInvoiceJournalHeadersBase
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

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? IsPosted { get; set; }

    [StringLength(2000)]
    public string? JournalName { get; set; }

    [StringLength(2000)]
    public string? SalesTaxIncluded { get; set; }
}

public partial class VendInvoiceJournalHeadersTest : VendInvoiceJournalHeadersBase { }

public partial class VendInvoiceJournalHeaders : VendInvoiceJournalHeadersBase { }
