using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("DisplayValue", "RecId1")]
public partial class DimensionAttributeValueCombinations
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string DisplayValue { get; set; } = null!;

    [Key]
    public long RecId1 { get; set; }

    public long? AccountStructure_DeletedVersion { get; set; }

    [StringLength(2000)]
    public string? AccountStructure_IsDraft { get; set; }

    [StringLength(2000)]
    public string? AccountStructure_IsSystemGenerated { get; set; }

    [StringLength(2000)]
    public string? AccountStructure_Name { get; set; }

    [StringLength(2000)]
    public string? AccountStructure_StructureType { get; set; }

    [StringLength(2000)]
    public string? DataAreaForCreation { get; set; }

    public byte[]? Hash { get; set; }

    [StringLength(2000)]
    public string? LedgerDimensionType { get; set; }

    public long? MainAccount { get; set; }

    [StringLength(2000)]
    public string? MainAccountValue { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
