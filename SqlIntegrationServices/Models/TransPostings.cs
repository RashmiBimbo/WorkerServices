using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventTransOrigin_InventTransId", "InventTransPostingType", "TransDate", "Voucher")]
public abstract partial class TransPostingsBase
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
    public string InventTransOrigin_InventTransId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventTransPostingType { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [Key]
    [StringLength(255)]
    public string Voucher { get; set; } = null!;

    [StringLength(2000)]
    public string? DefaultDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? IsPosted { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? LedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? OffsetLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? PostingType { get; set; }

    [StringLength(2000)]
    public string? PostingTypeOffset { get; set; }

    [StringLength(2000)]
    public string? ProjId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransBeginTime { get; set; }

    [StringLength(2000)]
    public string? ModifiedByCopy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTimeCopy1 { get; set; }
}

public partial class TransPostingsTest : TransPostingsBase { }

public partial class TransPostings : TransPostingsBase { }
