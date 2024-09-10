using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "SalesOrderNumber")]
public abstract partial class SalesOrderHeadersBase
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
    [StringLength(255)]
    public string SalesOrderNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? ArePricesIncludingSalesTax { get; set; }

    [StringLength(2000)]
    public string? AreTotalsCalculated { get; set; }

    [StringLength(2000)]
    public string? BankConstantSymbol { get; set; }

    [StringLength(2000)]
    public string? BankSpecificSymbol { get; set; }

    [StringLength(2000)]
    public string? CampaignId { get; set; }

    [StringLength(2000)]
    public string? CashDiscountCode { get; set; }

    [StringLength(2000)]
    public string? CFPSCode { get; set; }

    [StringLength(2000)]
    public string? ChargeCustomerGroupId { get; set; }

    [StringLength(2000)]
    public string? CommissionCustomerGroupId { get; set; }

    [StringLength(2000)]
    public string? CommissionSalesRepresentativeGroupId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedReceiptDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedShippingDate { get; set; }

    [StringLength(2000)]
    public string? ContactPersonId { get; set; }

    [StringLength(2000)]
    public string? CreditNoteReasonCode { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? CustomerPaymentFinancialInterestCode { get; set; }

    [StringLength(2000)]
    public string? CustomerPaymentFineCode { get; set; }

    [StringLength(2000)]
    public string? CustomerPaymentMethodName { get; set; }

    [StringLength(2000)]
    public string? CustomerPaymentMethodSpecificationName { get; set; }

    [StringLength(2000)]
    public string? CustomerPostingProfileId { get; set; }

    [StringLength(2000)]
    public string? CustomerRequisitionNumber { get; set; }

    [StringLength(2000)]
    public string? CustomersOrderReference { get; set; }

    [StringLength(2000)]
    public string? CustomerTransactionSettlementType { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DefaultShippingSiteId { get; set; }

    [StringLength(2000)]
    public string? DefaultShippingWarehouseId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCity { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionISOCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDescription { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDunsNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DeliveryAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressLocationId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DeliveryAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressName { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStateId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreet { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? DeliveryModeCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryReasonCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryTermsCode { get; set; }

    [StringLength(2000)]
    public string? DirectDebitMandateId { get; set; }

    [StringLength(2000)]
    public string? EInvoiceDimensionAccountCode { get; set; }

    [StringLength(2000)]
    public string? Email { get; set; }

    [StringLength(2000)]
    public string? EUSalesListCode { get; set; }

    [StringLength(2000)]
    public string? ExportReason { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentOperationTypeId { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentTypeId { get; set; }

    [StringLength(2000)]
    public string? FiscalOperationPresenceType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FixedDueDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FixedExchangeRate { get; set; }

    [StringLength(2000)]
    public string? FormattedDelveryAddress { get; set; }

    [StringLength(2000)]
    public string? FormattedInvoiceAddress { get; set; }

    [StringLength(2000)]
    public string? IntrastatPortId { get; set; }

    [StringLength(2000)]
    public string? IntrastatStatisticsProcedureCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransactionCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransportModeCode { get; set; }

    [StringLength(2000)]
    public string? InventoryReservationMethod { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCity { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressDistrictName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceAddressLatitude { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InvoiceAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStateId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStreet { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? InvoiceBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? InvoiceCustomerAccountNumber { get; set; }

    [StringLength(2000)]
    public string? InvoicePaymentAttachmentType { get; set; }

    [StringLength(2000)]
    public string? InvoiceType { get; set; }

    [StringLength(2000)]
    public string? IsConsolidatedInvoiceTarget { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressOrderSpecific { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressPrivate { get; set; }

    [StringLength(2000)]
    public string? IsEInvoiceDimensionAccountCodeSpecifiedPerLine { get; set; }

    [StringLength(2000)]
    public string? IsEntryCertificateRequired { get; set; }

    [StringLength(2000)]
    public string? IsExportSale { get; set; }

    [StringLength(2000)]
    public string? IsFinalUser { get; set; }

    [StringLength(2000)]
    public string? IsInvoiceAddressPrivate { get; set; }

    [StringLength(2000)]
    public string? IsOneTimeCustomer { get; set; }

    [StringLength(2000)]
    public string? IsOwnEntryCertificateIssued { get; set; }

    [StringLength(2000)]
    public string? IsSalesProcessingStopped { get; set; }

    [StringLength(2000)]
    public string? IsServiceDeliveryAddressBased { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? LineDiscountCustomerGroupCode { get; set; }

    [StringLength(2000)]
    public string? MultilineDiscountCustomerGroupCode { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroupId { get; set; }

    [StringLength(2000)]
    public string? OrderingCustomerAccountNumber { get; set; }

    [StringLength(2000)]
    public string? OrderResponsiblePersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? OrderTakerPersonnelNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? OrderTotalAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? OrderTotalChargesAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? OrderTotalDiscountAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? OrderTotalTaxAmount { get; set; }

    [StringLength(2000)]
    public string? PaymentScheduleName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaymentTermsBaseDate { get; set; }

    [StringLength(2000)]
    public string? PaymentTermsName { get; set; }

    [StringLength(2000)]
    public string? PriceCustomerGroupCode { get; set; }

    [StringLength(2000)]
    public string? QuotationNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedReceiptDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedShippingDate { get; set; }

    [StringLength(2000)]
    public string? SalesOrderName { get; set; }

    [StringLength(2000)]
    public string? SalesOrderOriginCode { get; set; }

    [StringLength(2000)]
    public string? SalesOrderPoolId { get; set; }

    [StringLength(2000)]
    public string? SalesOrderProcessingStatus { get; set; }

    [StringLength(2000)]
    public string? SalesOrderPromisingMethod { get; set; }

    [StringLength(2000)]
    public string? SalesOrderStatus { get; set; }

    [StringLength(2000)]
    public string? SalesRebateCustomerGroupId { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? SalesUnitId { get; set; }

    [StringLength(2000)]
    public string? ServiceFiscalInformationCode { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierId { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierServiceGroupId { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierServiceId { get; set; }

    [StringLength(2000)]
    public string? TaxExemptNumber { get; set; }

    [StringLength(2000)]
    public string? ThirdPartySalesDigitalPlatform { get; set; }

    [StringLength(2000)]
    public string? ThirdPartySalesDigitalPlatformCNPJ { get; set; }

    [StringLength(2000)]
    public string? TMACustomerGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TotalDiscountAmount { get; set; }

    [StringLength(2000)]
    public string? TotalDiscountCustomerGroupCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TotalDiscountPercentage { get; set; }

    [StringLength(2000)]
    public string? TransportationBrokerId { get; set; }

    [StringLength(36)]
    public string? TransportationDocumentLineId { get; set; }

    [StringLength(2000)]
    public string? TransportationModeId { get; set; }

    [StringLength(2000)]
    public string? TransportationRoutePlanId { get; set; }

    [StringLength(2000)]
    public string? TransportationTemplateId { get; set; }

    [StringLength(2000)]
    public string? URL { get; set; }

    [StringLength(2000)]
    public string? WillAutomaticInventoryReservationConsiderBatchAttributes { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? MTRouteId { get; set; }
}

public partial class SalesOrderHeadersTest : SalesOrderHeadersBase {}

public partial class SalesOrderHeaders : SalesOrderHeadersBase {}
