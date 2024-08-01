using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("DataAreaId", "PurchaseOrderNumber")]
[Table("PurchaseOrderHeadersV2")]
public partial class PurchaseOrderHeadersV2Test
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [Column("dataAreaId")]
    [StringLength(255)]
    public string DataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string PurchaseOrderNumber { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? AccountingDate { get; set; }

    [StringLength(2000)]
    public string? AccountingDistributionTemplateName { get; set; }

    [StringLength(2000)]
    public string? ArePricesIncludingSalesTax { get; set; }

    [StringLength(2000)]
    public string? AttentionInformation { get; set; }

    [StringLength(2000)]
    public string? BankDocumentType { get; set; }

    [StringLength(2000)]
    public string? BuyerGroupId { get; set; }

    [StringLength(2000)]
    public string? CashDiscountCode { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CashDiscountPercentage { get; set; }

    [StringLength(2000)]
    public string? ChargeVendorGroupId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedDeliveryDate { get; set; }

    [StringLength(2000)]
    public string? ConfirmingPurchaseOrderCode { get; set; }

    [StringLength(2000)]
    public string? ConfirmingPurchaseOrderCodeLanguageId { get; set; }

    [StringLength(2000)]
    public string? ContactPersonId { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DefaultReceivingSiteId { get; set; }

    [StringLength(2000)]
    public string? DefaultReceivingWarehouseId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCity { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionId { get; set; }

    [Column("DeliveryAddressCountryRegionISOCode")]
    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionIsocode { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDescription { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDunsNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? DeliveryAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressLocationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
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
    public string? DeliveryCityInKana { get; set; }

    [StringLength(2000)]
    public string? DeliveryModeId { get; set; }

    [StringLength(2000)]
    public string? DeliveryStreetInKana { get; set; }

    [StringLength(2000)]
    public string? DeliveryTermsId { get; set; }

    [StringLength(2000)]
    public string? DocumentApprovalStatus { get; set; }

    [StringLength(2000)]
    public string? Email { get; set; }

    [Column("EUSalesListCode")]
    [StringLength(2000)]
    public string? EusalesListCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpectedCrossDockingDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpectedStoreAvailableSalesDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpectedStoreReceiptDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FixedDueDate { get; set; }

    [StringLength(2000)]
    public string? FormattedDeliveryAddress { get; set; }

    [StringLength(2000)]
    public string? FormattedInvoiceAddress { get; set; }

    [Column("GSTSelfBilledInvoiceApprovalNumber")]
    [StringLength(2000)]
    public string? GstselfBilledInvoiceApprovalNumber { get; set; }

    [StringLength(2000)]
    public string? ImportDeclarationNumber { get; set; }

    [StringLength(2000)]
    public string? IntrastatPortId { get; set; }

    [StringLength(2000)]
    public string? IntrastatStatisticsProcedureCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransactionCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransportModeCode { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCity { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressCounty { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressState { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStreet { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? InvoiceAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? InvoiceType { get; set; }

    [StringLength(2000)]
    public string? InvoiceVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? IsChangeManagementActive { get; set; }

    [StringLength(2000)]
    public string? IsConsolidatedInvoiceTarget { get; set; }

    [StringLength(2000)]
    public string? IsDeliveredDirectly { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressOrderSpecific { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressPrivate { get; set; }

    [StringLength(2000)]
    public string? IsOneTimeVendor { get; set; }

    [StringLength(2000)]
    public string? LanguageId { get; set; }

    [StringLength(2000)]
    public string? LineDiscountVendorGroupCode { get; set; }

    [StringLength(2000)]
    public string? MultilineDiscountVendorGroupCode { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroupId { get; set; }

    [StringLength(2000)]
    public string? OrdererPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? OrderVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? PaymentScheduleName { get; set; }

    [StringLength(2000)]
    public string? PaymentTermsName { get; set; }

    [StringLength(2000)]
    public string? PriceVendorGroupCode { get; set; }

    [StringLength(2000)]
    public string? ProjectId { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderHeaderCreationMethod { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderName { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderPoolId { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderStatus { get; set; }

    [StringLength(2000)]
    public string? PurchaseRebateVendorGroupId { get; set; }

    [StringLength(2000)]
    public string? ReasonCode { get; set; }

    [StringLength(2000)]
    public string? ReasonComment { get; set; }

    [StringLength(2000)]
    public string? ReplenishmentServiceCategoryId { get; set; }

    [StringLength(2000)]
    public string? ReplenishmentWarehouseId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedDeliveryDate { get; set; }

    [StringLength(2000)]
    public string? RequesterPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierId { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierServiceGroupId { get; set; }

    [StringLength(2000)]
    public string? ShippingCarrierServiceId { get; set; }

    [StringLength(2000)]
    public string? TaxExemptNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TotalDiscountPercentage { get; set; }

    [StringLength(2000)]
    public string? TotalDiscountVendorGroupCode { get; set; }

    [StringLength(36)]
    public string? TransportationDocumentLineId { get; set; }

    [StringLength(2000)]
    public string? TransportationModeId { get; set; }

    [StringLength(2000)]
    public string? TransportationRoutePlanId { get; set; }

    [StringLength(2000)]
    public string? TransportationTemplateId { get; set; }

    [Column("URL")]
    [StringLength(2000)]
    public string? Url { get; set; }

    [StringLength(2000)]
    public string? VendorInvoiceDeclarationId { get; set; }

    [StringLength(2000)]
    public string? VendorOrderReference { get; set; }

    [StringLength(2000)]
    public string? VendorPaymentMethodName { get; set; }

    [StringLength(2000)]
    public string? VendorPaymentMethodSpecificationName { get; set; }

    [StringLength(2000)]
    public string? VendorPostingProfileId { get; set; }

    [StringLength(2000)]
    public string? VendorTransactionSettlementType { get; set; }

    [StringLength(2000)]
    public string? ZakatContractNumber { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesTax { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? TradeEndCustomerAccount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedShipDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedShipDate { get; set; }

    [StringLength(2000)]
    public string? ShipCalendarId { get; set; }

    public long? MatchingAgreement { get; set; }

    [StringLength(2000)]
    public string? FiscalDocumentOperationTypeId { get; set; }
}
