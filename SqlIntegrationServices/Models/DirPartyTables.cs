using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public abstract partial class DirPartyTablesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [Key]
    [StringLength(255)]
    public string PartyNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AddressBookNames { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    public long? InstanceRelationType { get; set; }

    [StringLength(2000)]
    public string? KnownAs { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? LogisticsElectronicAddress_Email_Locator { get; set; }

    [StringLength(2000)]
    public string? LogisticsElectronicAddress_Facebook_Locator { get; set; }

    [StringLength(2000)]
    public string? LogisticsElectronicAddress_Fax_Locator { get; set; }

    [StringLength(2000)]
    public string? LogisticsElectronicAddress_LinkedIn_Locator { get; set; }

    [StringLength(2000)]
    public string? LogisticsElectronicAddress_Phone_Locator { get; set; }

    [StringLength(2000)]
    public string? LogisticsElectronicAddress_Telex_Locator { get; set; }

    [StringLength(2000)]
    public string? LogisticsElectronicAddress_Twitter_Locator { get; set; }

    [StringLength(2000)]
    public string? LogisticsElectronicAddress_URL_Locator { get; set; }

    [StringLength(2000)]
    public string? LogisticsLocation_PrimaryAddress_LocationId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? NameAlias { get; set; }
}

public partial class DirPartyTablesTest : DirPartyTablesBase { }

public partial class DirPartyTables : DirPartyTablesBase { }
