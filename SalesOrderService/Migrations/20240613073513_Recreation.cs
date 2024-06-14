using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesOrderService.Migrations
{
    /// <inheritdoc />
    public partial class Recreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Value");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrderTestPoco",
                table: "SalesOrderTestPoco");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SalesOrderTestPoco");

            migrationBuilder.DropColumn(
                name: "OdataContext",
                table: "SalesOrderTestPoco");

            migrationBuilder.AlterColumn<string>(
                name: "SalesOrderNumber",
                table: "SalesOrderTestPoco",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataAreaId",
                table: "SalesOrderTestPoco",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrderTestPoco",
                table: "SalesOrderTestPoco",
                columns: new[] { "DataAreaId", "SalesOrderNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrderTestPoco",
                table: "SalesOrderTestPoco");

            migrationBuilder.AlterColumn<string>(
                name: "SalesOrderNumber",
                table: "SalesOrderTestPoco",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DataAreaId",
                table: "SalesOrderTestPoco",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SalesOrderTestPoco",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "OdataContext",
                table: "SalesOrderTestPoco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrderTestPoco",
                table: "SalesOrderTestPoco",
                column: "Id");

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
                name: "Value",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArePricesIncludingSalesTax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreTotalsCalculated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankConstantSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankSpecificSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseDocumentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BaseDocumentItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseDocumentLineNumber = table.Column<long>(type: "bigint", nullable: false),
                    BaseDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseDocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashDiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CfpsCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargeCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CipEcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionSalesRepresentativeGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmedReceiptDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ConfirmedShippingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ContactPersonId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    CreditNoteReasonCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPaymentFinancialInterestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPaymentFineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPaymentMethodSpecificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPostingProfileId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerRequisitionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerTransactionSettlementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomersOrderReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAreaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultLedgerDimensionDisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultShippingSiteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultShippingWarehouseId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCityInKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCountryRegionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCountryRegionIsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCountyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressDunsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressLatitude = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryAddressLocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressLongitude = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryAddressName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressPostBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStreetInKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressTimeZone = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeliveryAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryBuildingCompliment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryModeCode = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryReasonCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTermsCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectDebitMandateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EInvoiceDimensionAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EuSalesListCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExportReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiscalDocumentOperationTypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiscalOperationPresenceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FixedDueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FixedExchangeRate = table.Column<long>(type: "bigint", nullable: false),
                    FormattedDelveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormattedInvoiceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FulfillmentPolicyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullRunCtpStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntrastatPortId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntrastatStatisticsProcedureCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntrastatTransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntrastatTransportModeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryReservationMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCityInKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountryRegionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountryRegionIsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressLatitude = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceAddressLongitude = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceAddressPostBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStreetInKana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressTimeZone = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    InvoiceAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceBuildingCompliment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoicePaymentAttachmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConsolidatedInvoiceTarget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeliveryAddressOrderSpecific = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeliveryAddressPrivate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEInvoiceDimensionAccountCodeSpecifiedPerLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEntryCertificateRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExportSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFinalUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInvoiceAddressPrivate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOneTimeCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOwnEntryCertificateIssued = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSalesProcessingStopped = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsServiceDeliveryAddressBased = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultilineDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberSequenceGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdataEtag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCreationDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    OrderHeaderTaxAmount = table.Column<long>(type: "bigint", nullable: false),
                    OrderOrAgreementCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderResponsiblePersonnelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTakerPersonnelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTotalAmount = table.Column<long>(type: "bigint", nullable: false),
                    OrderTotalChargesAmount = table.Column<long>(type: "bigint", nullable: false),
                    OrderTotalDiscountAmount = table.Column<long>(type: "bigint", nullable: false),
                    OrderTotalTaxAmount = table.Column<long>(type: "bigint", nullable: false),
                    OrderingCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverrideSalesTax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTermsBaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PaymentTermsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportingCurrencyFixedExchangeRate = table.Column<long>(type: "bigint", nullable: false),
                    RequestedReceiptDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RequestedShippingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RevRecContractEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RevRecContractStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RevRecFollowOriginalPricingMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevRecLatestReverseJournal = table.Column<long>(type: "bigint", nullable: false),
                    RevRecMultipleSoReallocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevRecReallocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderOriginCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderPoolId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderProcessingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderPromisingMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesRebateCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesTaxGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesUnitId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceFiscalInformationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingCarrierCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingCarrierId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingCarrierServiceGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingCarrierServiceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkipCreateAutoCharges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkipGlobalUnifiedPricingCalculation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubBillCreatedFromSubscriptionBilling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxExemptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdPartySalesDigitalPlatform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdPartySalesDigitalPlatformCnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TmaCustomerGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDiscountAmount = table.Column<long>(type: "bigint", nullable: false),
                    TotalDiscountCustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDiscountPercentage = table.Column<long>(type: "bigint", nullable: false),
                    TransportationBrokerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationDocumentLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportationModeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationRoutePlanId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationTemplateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WillAutomaticInventoryReservationConsiderBatchAttributes = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
