using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("BagQty", "dataAreaId", "InventSiteId", "ItemId", "KPIBatchNo")]
public abstract partial class KPIStdDatasBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal BagQty { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string KPIBatchNo { get; set; } = null!;

    public int? Count1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FSTDRej { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdChangeOverMinute { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdProdQuantity { get; set; }

    public int? StdStockDays { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TargetWeight { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidTillDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class KPIStdDatasTest : KPIStdDatasBase {}

public partial class KPIStdDatas : KPIStdDatasBase {}
