using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("DirPartyTableFkPartyNumber", "LogisticsLocationFkLocationId")]
public partial class DirPartyLocationTest
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [Column("DirPartyTable_FK_PartyNumber")]
    [StringLength(255)]
    public string DirPartyTableFkPartyNumber { get; set; } = null!;

    [Key]
    [Column("LogisticsLocation_FK_LocationId")]
    [StringLength(255)]
    public string LogisticsLocationFkLocationId { get; set; } = null!;

    [StringLength(2000)]
    public string? AttentionToAddressLine { get; set; }

    [StringLength(2000)]
    public string? IsLocationOwner { get; set; }

    [StringLength(2000)]
    public string? IsPostalAddress { get; set; }

    [StringLength(2000)]
    public string? IsPrimary { get; set; }

    [StringLength(2000)]
    public string? IsPrimaryTaxRegistration { get; set; }

    [StringLength(2000)]
    public string? IsPrivate { get; set; }

    [StringLength(2000)]
    public string? IsRoleBusiness { get; set; }

    [StringLength(2000)]
    public string? IsRoleDelivery { get; set; }

    [StringLength(2000)]
    public string? IsRoleHome { get; set; }

    [StringLength(2000)]
    public string? IsRoleInvoice { get; set; }

    [StringLength(2000)]
    public string? PostalAddressRoles { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
