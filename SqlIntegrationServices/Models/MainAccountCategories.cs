using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class MainAccountCategoriesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    public int ReferenceId { get; set; }

    [StringLength(2000)]
    public string? Closed { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    public int? DisplayOrder { get; set; }

    [StringLength(2000)]
    public string? MainAccountCategory { get; set; }

    [StringLength(2000)]
    public string? MainAccountType { get; set; }
}

public partial class MainAccountCategoriesTest : MainAccountCategoriesBase {}

public partial class MainAccountCategories : MainAccountCategoriesBase {}
