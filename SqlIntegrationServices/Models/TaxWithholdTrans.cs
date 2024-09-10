using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CustInvoiceTrans", "dataAreaId", "Invoice", "RecId1", "SalesId")]
public abstract partial class TaxWithholdTransBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    public long CustInvoiceTrans { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string Invoice { get; set; } = null!;

    [Key]
    public long RecId1 { get; set; }

    [Key]
    [StringLength(255)]
    public string SalesId { get; set; } = null!;

    [StringLength(2000)]
    public string? InvoiceVoucher { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RateOfDeduction { get; set; }

    [StringLength(2000)]
    public string? TaxType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxWithholdAmountCur { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TaxWithholdAmountOrigin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class TaxWithholdTransTest : TaxWithholdTransBase {}

public partial class TaxWithholdTrans : TaxWithholdTransBase {}
