using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CustVendRelation", "dataAreaId", "FromDate", "ItemId", "ToDate")]
[Index("ItemId", "FromDate", Name = "idx_ItemidFdate")]
[Index("FromDate", Name = "idx_fromdate")]
public abstract partial class CustomerItemsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string CustVendRelation { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime FromDate { get; set; }

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime ToDate { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? IsActive { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class CustomerItemsTest : CustomerItemsBase { }

public partial class CustomerItems : CustomerItemsBase { }
