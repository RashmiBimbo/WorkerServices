﻿using System.ComponentModel.DataAnnotations;

// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using  SalesOrderService.Models;
//
//    var tokenResponse = TokenResponse.FromJson(jsonString);

namespace SalesOrderService.Models
{
    public partial class SalesOrderTestPoco
    {
        public static SalesOrderTestPoco FromJson(string json) => JsonConvert.DeserializeObject<SalesOrderTestPoco>(json, Converter.Settings);
    }
    [PrimaryKey(nameof(DataAreaId), nameof(SalesOrderNumber))]
    public partial class SalesOrderTestPoco
    {
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }

        [JsonProperty("dataAreaId")]
        public string? DataAreaId { get; set; }

        //[Key]
        [JsonProperty("SalesOrderNumber")]
        public string? SalesOrderNumber { get; set; }

        [JsonProperty("CustomerRequisitionNumber")]
        public string? CustomerRequisitionNumber { get; set; }

        [JsonProperty("SalesOrderProcessingStatus")]
        public string? SalesOrderProcessingStatus { get; set; }

        [JsonProperty("OrderTotalAmount")]
        public long? OrderTotalAmount { get; set; }

        [JsonProperty("IntrastatPortId")]
        public string? IntrastatPortId { get; set; }

        [JsonProperty("ContactPersonId")]
        public string? ContactPersonId { get; set; }

        [JsonProperty("CustomersOrderReference")]
        public string? CustomersOrderReference { get; set; }

        [JsonProperty("SkipCreateAutoCharges")]
        public string? SkipCreateAutoCharges { get; set; }

        [JsonProperty("TotalDiscountPercentage")]
        public long? TotalDiscountPercentage { get; set; }

        [JsonProperty("CustomerPaymentFineCode")]
        public string? CustomerPaymentFineCode { get; set; }

        [JsonProperty("IsSalesProcessingStopped")]
        public string? IsSalesProcessingStopped { get; set; }

        [JsonProperty("InventoryReservationMethod")]
        public string? InventoryReservationMethod { get; set; }

        [JsonProperty("IntrastatTransportModeCode")]
        public string? IntrastatTransportModeCode { get; set; }

        [JsonProperty("InvoiceCustomerAccountNumber")]
        public string? InvoiceCustomerAccountNumber { get; set; }

        [JsonProperty("URL")]
        public string? URL { get; set; }

        [JsonProperty("InvoiceAddressCity")]
        public string? InvoiceAddressCity { get; set; }

        [JsonProperty("BankSpecificSymbol")]
        public string? BankSpecificSymbol { get; set; }

        [JsonProperty("BaseDocumentNumber")]
        public string? BaseDocumentNumber { get; set; }

        [JsonProperty("IsFinalUser")]
        public string? IsFinalUser { get; set; }

        [JsonProperty("CFPSCode")]
        public string? CFPSCode { get; set; }

        [JsonProperty("InvoiceAddressStreet")]
        public string? InvoiceAddressStreet { get; set; }

        [JsonProperty("InvoiceAddressCountyId")]
        public string? InvoiceAddressCountyId { get; set; }

        [JsonProperty("DeliveryAddressCountryRegionId")]
        public string? DeliveryAddressCountryRegionId { get; set; }

        [JsonProperty("IsServiceDeliveryAddressBased")]
        public string? IsServiceDeliveryAddressBased { get; set; }

        [JsonProperty("InvoiceAddressDistrictName")]
        public string? InvoiceAddressDistrictName { get; set; }

        [JsonProperty("InvoiceAddressTimeZone")]
        public DateTimeOffset? InvoiceAddressTimeZone { get; set; }

        [JsonProperty("FiscalOperationPresenceType")]
        public string? FiscalOperationPresenceType { get; set; }

        [JsonProperty("MultilineDiscountCustomerGroupCode")]
        public string? MultilineDiscountCustomerGroupCode { get; set; }

        [JsonProperty("IsOwnEntryCertificateIssued")]
        public string? IsOwnEntryCertificateIssued { get; set; }

        [JsonProperty("DeliveryAddressCountyId")]
        public string? DeliveryAddressCountyId { get; set; }

        [JsonProperty("DefaultShippingWarehouseId")]
        public string? DefaultShippingWarehouseId { get; set; }

        [JsonProperty("DeliveryAddressLocationId")]
        public string? DeliveryAddressLocationId { get; set; }

        [JsonProperty("CustomerPaymentMethodName")]
        public string? CustomerPaymentMethodName { get; set; }

        [JsonProperty("SalesUnitId")]
        public string? SalesUnitId { get; set; }

        [JsonProperty("DefaultLedgerDimensionDisplayValue")]
        public string? DefaultLedgerDimensionDisplayValue { get; set; }

        [JsonProperty("DeliveryAddressCountryRegionISOCode")]
        public string? DeliveryAddressCountryRegionISOCode { get; set; }

        [JsonProperty("AreTotalsCalculated")]
        public string? AreTotalsCalculated { get; set; }

        [JsonProperty("TaxExemptNumber")]
        public string? TaxExemptNumber { get; set; }

        [JsonProperty("DeliveryAddressDescription")]
        public string? DeliveryAddressDescription { get; set; }

        [JsonProperty("DeliveryAddressLongitude")]
        public long? DeliveryAddressLongitude { get; set; }

        [JsonProperty("DefaultShippingSiteId")]
        public string? DefaultShippingSiteId { get; set; }

        [JsonProperty("CashDiscountCode")]
        public string? CashDiscountCode { get; set; }

        [JsonProperty("DeliveryReasonCode")]
        public string? DeliveryReasonCode { get; set; }

        [JsonProperty("TotalDiscountCustomerGroupCode")]
        public string? TotalDiscountCustomerGroupCode { get; set; }

        [JsonProperty("CampaignId")]
        public string? CampaignId { get; set; }

        [JsonProperty("OrderTotalDiscountAmount")]
        public long? OrderTotalDiscountAmount { get; set; }

        [JsonProperty("PaymentTermsName")]
        public string? PaymentTermsName { get; set; }

        [JsonProperty("ShippingCarrierServiceGroupId")]
        public string? ShippingCarrierServiceGroupId { get; set; }

        [JsonProperty("CIPEcode")]
        public string? CIPEcode { get; set; }

        [JsonProperty("RequestedReceiptDate")]
        public DateTimeOffset? RequestedReceiptDate { get; set; }

        [JsonProperty("ConfirmedReceiptDate")]
        public DateTimeOffset? ConfirmedReceiptDate { get; set; }

        [JsonProperty("BaseDocumentDate")]
        public DateTimeOffset? BaseDocumentDate { get; set; }

        [JsonProperty("EInvoiceDimensionAccountCode")]
        public string? EInvoiceDimensionAccountCode { get; set; }

        [JsonProperty("OrderingCustomerAccountNumber")]
        public string? OrderingCustomerAccountNumber { get; set; }

        [JsonProperty("OrderTotalChargesAmount")]
        public long? OrderTotalChargesAmount { get; set; }

        [JsonProperty("SalesRebateCustomerGroupId")]
        public string? SalesRebateCustomerGroupId { get; set; }

        [JsonProperty("TransportationBrokerId")]
        public string? TransportationBrokerId { get; set; }

        [JsonProperty("DirectDebitMandateId")]
        public string? DirectDebitMandateId { get; set; }

        [JsonProperty("CreditNoteReasonCode")]
        public string? CreditNoteReasonCode { get; set; }

        [JsonProperty("IntrastatStatisticsProcedureCode")]
        public string? IntrastatStatisticsProcedureCode { get; set; }

        [JsonProperty("TMACustomerGroupId")]
        public string? TMACustomerGroupId { get; set; }

        [JsonProperty("ArePricesIncludingSalesTax")]
        public string? ArePricesIncludingSalesTax { get; set; }

        [JsonProperty("IsExportSale")]
        public string? IsExportSale { get; set; }

        [JsonProperty("InvoicePaymentAttachmentType")]
        public string? InvoicePaymentAttachmentType { get; set; }

        [JsonProperty("ReportingCurrencyFixedExchangeRate")]
        public long? ReportingCurrencyFixedExchangeRate { get; set; }

        [JsonProperty("IsDeliveryAddressPrivate")]
        public string? IsDeliveryAddressPrivate { get; set; }

        [JsonProperty("DeliveryAddressCity")]
        public string? DeliveryAddressCity { get; set; }

        [JsonProperty("DeliveryAddressStreet")]
        public string? DeliveryAddressStreet { get; set; }

        [JsonProperty("NumberSequenceGroupId")]
        public string? NumberSequenceGroupId { get; set; }

        [JsonProperty("OrderTotalTaxAmount")]
        public long? OrderTotalTaxAmount { get; set; }

        [JsonProperty("DeliveryTermsCode")]
        public string? DeliveryTermsCode { get; set; }

        [JsonProperty("ChargeCustomerGroupId")]
        public string? ChargeCustomerGroupId { get; set; }

        [JsonProperty("WillAutomaticInventoryReservationConsiderBatchAttributes")]
        public string? WillAutomaticInventoryReservationConsiderBatchAttributes { get; set; }

        [JsonProperty("SalesTaxGroupCode")]
        public string? SalesTaxGroupCode { get; set; }

        [JsonProperty("IsInvoiceAddressPrivate")]
        public string? IsInvoiceAddressPrivate { get; set; }

        [JsonProperty("ThirdPartySalesDigitalPlatformCNPJ")]
        public string? ThirdPartySalesDigitalPlatformCNPJ { get; set; }

        [JsonProperty("OrderHeaderTaxAmount")]
        public long? OrderHeaderTaxAmount { get; set; }

        [JsonProperty("FiscalDocumentOperationTypeId")]
        public string? FiscalDocumentOperationTypeId { get; set; }

        [JsonProperty("OrderCreationDateTime")]
        public DateTimeOffset? OrderCreationDateTime { get; set; }

        [JsonProperty("SalesOrderOriginCode")]
        public string? SalesOrderOriginCode { get; set; }

        [JsonProperty("ServiceFiscalInformationCode")]
        public string? ServiceFiscalInformationCode { get; set; }

        [JsonProperty("DeliveryAddressStateId")]
        public string? DeliveryAddressStateId { get; set; }

        [JsonProperty("FulfillmentPolicyName")]
        public string? FulfillmentPolicyName { get; set; }

        [JsonProperty("CommissionSalesRepresentativeGroupId")]
        public string? CommissionSalesRepresentativeGroupId { get; set; }

        [JsonProperty("CustomerPostingProfileId")]
        public string? CustomerPostingProfileId { get; set; }

        [JsonProperty("CustomerTransactionSettlementType")]
        public string? CustomerTransactionSettlementType { get; set; }

        [JsonProperty("BaseDocumentItemNumber")]
        public string? BaseDocumentItemNumber { get; set; }

        [JsonProperty("TransportationDocumentLineId")]
        public Guid TransportationDocumentLineId { get; set; }

        [JsonProperty("DeliveryAddressStreetInKana")]
        public string? DeliveryAddressStreetInKana { get; set; }

        [JsonProperty("CustomerPaymentFinancialInterestCode")]
        public string? CustomerPaymentFinancialInterestCode { get; set; }

        [JsonProperty("PaymentScheduleName")]
        public string? PaymentScheduleName { get; set; }

        [JsonProperty("InvoiceAddressStreetNumber")]
        public string? InvoiceAddressStreetNumber { get; set; }

        [JsonProperty("SalesOrderStatus")]
        public string? SalesOrderStatus { get; set; }

        [JsonProperty("PaymentTermsBaseDate")]
        public DateTimeOffset? PaymentTermsBaseDate { get; set; }

        [JsonProperty("ShippingCarrierId")]
        public string? ShippingCarrierId { get; set; }

        [JsonProperty("InvoiceAddressPostBox")]
        public string? InvoiceAddressPostBox { get; set; }

        [JsonProperty("ConfirmedShippingDate")]
        public DateTimeOffset? ConfirmedShippingDate { get; set; }

        [JsonProperty("TenderCode")]
        public string? TenderCode { get; set; }

        [JsonProperty("DeliveryAddressDunsNumber")]
        public string? DeliveryAddressDunsNumber { get; set; }

        [JsonProperty("IsEntryCertificateRequired")]
        public string? IsEntryCertificateRequired { get; set; }

        [JsonProperty("ThirdPartySalesDigitalPlatform")]
        public string? ThirdPartySalesDigitalPlatform { get; set; }

        [JsonProperty("DeliveryAddressDistrictName")]
        public string? DeliveryAddressDistrictName { get; set; }

        [JsonProperty("SalesOrderPromisingMethod")]
        public string? SalesOrderPromisingMethod { get; set; }

        [JsonProperty("DeliveryModeCode")]
        //[JsonConverter(typeof(ParseStringConverter<long>))]
        public long? DeliveryModeCode { get; set; }

        [JsonProperty("BaseDocumentLineNumber")]
        public long? BaseDocumentLineNumber { get; set; }

        [JsonProperty("TransportationModeId")]
        public string? TransportationModeId { get; set; }

        [JsonProperty("SalesOrderName")]
        public string? SalesOrderName { get; set; }

        [JsonProperty("DeliveryAddressStreetNumber")]
        public string? DeliveryAddressStreetNumber { get; set; }

        [JsonProperty("InvoiceAddressLongitude")]
        public long? InvoiceAddressLongitude { get; set; }

        [JsonProperty("InvoiceAddressLatitude")]
        public long? InvoiceAddressLatitude { get; set; }

        [JsonProperty("BaseDocumentType")]
        public string? BaseDocumentType { get; set; }

        [JsonProperty("SalesOrderPoolId")]
        public string? SalesOrderPoolId { get; set; }

        [JsonProperty("FormattedInvoiceAddress")]
        public string? FormattedInvoiceAddress { get; set; }

        [JsonProperty("CustomerPaymentMethodSpecificationName")]
        public string? CustomerPaymentMethodSpecificationName { get; set; }

        [JsonProperty("CurrencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("FormattedDelveryAddress")]
        public string? FormattedDelveryAddress { get; set; }

        [JsonProperty("BankConstantSymbol")]
        public string? BankConstantSymbol { get; set; }

        [JsonProperty("PriceCustomerGroupCode")]
        public string? PriceCustomerGroupCode { get; set; }

        [JsonProperty("DeliveryAddressTimeZone")]
        public DateTimeOffset? DeliveryAddressTimeZone { get; set; }

        [JsonProperty("FullRunCTPStatus")]
        public string? FullRunCTPStatus { get; set; }

        [JsonProperty("Email")]
        public string? Email { get; set; }

        [JsonProperty("InvoiceAddressCityInKana")]
        public string? InvoiceAddressCityInKana { get; set; }

        [JsonProperty("InvoiceAddressCountryRegionISOCode")]
        public string? InvoiceAddressCountryRegionISOCode { get; set; }

        [JsonProperty("TransportationTemplateId")]
        public string? TransportationTemplateId { get; set; }

        [JsonProperty("IsConsolidatedInvoiceTarget")]
        public string? IsConsolidatedInvoiceTarget { get; set; }

        [JsonProperty("OrderOrAgreementCode")]
        public string? OrderOrAgreementCode { get; set; }

        [JsonProperty("TransportationRoutePlanId")]
        public string? TransportationRoutePlanId { get; set; }

        [JsonProperty("FixedDueDate")]
        public DateTimeOffset? FixedDueDate { get; set; }

        [JsonProperty("DeliveryAddressName")]
        public string? DeliveryAddressName { get; set; }

        [JsonProperty("ExportReason")]
        public string? ExportReason { get; set; }

        [JsonProperty("FixedExchangeRate")]
        public long? FixedExchangeRate { get; set; }

        [JsonProperty("IntrastatTransactionCode")]
        public string? IntrastatTransactionCode { get; set; }

        [JsonProperty("InvoiceAddressStreetInKana")]
        public string? InvoiceAddressStreetInKana { get; set; }

        [JsonProperty("InvoiceBuildingCompliment")]
        public string? InvoiceBuildingCompliment { get; set; }

        [JsonProperty("InvoiceAddressZipCode")]
        public string? InvoiceAddressZipCode { get; set; }

        [JsonProperty("TotalDiscountAmount")]
        public long? TotalDiscountAmount { get; set; }

        [JsonProperty("ShippingCarrierServiceId")]
        public string? ShippingCarrierServiceId { get; set; }

        [JsonProperty("IsOneTimeCustomer")]
        public string? IsOneTimeCustomer { get; set; }

        [JsonProperty("DeliveryAddressZipCode")]
        //[JsonConverter(typeof(ParseStringConverter<long>))]
        public long? DeliveryAddressZipCode { get; set; }

        [JsonProperty("OrderTakerPersonnelNumber")]
        public string? OrderTakerPersonnelNumber { get; set; }

        [JsonProperty("DeliveryAddressCityInKana")]
        public string? DeliveryAddressCityInKana { get; set; }

        [JsonProperty("DeliveryAddressPostBox")]
        public string? DeliveryAddressPostBox { get; set; }

        [JsonProperty("IsDeliveryAddressOrderSpecific")]
        public string? IsDeliveryAddressOrderSpecific { get; set; }

        [JsonProperty("InvoiceAddressStateId")]
        public string? InvoiceAddressStateId { get; set; }

        [JsonProperty("RequestedShippingDate")]
        public DateTimeOffset? RequestedShippingDate { get; set; }

        [JsonProperty("DeliveryAddressLatitude")]
        public long? DeliveryAddressLatitude { get; set; }

        [JsonProperty("DeliveryBuildingCompliment")]
        public string? DeliveryBuildingCompliment { get; set; }

        [JsonProperty("InvoiceAddressCountryRegionId")]
        public string? InvoiceAddressCountryRegionId { get; set; }

        [JsonProperty("IsEInvoiceDimensionAccountCodeSpecifiedPerLine")]
        public string? IsEInvoiceDimensionAccountCodeSpecifiedPerLine { get; set; }

        [JsonProperty("InvoiceType")]
        public string? InvoiceType { get; set; }

        [JsonProperty("EUSalesListCode")]
        public string? EUSalesListCode { get; set; }

        [JsonProperty("ProjectId")]
        public string? ProjectId { get; set; }

        [JsonProperty("OverrideSalesTax")]
        public string? OverrideSalesTax { get; set; }

        [JsonProperty("QuotationNumber")]
        public string? QuotationNumber { get; set; }

        [JsonProperty("OrderResponsiblePersonnelNumber")]
        public string? OrderResponsiblePersonnelNumber { get; set; }

        [JsonProperty("CommissionCustomerGroupId")]
        public string? CommissionCustomerGroupId { get; set; }

        [JsonProperty("LanguageId")]
        public string? LanguageId { get; set; }

        [JsonProperty("LineDiscountCustomerGroupCode")]
        public string? LineDiscountCustomerGroupCode { get; set; }

        [JsonProperty("ShippingCarrierCustomerAccountNumber")]
        public string? ShippingCarrierCustomerAccountNumber { get; set; }

        [JsonProperty("SubBillCreatedFromSubscriptionBilling")]
        public string? SubBillCreatedFromSubscriptionBilling { get; set; }

        [JsonProperty("RevRecReallocationId")]
        public string? RevRecReallocationId { get; set; }

        [JsonProperty("RevRecFollowOriginalPricingMethod")]
        public string? RevRecFollowOriginalPricingMethod { get; set; }

        [JsonProperty("RevRecMultipleSOReallocation")]
        public string? RevRecMultipleSOReallocation { get; set; }

        [JsonProperty("RevRecContractEndDate")]
        public DateTimeOffset? RevRecContractEndDate { get; set; }

        [JsonProperty("RevRecLatestReverseJournal")]
        public long? RevRecLatestReverseJournal { get; set; }

        [JsonProperty("RevRecContractStartDate")]
        public DateTimeOffset? RevRecContractStartDate { get; set; }

        [JsonProperty("SkipGlobalUnifiedPricingCalculation")]
        public string? SkipGlobalUnifiedPricingCalculation { get; set; }

    }

}
