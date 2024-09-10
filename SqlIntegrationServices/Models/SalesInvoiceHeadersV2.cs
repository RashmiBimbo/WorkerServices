using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InvoiceDate", "InvoiceNumber", "LedgerVoucher")]
public abstract partial class SalesInvoiceHeadersV2Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    public DateTime InvoiceDate { get; set; }

    [Key]
    [StringLength(255)]
    public string InvoiceNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string LedgerVoucher { get; set; } = null!;

    [StringLength(2000)]
    public string? ContactPersonId { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? CustomersOrderReference { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressName { get; set; }

    [StringLength(2000)]
    public string? DeliveryModeCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    [StringLength(2000)]
    public string? DeliveryTermsCode { get; set; }

    public DateTime? DemandDateJour { get; set; }

    [StringLength(2000)]
    public string? DriverCode { get; set; }

    [StringLength(2000)]
    public string? DriverName { get; set; }

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

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? InvoiceHeaderTaxAmount { get; set; }

    [StringLength(2000)]
    public string? InvoiceId_CT { get; set; }

    [StringLength(2000)]
    public string? IRNNumber { get; set; }

    [StringLength(2000)]
    public string? IsProcessed { get; set; }

    [StringLength(2000)]
    public string? IsProcess_CT { get; set; }

    [StringLength(2000)]
    public string? IsReturn { get; set; }

    [StringLength(2000)]
    public string? IsSample { get; set; }

    [StringLength(2000)]
    public string? LoaderCode { get; set; }

    [StringLength(2000)]
    public string? LoaderName { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? OrderAccount { get; set; }

    [StringLength(2000)]
    public string? OrderId { get; set; }

    [StringLength(2000)]
    public string? PackerCode { get; set; }

    [StringLength(2000)]
    public string? PackerName { get; set; }

    [StringLength(2000)]
    public string? PaymentTermsName { get; set; }

    [StringLength(2000)]
    public string? PORefID { get; set; }

    public long? RecId1 { get; set; }

    [StringLength(2000)]
    public string? ReturnReasonCodeId { get; set; }

    [StringLength(2000)]
    public string? RouteCode { get; set; }

    [StringLength(2000)]
    public string? SalesId { get; set; }

    [StringLength(2000)]
    public string? SalesId_CT { get; set; }

    [StringLength(2000)]
    public string? SalesOrderNumber { get; set; }

    [StringLength(2000)]
    public string? SalesOrderOriginCode { get; set; }

    [StringLength(2000)]
    public string? SalesOrderResponsiblePersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? SalespersonCode { get; set; }

    [StringLength(2000)]
    public string? SalesStatus { get; set; }

    [StringLength(2000)]
    public string? SalesType { get; set; }

    [StringLength(2000)]
    public string? SupervisorCode { get; set; }

    [StringLength(2000)]
    public string? SupervisorCodeBak { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? TotalChargeAmount { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? TotalDiscountAmount { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? TotalDiscountCustomerGroupCode { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? TotalInvoiceAmount { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? TotalTaxAmount { get; set; }

    [StringLength(2000)]
    public string? VehicleCode { get; set; }

    [StringLength(2000)]
    public string? VehicleTag { get; set; }

    [StringLength(2000)]
    public string? LineDisc { get; set; }

    [StringLength(2000)]
    public string? PriceGroupId { get; set; }
}

public partial class SalesInvoiceHeadersV2Test : SalesInvoiceHeadersV2Base {}

public partial class SalesInvoiceHeadersV2 : SalesInvoiceHeadersV2Base {}
