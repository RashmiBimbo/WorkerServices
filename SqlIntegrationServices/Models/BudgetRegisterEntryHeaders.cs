using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "EntryNumber", "LegalEntityId")]
public abstract partial class BudgetRegisterEntryHeadersBase
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

    [StringLength(255)]
    public string? BudgetCode { get; set; }

    [StringLength(255)]
    public string? BudgetModelId { get; set; }

    [StringLength(2000)]
    public string? BudgetType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DefaultDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExpenseBudgetTotal { get; set; }

    [StringLength(2000)]
    public string? OneTimeRevision { get; set; }

    [StringLength(2000)]
    public string? ReasonCode { get; set; }

    [StringLength(2000)]
    public string? ReasonComment { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RevenueBudgetTotal { get; set; }

    [StringLength(2000)]
    public string? SourceDocument { get; set; }

    [StringLength(2000)]
    public string? Status { get; set; }

    [StringLength(2000)]
    public string? WorkflowStatus { get; set; }

    [StringLength(2000)]
    public string? BudgetClassifications { get; set; }

    [StringLength(2000)]
    public string? Budgetmaincategory { get; set; }

    [StringLength(2000)]
    public string? ProductTypes { get; set; }
}

public partial class BudgetRegisterEntryHeadersTest : BudgetRegisterEntryHeadersBase { }

public partial class BudgetRegisterEntryHeaders : BudgetRegisterEntryHeadersBase { }
