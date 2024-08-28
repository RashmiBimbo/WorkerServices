using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "HG_Recid", "InventSiteId", "ItemId")]
public abstract partial class ProdDieselStdsBase
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
    public int HG_Recid { get; set; }

    [Key]
    [StringLength(255)]
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [StringLength(2000)]
    public string? DisplayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdDieselUsage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    [StringLength(2000)]
    public string? DisplayValue1 { get; set; }
}

public partial class ProdDieselStdsTest : ProdDieselStdsBase {}

public partial class ProdDieselStds : ProdDieselStdsBase {}
