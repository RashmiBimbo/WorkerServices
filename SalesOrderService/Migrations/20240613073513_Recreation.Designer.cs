﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesOrderService;

#nullable disable

namespace SalesOrderService.Migrations
{
    [DbContext(typeof(SalesOrderContext))]
    [Migration("20240613073513_Recreation")]
    partial class Recreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalesOrderService.Models.SalesOrderTestPoco", b =>
                {
                    b.Property<string>("DataAreaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SalesOrderNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArePricesIncludingSalesTax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AreTotalsCalculated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankConstantSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankSpecificSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("BaseDocumentDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("BaseDocumentItemNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BaseDocumentLineNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("BaseDocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaseDocumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CFPSCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CIPEcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampaignId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CashDiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChargeCustomerGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommissionCustomerGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommissionSalesRepresentativeGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ConfirmedReceiptDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("ConfirmedShippingDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ContactPersonId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditNoteReasonCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPaymentFinancialInterestCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPaymentFineCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPaymentMethodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPaymentMethodSpecificationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPostingProfileId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerRequisitionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerTransactionSettlementType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomersOrderReference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultLedgerDimensionDisplayValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultShippingSiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultShippingWarehouseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressCityInKana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressCountryRegionISOCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressCountryRegionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressCountyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressDistrictName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressDunsNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeliveryAddressLatitude")
                        .HasColumnType("bigint");

                    b.Property<string>("DeliveryAddressLocationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeliveryAddressLongitude")
                        .HasColumnType("bigint");

                    b.Property<string>("DeliveryAddressName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressPostBox")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressStateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressStreetInKana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddressStreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeliveryAddressTimeZone")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("DeliveryAddressZipCode")
                        .HasColumnType("bigint");

                    b.Property<string>("DeliveryBuildingCompliment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeliveryModeCode")
                        .HasColumnType("bigint");

                    b.Property<string>("DeliveryReasonCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryTermsCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectDebitMandateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EInvoiceDimensionAccountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EUSalesListCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExportReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiscalDocumentOperationTypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiscalOperationPresenceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("FixedDueDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("FixedExchangeRate")
                        .HasColumnType("bigint");

                    b.Property<string>("FormattedDelveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormattedInvoiceAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FulfillmentPolicyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullRunCTPStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntrastatPortId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntrastatStatisticsProcedureCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntrastatTransactionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntrastatTransportModeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryReservationMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressCityInKana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressCountryRegionISOCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressCountryRegionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressCountyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressDistrictName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("InvoiceAddressLatitude")
                        .HasColumnType("bigint");

                    b.Property<long?>("InvoiceAddressLongitude")
                        .HasColumnType("bigint");

                    b.Property<string>("InvoiceAddressPostBox")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressStateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressStreetInKana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceAddressStreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("InvoiceAddressTimeZone")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("InvoiceAddressZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceBuildingCompliment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceCustomerAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoicePaymentAttachmentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsConsolidatedInvoiceTarget")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsDeliveryAddressOrderSpecific")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsDeliveryAddressPrivate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsEInvoiceDimensionAccountCodeSpecifiedPerLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsEntryCertificateRequired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsExportSale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsFinalUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsInvoiceAddressPrivate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsOneTimeCustomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsOwnEntryCertificateIssued")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsSalesProcessingStopped")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsServiceDeliveryAddressBased")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineDiscountCustomerGroupCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MultilineDiscountCustomerGroupCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberSequenceGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OdataEtag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("OrderCreationDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("OrderHeaderTaxAmount")
                        .HasColumnType("bigint");

                    b.Property<string>("OrderOrAgreementCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderResponsiblePersonnelNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderTakerPersonnelNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderTotalAmount")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderTotalChargesAmount")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderTotalDiscountAmount")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderTotalTaxAmount")
                        .HasColumnType("bigint");

                    b.Property<string>("OrderingCustomerAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverrideSalesTax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentScheduleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("PaymentTermsBaseDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PaymentTermsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceCustomerGroupCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuotationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ReportingCurrencyFixedExchangeRate")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("RequestedReceiptDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("RequestedShippingDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("RevRecContractEndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("RevRecContractStartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RevRecFollowOriginalPricingMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RevRecLatestReverseJournal")
                        .HasColumnType("bigint");

                    b.Property<string>("RevRecMultipleSOReallocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RevRecReallocationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesOrderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesOrderOriginCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesOrderPoolId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesOrderProcessingStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesOrderPromisingMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesOrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesRebateCustomerGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesTaxGroupCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesUnitId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceFiscalInformationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingCarrierCustomerAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingCarrierId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingCarrierServiceGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingCarrierServiceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkipCreateAutoCharges")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkipGlobalUnifiedPricingCalculation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubBillCreatedFromSubscriptionBilling")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TMACustomerGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxExemptNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenderCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPartySalesDigitalPlatform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPartySalesDigitalPlatformCNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TotalDiscountAmount")
                        .HasColumnType("bigint");

                    b.Property<string>("TotalDiscountCustomerGroupCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TotalDiscountPercentage")
                        .HasColumnType("bigint");

                    b.Property<string>("TransportationBrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TransportationDocumentLineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransportationModeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportationRoutePlanId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportationTemplateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WillAutomaticInventoryReservationConsiderBatchAttributes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataAreaId", "SalesOrderNumber");

                    b.ToTable("SalesOrderTestPoco");
                });
#pragma warning restore 612, 618
        }
    }
}
