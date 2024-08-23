using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventTransId", "InventTransType", "ItemId")]
public abstract partial class ReqTransFirmLogsBase
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
    public string InventTransId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventTransType { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [StringLength(2000)]
    public string? InventTransRefId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Qty { get; set; }

    [StringLength(2000)]
    public string? RefId { get; set; }

    [StringLength(2000)]
    public string? RefType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReqFirmDate { get; set; }

    [StringLength(2000)]
    public string? ReqFirmUserId { get; set; }

    [StringLength(2000)]
    public string? ReqPlanId { get; set; }
}

public partial class ReqTransFirmLogsTest : ReqTransFirmLogsBase {}

public partial class ReqTransFirmLogs : ReqTransFirmLogsBase {}
