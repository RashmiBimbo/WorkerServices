using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CustTable", "dataAreaId")]
public abstract partial class TaxInformationCustTable_INDsBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string CustTable { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [StringLength(2000)]
    public string? CustomerType { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [StringLength(2000)]
    public string? DefaultECommerceOperator { get; set; }

    [StringLength(2000)]
    public string? IsConsumer { get; set; }

    [StringLength(2000)]
    public string? IsForeign { get; set; }

    [StringLength(2000)]
    public string? IsPreferential { get; set; }

    [StringLength(2000)]
    public string? MerchantID { get; set; }

    [StringLength(2000)]
    public string? NatureOfAssessee { get; set; }

    [StringLength(2000)]
    public string? PANNumber { get; set; }

    [StringLength(2000)]
    public string? PANReferenceNumber { get; set; }

    [StringLength(2000)]
    public string? PanStatus { get; set; }

    [StringLength(2000)]
    public string? TCSGroup { get; set; }

    [StringLength(2000)]
    public string? TDSGroup { get; set; }
}

public partial class TaxInformationCustTable_INDsTest : TaxInformationCustTable_INDsBase {}

public partial class TaxInformationCustTable_INDs : TaxInformationCustTable_INDsBase {}
