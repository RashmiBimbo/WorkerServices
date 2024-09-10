using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CategoryName", "ProductCategoryHierarchyName")]
public abstract partial class ProductCategoriesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string CategoryName { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductCategoryHierarchyName { get; set; } = null!;

    [StringLength(2000)]
    public string? CategoryCode { get; set; }

    [StringLength(2000)]
    public string? CategoryDescription { get; set; }

    [StringLength(2000)]
    public string? CategoryKeywords { get; set; }

    public long? CategoryRecordId { get; set; }

    [StringLength(2000)]
    public string? DefaultProjectGlobalCategoryId { get; set; }

    [StringLength(36)]
    public string? ExternalId { get; set; }

    [StringLength(2000)]
    public string? FriendlyCategoryName { get; set; }

    [StringLength(2000)]
    public string? IsCategoryInheritingParentCategoryAttributes { get; set; }

    [StringLength(2000)]
    public string? IsCategoryInheritingParentProductAttributes { get; set; }

    [StringLength(2000)]
    public string? IsTangibleProduct { get; set; }

    [StringLength(2000)]
    public string? ParentProductCategoryCode { get; set; }

    [StringLength(2000)]
    public string? ParentProductCategoryHierarchyName { get; set; }

    [StringLength(255)]
    public string? ParentProductCategoryName { get; set; }

    [StringLength(2000)]
    public string? PKWiUCode { get; set; }

    [StringLength(2000)]
    public string? ProjectCategoryName { get; set; }
}

public partial class ProductCategoriesTest : ProductCategoriesBase {}

public partial class ProductCategories : ProductCategoriesBase {}
