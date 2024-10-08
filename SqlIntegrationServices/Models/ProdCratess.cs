﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[Keyless]
public abstract partial class ProdCratessBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [StringLength(255)]
    public string AccountNum { get; set; } = null!;

    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    public DateTime TransDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CrateIn { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CrateOut { get; set; }

    public int? Deposit { get; set; }

    [StringLength(2000)]
    public string? Location { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? OpeningBalance { get; set; }
}

public partial class ProdCratessTest : ProdCratessBase { }

public partial class ProdCratess : ProdCratessBase { }
