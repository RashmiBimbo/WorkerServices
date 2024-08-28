using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "QualityOrderNumber", "QualityOrderSequenceNumber", "QualityTestId", "ResultLineNumber")]
public abstract partial class QualityOrderLineResultsBase
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
    public string QualityOrderNumber { get; set; } = null!;

    [Key]
    public int QualityOrderSequenceNumber { get; set; }

    [Key]
    [StringLength(255)]
    public string QualityTestId { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal ResultLineNumber { get; set; }

    [StringLength(2000)]
    public string? IsTestValidationIncludingResult { get; set; }

    [StringLength(2000)]
    public string? QualityTestVariableOutcomeId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ResultCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ResultInventoryQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ResultValue { get; set; }

    [StringLength(2000)]
    public string? TestResult { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class QualityOrderLineResultsTest : QualityOrderLineResultsBase {}

public partial class QualityOrderLineResults : QualityOrderLineResultsBase {}
