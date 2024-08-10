using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("AgreementLine", "CustInvoiceTrans", "ProjInvoiceItem", "PurchLineDataAreaId", "PurchLineInventTransId", "SalesLineDataAreaId", "SalesLineInventTransId", "VendInvoiceTrans")]
public abstract partial class AgreementLineReleasedLinesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    public long AgreementLine { get; set; }

    [Key]
    public long CustInvoiceTrans { get; set; }

    [Key]
    public long ProjInvoiceItem { get; set; }

    [Key]
    [StringLength(255)]
    public string PurchLineDataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string PurchLineInventTransId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string SalesLineDataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string SalesLineInventTransId { get; set; } = null!;

    [Key]
    public long VendInvoiceTrans { get; set; }

    [StringLength(2000)]
    public string? IsDeleted { get; set; }

    [StringLength(2000)]
    public string? IsModified { get; set; }

    public int? ReferenceRelationType { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class AgreementLineReleasedLinesTest : AgreementLineReleasedLinesBase {}

public partial class AgreementLineReleasedLines : AgreementLineReleasedLinesBase {}
