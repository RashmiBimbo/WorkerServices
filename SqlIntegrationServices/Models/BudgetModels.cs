using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("BudgetModel", "dataAreaId")]
public abstract partial class BudgetModelsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string BudgetModel { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [StringLength(2000)]
    public string? CashFlowForecasts { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? Stopped { get; set; }
}

public partial class BudgetModelsTest : BudgetModelsBase { }

public partial class BudgetModels : BudgetModelsBase { }
