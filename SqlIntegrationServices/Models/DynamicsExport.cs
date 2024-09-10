using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[Keyless]
public abstract partial class DynamicsExportBase
{
    [StringLength(50)]
    public string? ReturnReasonCodeId { get; set; }

    [StringLength(50)]
    public string? Customer { get; set; }

    [StringLength(50)]
    public string? Item_number { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? Quantity { get; set; }

    [StringLength(50)]
    public string? Sales_order { get; set; }
}

public partial class DynamicsExportTest : DynamicsExportBase {}

public partial class DynamicsExport : DynamicsExportBase {}
