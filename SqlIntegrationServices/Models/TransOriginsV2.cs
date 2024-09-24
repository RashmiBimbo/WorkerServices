using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventTransId")]
public abstract partial class TransOriginsV2Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventTransId { get; set; } = null!;

    [StringLength(2000)]
    public string? DirPartyTable_PartyNumber { get; set; }

    [StringLength(2000)]
    public string? IsExcludedFromInventoryValue { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? ItemInventDimId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    public long? RecId1 { get; set; }

    [StringLength(2000)]
    public string? ReferenceCategory { get; set; }

    [StringLength(2000)]
    public string? ReferenceId { get; set; }
}

public partial class TransOriginsV2Test : TransOriginsV2Base { }

public partial class TransOriginsV2 : TransOriginsV2Base { }
