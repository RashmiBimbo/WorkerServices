using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[Keyless]
public partial class HGMRPCalculations
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [StringLength(2000)]
    public string? dataAreaId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [StringLength(2000)]
    public string? GroupId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? GSTAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? GSTPercentage { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? JournalName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MRPCode { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MTAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MTIndirectAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MTIndirectPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MTPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? NetAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PTDAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PTDPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PTRAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PTRPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SSAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SSPercentage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? RejectionAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? RejectionPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ECOMDirectAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ECOMDirectPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ECOMInDirectAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ECOMInDirectPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InstitutionAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InstitutionPercentage { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
