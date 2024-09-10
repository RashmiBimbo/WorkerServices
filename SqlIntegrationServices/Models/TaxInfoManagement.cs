using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("LocationId", "Name")]
public abstract partial class TaxInfoManagementBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string LocationId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [StringLength(2000)]
    public string? Commissionarate { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(2000)]
    public string? Division { get; set; }

    [StringLength(2000)]
    public string? ECCNumberOthers { get; set; }

    [StringLength(2000)]
    public string? GSTNumber { get; set; }

    [StringLength(2000)]
    public string? IECNumber { get; set; }

    [StringLength(2000)]
    public string? IsPrimary { get; set; }

    [StringLength(2000)]
    public string? LargeTaxpayerUnitCode { get; set; }

    [StringLength(2000)]
    public string? ManufacturerECCNumber { get; set; }

    [StringLength(2000)]
    public string? NumSeqGroup { get; set; }

    [StringLength(2000)]
    public string? Range { get; set; }

    [StringLength(2000)]
    public string? RegistrationType { get; set; }

    [StringLength(2000)]
    public string? SalesTaxRegistrationNumber { get; set; }

    [StringLength(2000)]
    public string? STCNumber { get; set; }

    [StringLength(2000)]
    public string? TaxAccountNumber { get; set; }

    [StringLength(2000)]
    public string? TaxIdentificationNumber { get; set; }

    [StringLength(2000)]
    public string? TraderECCNumber { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class TaxInfoManagementTest : TaxInfoManagementBase {}

public partial class TaxInfoManagement : TaxInfoManagementBase {}
