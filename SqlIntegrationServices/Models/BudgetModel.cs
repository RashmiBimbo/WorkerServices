using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("BudgetModel1", "DataAreaId")]
public abstract partial class BudgetModelBase
{
    [Key]
    [Column("BudgetModel")]
    public string BudgetModel1 { get; set; } = null!;

    [Key]
    public string DataAreaId { get; set; } = null!;

    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    public string? ParentReference { get; set; }

    public string? CashFlowForecasts { get; set; }

    public string? Name { get; set; }

    public string? Stopped { get; set; }
}

public partial class BudgetModelTest : BudgetModelBase { }

public partial class BudgetModel : BudgetModelBase { }
