using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InvoiceDate", "InvoiceNumber")]
public abstract partial class SalesInvoiceHeadersBase
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
    [Column(TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InvoiceNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? ContactPersonId { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? CustomersOrderReference { get; set; }

    [StringLength(2000)]
    public string? DeliveryModeCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryTermsCode { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCity { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressState { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStreet { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? InvoiceCustomerAccountNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceHeaderTaxAmount { get; set; }

    [StringLength(2000)]
    public string? PaymentTermsName { get; set; }

    [StringLength(2000)]
    public string? SalesOrderNumber { get; set; }

    [StringLength(2000)]
    public string? SalesOrderOriginCode { get; set; }

    [StringLength(2000)]
    public string? SalesOrderResponsiblePersonnelNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TotalChargeAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TotalDiscountAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TotalDiscountCustomerGroupCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TotalInvoiceAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TotalTaxAmount { get; set; }
}

public partial class SalesInvoiceHeadersTest : SalesInvoiceHeadersBase { }

public partial class SalesInvoiceHeaders : SalesInvoiceHeadersBase { }
