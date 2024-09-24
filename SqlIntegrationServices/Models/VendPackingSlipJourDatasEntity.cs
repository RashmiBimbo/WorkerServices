using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("AccountNum", "dataAreaId", "DocumentDate", "PackingSlipId", "RecId1")]
public abstract partial class VendPackingSlipJourDatasEntityBase
{
    [Key]
    [StringLength(255)]
    public string AccountNum { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime DocumentDate { get; set; }

    [Key]
    [StringLength(255)]
    public string PackingSlipId { get; set; } = null!;

    [Key]
    public long RecId1 { get; set; }

    public long? BankLCImportLine { get; set; }

    [StringLength(2000)]
    public string? CountryRegionId { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryDate { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    public long? DeliveryPostalAddress { get; set; }

    [StringLength(2000)]
    public string? DeliveryType { get; set; }

    [StringLength(2000)]
    public string? DlvMode { get; set; }

    [StringLength(2000)]
    public string? DlvTerm { get; set; }

    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? FreightSlipNum { get; set; }

    [StringLength(2000)]
    public string? FreightSlipType { get; set; }

    [StringLength(2000)]
    public string? GRNNumber_IN { get; set; }

    [StringLength(2000)]
    public string? InterCompanyCompanyId { get; set; }

    [StringLength(2000)]
    public string? InterCompanyPosted { get; set; }

    [StringLength(2000)]
    public string? InterCompanySalesId { get; set; }

    [StringLength(2000)]
    public string? IntrastatDispatch { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccount { get; set; }

    [StringLength(2000)]
    public string? ItemBuyerGroupId { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroup { get; set; }

    [StringLength(2000)]
    public string? OrderAccount { get; set; }

    public long? PartyTaxID { get; set; }

    [StringLength(2000)]
    public string? ProjectReference { get; set; }

    [StringLength(2000)]
    public string? PurchaseType { get; set; }

    [StringLength(2000)]
    public string? PurchId { get; set; }

    [StringLength(2000)]
    public string? ReqAttention { get; set; }

    public long? Requester { get; set; }

    [StringLength(2000)]
    public string? ReturnItemNum { get; set; }

    public long? SourceDocumentHeader { get; set; }

    public long? TaxID { get; set; }

    public long? TransportationDocument { get; set; }

    [StringLength(2000)]
    public string? VendReference { get; set; }

    [StringLength(2000)]
    public string? InventSiteId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [MaxLength(2000)]
    public byte[]? PackedExtensions { get; set; }
}

public partial class VendPackingSlipJourDatasEntityTest : VendPackingSlipJourDatasEntityBase { }

public partial class VendPackingSlipJourDatasEntity : VendPackingSlipJourDatasEntityBase { }
