using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "InventSiteId", "ItemId", "Shift", "TransDate")]
public partial class ProdWastageAnalysiss
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventSiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string Shift { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Burnt { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ImproperMShape { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OverSize { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PoorSlicing { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? UnderSize { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? WrongDepanning { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? WrongWrapped { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? RNDProcWaste { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? RNDProdWaste { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
