using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("EmploymentEndDate", "EmploymentStartDate", "LegalEntityId", "PersonnelNumber")]
public abstract partial class HCMEmploymentsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime EmploymentEndDate { get; set; }

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime EmploymentStartDate { get; set; }

    [Key]
    [StringLength(255)]
    public string LegalEntityId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string PersonnelNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? CalendarId { get; set; }

    [StringLength(2000)]
    public string? DimensionDisplayValue { get; set; }

    [StringLength(255)]
    public string? RegulatoryEstablishmentId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidTo { get; set; }

    [StringLength(2000)]
    public string? WorkerType { get; set; }
}

public partial class HCMEmploymentsTest : HCMEmploymentsBase {}

public partial class HCMEmployments : HCMEmploymentsBase {}
