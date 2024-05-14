﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrderService.Migrations
{
    /// <inheritdoc />
    public partial class MSSQLLocalDB_Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdataContext = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderTestPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdataContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdataEtag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAreaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerRequisitionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderProcessingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotalAmount = table.Column<long>(type: "bigint", nullable: false),
                    IntrastatPortId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersOrderReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkipCreateAutoCharges = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDiscountPercentage = table.Column<long>(type: "bigint", nullable: false),
                    CustomerPaymentFineCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSalesProcessingStopped = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryReservationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntrastatTransportModeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankSpecificSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFinalUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CFPSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCountyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressCountryRegionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsServiceDeliveryAddressBased = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressTimeZone = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FiscalOperationPresenceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MultilineDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOwnEntryCertificateIssued = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressCountyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultShippingWarehouseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressLocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesUnitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultLedgerDimensionDisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressCountryRegionISOCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreTotalsCalculated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxExemptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressLongitude = table.Column<long>(type: "bigint", nullable: false),
                    DefaultShippingSiteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashDiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryReasonCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotalDiscountAmount = table.Column<long>(type: "bigint", nullable: false),
                    PaymentTermsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingCarrierServiceGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIPEcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedReceiptDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ConfirmedReceiptDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    BaseDocumentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EInvoiceDimensionAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderingCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotalChargesAmount = table.Column<long>(type: "bigint", nullable: false),
                    SalesRebateCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportationBrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectDebitMandateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditNoteReasonCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntrastatStatisticsProcedureCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TMACustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArePricesIncludingSalesTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExportSale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicePaymentAttachmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingCurrencyFixedExchangeRate = table.Column<long>(type: "bigint", nullable: false),
                    IsDeliveryAddressPrivate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberSequenceGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotalTaxAmount = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryTermsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WillAutomaticInventoryReservationConsiderBatchAttributes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesTaxGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInvoiceAddressPrivate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdPartySalesDigitalPlatformCNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderHeaderTaxAmount = table.Column<long>(type: "bigint", nullable: false),
                    FiscalDocumentOperationTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderCreationDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SalesOrderOriginCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceFiscalInformationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressStateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FulfillmentPolicyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionSalesRepresentativeGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPostingProfileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerTransactionSettlementType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseDocumentItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportationDocumentLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryAddressStreetInKana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPaymentFinancialInterestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTermsBaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ShippingCarrierId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressPostBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmedShippingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TenderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressDunsNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEntryCertificateRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdPartySalesDigitalPlatform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderPromisingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryModeCode = table.Column<long>(type: "bigint", nullable: false),
                    BaseDocumentLineNumber = table.Column<long>(type: "bigint", nullable: false),
                    TransportationModeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressLongitude = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceAddressLatitude = table.Column<long>(type: "bigint", nullable: false),
                    BaseDocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderPoolId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormattedInvoiceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPaymentMethodSpecificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormattedDelveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankConstantSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressTimeZone = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FullRunCTPStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCityInKana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCountryRegionISOCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportationTemplateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConsolidatedInvoiceTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderOrAgreementCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportationRoutePlanId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixedDueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryAddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixedExchangeRate = table.Column<long>(type: "bigint", nullable: false),
                    IntrastatTransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressStreetInKana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceBuildingCompliment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDiscountAmount = table.Column<long>(type: "bigint", nullable: false),
                    ShippingCarrierServiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOneTimeCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressZipCode = table.Column<long>(type: "bigint", nullable: false),
                    OrderTakerPersonnelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressCityInKana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressPostBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeliveryAddressOrderSpecific = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressStateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedShippingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeliveryAddressLatitude = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryBuildingCompliment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCountryRegionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEInvoiceDimensionAccountCodeSpecifiedPerLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EUSalesListCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverrideSalesTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderResponsiblePersonnelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingCarrierCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubBillCreatedFromSubscriptionBilling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevRecReallocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevRecFollowOriginalPricingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevRecMultipleSOReallocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevRecContractEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RevRecLatestReverseJournal = table.Column<long>(type: "bigint", nullable: false),
                    RevRecContractStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SkipGlobalUnifiedPricingCalculation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JsonPoco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Value",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdataEtag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAreaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerRequisitionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderProcessingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTotalAmount = table.Column<long>(type: "bigint", nullable: false),
                    IntrastatPortId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomersOrderReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkipCreateAutoCharges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDiscountPercentage = table.Column<long>(type: "bigint", nullable: false),
                    CustomerPaymentFineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSalesProcessingStopped = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryReservationMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntrastatTransportModeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankSpecificSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFinalUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CfpsCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCountryRegionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsServiceDeliveryAddressBased = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressTimeZone = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FiscalOperationPresenceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultilineDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOwnEntryCertificateIssued = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCountyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultShippingWarehouseId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressLocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesUnitId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultLedgerDimensionDisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCountryRegionIsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreTotalsCalculated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxExemptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressLongitude = table.Column<long>(type: "bigint", nullable: false),
                    DefaultShippingSiteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashDiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryReasonCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTotalDiscountAmount = table.Column<long>(type: "bigint", nullable: false),
                    PaymentTermsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingCarrierServiceGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CipEcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedReceiptDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ConfirmedReceiptDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BaseDocumentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EInvoiceDimensionAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderingCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTotalChargesAmount = table.Column<long>(type: "bigint", nullable: false),
                    SalesRebateCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationBrokerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectDebitMandateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditNoteReasonCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntrastatStatisticsProcedureCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TmaCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArePricesIncludingSalesTax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExportSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoicePaymentAttachmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportingCurrencyFixedExchangeRate = table.Column<long>(type: "bigint", nullable: false),
                    IsDeliveryAddressPrivate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberSequenceGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTotalTaxAmount = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryTermsCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargeCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WillAutomaticInventoryReservationConsiderBatchAttributes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesTaxGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInvoiceAddressPrivate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdPartySalesDigitalPlatformCnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderHeaderTaxAmount = table.Column<long>(type: "bigint", nullable: false),
                    FiscalDocumentOperationTypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCreationDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SalesOrderOriginCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceFiscalInformationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FulfillmentPolicyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionSalesRepresentativeGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPostingProfileId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerTransactionSettlementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseDocumentItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationDocumentLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryAddressStreetInKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPaymentFinancialInterestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTermsBaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ShippingCarrierId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressPostBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmedShippingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TenderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressDunsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEntryCertificateRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdPartySalesDigitalPlatform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderPromisingMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryModeCode = table.Column<long>(type: "bigint", nullable: false),
                    BaseDocumentLineNumber = table.Column<long>(type: "bigint", nullable: false),
                    TransportationModeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressLongitude = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceAddressLatitude = table.Column<long>(type: "bigint", nullable: false),
                    BaseDocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderPoolId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormattedInvoiceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPaymentMethodSpecificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormattedDelveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankConstantSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressTimeZone = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FullRunCtpStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCityInKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountryRegionIsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationTemplateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConsolidatedInvoiceTarget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderOrAgreementCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationRoutePlanId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FixedDueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeliveryAddressName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExportReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FixedExchangeRate = table.Column<long>(type: "bigint", nullable: false),
                    IntrastatTransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStreetInKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceBuildingCompliment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDiscountAmount = table.Column<long>(type: "bigint", nullable: false),
                    ShippingCarrierServiceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOneTimeCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTakerPersonnelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCityInKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressPostBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeliveryAddressOrderSpecific = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedShippingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeliveryAddressLatitude = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryBuildingCompliment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountryRegionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEInvoiceDimensionAccountCodeSpecifiedPerLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EuSalesListCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverrideSalesTax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderResponsiblePersonnelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingCarrierCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubBillCreatedFromSubscriptionBilling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevRecReallocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevRecFollowOriginalPricingMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevRecMultipleSoReallocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevRecContractEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RevRecLatestReverseJournal = table.Column<long>(type: "bigint", nullable: false),
                    RevRecContractStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SkipGlobalUnifiedPricingCalculation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Value", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Value_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Value_ContentId",
                table: "Value",
                column: "ContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrderTestPoco");

            migrationBuilder.DropTable(
                name: "Value");

            migrationBuilder.DropTable(
                name: "Content");
        }
    }
}