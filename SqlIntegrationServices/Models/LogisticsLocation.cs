using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public partial class LogisticsLocationTest
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string LocationId { get; set; } = null!;

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [Column("DunsNumber_FK_DunsNumber")]
    [StringLength(2000)]
    public string? DunsNumberFkDunsNumber { get; set; }

    [StringLength(2000)]
    public string? IsPostalAddress { get; set; }

    [Column("LogisticsLocation_FK_LocationId")]
    [StringLength(2000)]
    public string? LogisticsLocationFkLocationId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    public long? RecId1 { get; set; }
}
