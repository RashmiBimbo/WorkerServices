using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("RegistrationNumber", "RegistrationType", "TaxType")]
public abstract partial class TaxRegistrationNumbers_INDsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string RegistrationNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string RegistrationType { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string TaxType { get; set; } = null!;

    [StringLength(2000)]
    public string? BusinessVerticalsTable_IN_BusinessVerticals { get; set; }

    [StringLength(2000)]
    public string? IsGlobal { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? NameOfTaxablePerson { get; set; }

    public long? RecId1 { get; set; }

    [StringLength(2000)]
    public string? RefCompanyId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TurnOver { get; set; }

    [StringLength(2000)]
    public string? Type { get; set; }
}

public partial class TaxRegistrationNumbers_INDsTest : TaxRegistrationNumbers_INDsBase { }

public partial class TaxRegistrationNumbers_INDs : TaxRegistrationNumbers_INDsBase { }
