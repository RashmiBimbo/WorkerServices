using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("DimensionValue", "FinancialDimension", "LegalEntityId")]
public abstract partial class FinancialDimensionValuesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string DimensionValue { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string FinancialDimension { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string LegalEntityId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? ActiveFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActiveTo { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? GroupDimension { get; set; }

    [StringLength(2000)]
    public string? IsBalancing_PSN { get; set; }

    [StringLength(2000)]
    public string? IsBlockedForManualEntry { get; set; }

    [StringLength(2000)]
    public string? IsSuspended { get; set; }

    [StringLength(2000)]
    public string? IsTotal { get; set; }

    [StringLength(2000)]
    public string? Owner { get; set; }

    [StringLength(2000)]
    public string? HG_BusinessArea { get; set; }

    [StringLength(2000)]
    public string? HG_CompanyName { get; set; }
}

public partial class FinancialDimensionValuesTest : FinancialDimensionValuesBase {}

public partial class FinancialDimensionValues : FinancialDimensionValuesBase {}
