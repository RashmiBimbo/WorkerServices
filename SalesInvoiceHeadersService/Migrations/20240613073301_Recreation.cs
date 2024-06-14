using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesInvoiceHeadersService.Migrations
{
    /// <inheritdoc />
    public partial class Recreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustInvoiceJour",
                columns: table => new
                {
                    RecId1 = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataAreaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LedgerVoucher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountryRegionISOCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceAddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDiscountCustomerGroupCode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalChargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTermsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderResponsiblePersonnelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTermsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryModeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceHeaderTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceAddressState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCountryRegionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersOrderReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalInvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalesOrderOriginCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorCodeBak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DemandDateJour = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDateTime1 = table.Column<DateTime>(type: "datetime", nullable: true),
                    SalesId_CT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRNNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnReasonCodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId_CT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSample = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalespersonCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReturn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PORefID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProcessed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProcess_CT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountMST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ParentReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustInvoiceJour", x => x.RecId1);
                });

            migrationBuilder.CreateTable(
                name: "CustInvoiceJourTestR",
                columns: table => new
                {
                    RecId1 = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataAreaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LedgerVoucher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountryRegionISOCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceAddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDiscountCustomerGroupCode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalChargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTermsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderResponsiblePersonnelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTermsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryModeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceCustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceHeaderTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceAddressState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCountryRegionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersOrderReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalInvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalesOrderOriginCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorCodeBak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DemandDateJour = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDateTime1 = table.Column<DateTime>(type: "datetime", nullable: true),
                    SalesId_CT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRNNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnReasonCodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId_CT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSample = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalespersonCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReturn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PORefID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProcessed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProcess_CT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountMST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ParentReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustInvoiceJourTestR", x => x.RecId1);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustInvoiceJour");

            migrationBuilder.DropTable(
                name: "CustInvoiceJourTestR");
        }
    }
}
