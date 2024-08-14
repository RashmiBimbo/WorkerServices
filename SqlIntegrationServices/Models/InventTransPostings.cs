using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventTransOrigin", "InventTransPostingType", "TransDate", "Voucher")]
public abstract partial class InventTransPostingsBase
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
    public long InventTransOrigin { get; set; }

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
    public string? IsPosted { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? PostingType { get; set; }

    [StringLength(2000)]
    public string? PostingTypeOffset { get; set; }

    [StringLength(2000)]
    public string? ProjId { get; set; }

    public DateTime? TransBeginTime { get; set; }

    [StringLength(2000)]
    public string? ModifiedByCopy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTimeCopy1 { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class InventTransPostingsTest : InventTransPostingsBase {}

public partial class InventTransPostings : InventTransPostingsBase {}
