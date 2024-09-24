using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("LanguageId", "ProductNumber")]
public abstract partial class EcoResProductTranslationsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string LanguageId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? ProductName { get; set; }
}

public partial class EcoResProductTranslationsTest : EcoResProductTranslationsBase { }

public partial class EcoResProductTranslations : EcoResProductTranslationsBase { }
