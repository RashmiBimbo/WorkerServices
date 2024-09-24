using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "GroupCode")]
public abstract partial class PriceCustomerGroupsBase
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
    public string GroupCode { get; set; } = null!;

    [StringLength(2000)]
    public string? GroupName { get; set; }

    public int? PricingPriority { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class PriceCustomerGroupsTest : PriceCustomerGroupsBase { }

public partial class PriceCustomerGroups : PriceCustomerGroupsBase { }
