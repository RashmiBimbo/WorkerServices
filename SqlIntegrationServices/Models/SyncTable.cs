using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[Keyless]
public abstract partial class SyncTableBase
{
    [StringLength(150)]
    [Unicode(false)]
    public string? TableID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Transdate { get; set; }

    public string? UrlId { get; set; }

    public int? TaskIncreement { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? TranDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastSyncDate { get; set; }
}

public partial class SyncTableTest : SyncTableBase {}

public partial class SyncTable : SyncTableBase {}
