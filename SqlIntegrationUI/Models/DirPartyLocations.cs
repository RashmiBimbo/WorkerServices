using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("DirPartyTable_FK_PartyNumber", "LogisticsLocation_FK_LocationId")]
public partial class DirPartyLocations
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string DirPartyTable_FK_PartyNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string LogisticsLocation_FK_LocationId { get; set; } = null!;

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
