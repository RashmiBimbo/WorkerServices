﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[Keyless]
public partial class HGMRPDiscountCalculations
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [StringLength(2000)]
    public string? dataAreaId { get; set; }

    [StringLength(2000)]
    public string? DiscountGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? JournalName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Percent1 { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Percent2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    [StringLength(2000)]
    public string? SiconeMRPReport { get; set; }

    [StringLength(2000)]
    public string? Type { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
