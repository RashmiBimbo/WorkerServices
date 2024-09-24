using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[Keyless]
public abstract partial class DemandStagingsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CustAccount { get; set; }

    [StringLength(2000)]
    public string? dataAreaId { get; set; }

    [StringLength(2000)]
    public string? HeaderCreated { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? OrderId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Qty { get; set; }

    [StringLength(2000)]
    public string? SalespersonCode { get; set; }

    [StringLength(2000)]
    public string? SupervisorCode { get; set; }

    [StringLength(2000)]
    public string? ItemGroupId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }
}

public partial class DemandStagingsTest : DemandStagingsBase { }

public partial class DemandStagings : DemandStagingsBase { }
