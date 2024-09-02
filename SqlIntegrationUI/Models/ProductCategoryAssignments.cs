using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("ProductCategoryHierarchyName", "ProductCategoryName", "ProductNumber")]
public partial class ProductCategoryAssignments
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string ProductCategoryHierarchyName { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductCategoryName { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductNumber { get; set; } = null!;

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? DisplayOrder { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
