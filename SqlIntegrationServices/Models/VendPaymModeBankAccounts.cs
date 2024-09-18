using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "LineId")]
public abstract partial class VendPaymModeBankAccountsBase
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
    [StringLength(36)]
    public string LineId { get; set; } = null!;

    [StringLength(2000)]
    public string? BankAccountID { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DefaultDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? PaymMode { get; set; }
}

public partial class VendPaymModeBankAccountsTest : VendPaymModeBankAccountsBase { }

public partial class VendPaymModeBankAccounts : VendPaymModeBankAccountsBase { }
