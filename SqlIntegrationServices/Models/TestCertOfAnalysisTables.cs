﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventCertificateOfAnalysisId")]
public abstract partial class TestCertOfAnalysisTablesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventCertificateOfAnalysisId { get; set; } = null!;

    [StringLength(2000)]
    public string? AccountRelation { get; set; }

    [StringLength(2000)]
    public string? ContactPersonId { get; set; }

    [StringLength(2000)]
    public string? InventDimId { get; set; }

    [StringLength(2000)]
    public string? InventRefId { get; set; }

    [StringLength(2000)]
    public string? InventRefTransId { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? QualityOrderId { get; set; }

    [StringLength(2000)]
    public string? ReferenceType { get; set; }

    [StringLength(2000)]
    public string? RouteId { get; set; }
}

public partial class TestCertOfAnalysisTablesTest : TestCertOfAnalysisTablesBase { }

public partial class TestCertOfAnalysisTables : TestCertOfAnalysisTablesBase { }
