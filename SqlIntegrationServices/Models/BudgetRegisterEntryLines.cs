using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "EntryNumber", "LegalEntityId", "LineNumber")]
public abstract partial class BudgetRegisterEntryLinesBase
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
    public string EntryNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string LegalEntityId { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal LineNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AccountingCurrencyAmount { get; set; }

    [StringLength(2000)]
    public string? AmountType { get; set; }

    [StringLength(2000)]
    public string? BudgetCheckResult { get; set; }

    [StringLength(2000)]
    public string? Comment { get; set; }

    [StringLength(255)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DimensionAccountStructure { get; set; }

    [StringLength(2000)]
    public string? DimensionDisplayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EntryDate { get; set; }

    [StringLength(2000)]
    public string? IncludeInCashFlowForecast { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TransactionCurrencyAmount { get; set; }

    [StringLength(2000)]
    public string? WorkflowStatus { get; set; }
}

public partial class BudgetRegisterEntryLinesTest : BudgetRegisterEntryLinesBase {}

public partial class BudgetRegisterEntryLines : BudgetRegisterEntryLinesBase {}
