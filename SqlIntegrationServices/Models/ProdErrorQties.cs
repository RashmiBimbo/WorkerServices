using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventSiteId", "ItemId", "OvenType", "TransDate")]
public abstract partial class ProdErrorQtiesBase
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
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string OvenType { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ErrorQty { get; set; }

    [StringLength(2000)]
    public string? ProdId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class ProdErrorQtiesTest : ProdErrorQtiesBase {}

public partial class ProdErrorQties : ProdErrorQtiesBase {}
