using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class CompaniesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string DataArea { get; set; } = null!;

    [StringLength(2000)]
    public string? KnownAs { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? PartyNumber { get; set; }
}

public partial class CompaniesTest : CompaniesBase {}

public partial class Companies : CompaniesBase {}
