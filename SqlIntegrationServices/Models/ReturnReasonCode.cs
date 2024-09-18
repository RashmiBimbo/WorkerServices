using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[Keyless]
public abstract partial class ReturnReasonCodeBase
{
    [Column(TypeName = "numeric(18, 0)")]
    public decimal RecId { get; set; }

    [Column("ReturnReasonCode")]
    [StringLength(15)]
    [Unicode(false)]
    public string? ReturnReasonCode1 { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Descrition { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ReturnReasonGroup { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IsGoodReturn { get; set; }
}

public partial class ReturnReasonCodeTest : ReturnReasonCodeBase { }

public partial class ReturnReasonCode : ReturnReasonCodeBase { }
