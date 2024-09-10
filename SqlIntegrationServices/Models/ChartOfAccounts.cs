using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class ChartOfAccountsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [Column("ChartOfAccounts")]
    [StringLength(255)]
    public string ChartOfAccounts1 { get; set; } = null!;

    public long? ChartOfAccountsRecId { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? MainAccountMask { get; set; }
}

public partial class ChartOfAccountsTest : ChartOfAccountsBase {}

public partial class ChartOfAccounts : ChartOfAccountsBase {}
