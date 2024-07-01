using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubledgerVoucherGeneralJournalEntryEntitiesService.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasureConversionsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllProductsTestR",
                columns: table => new
                {
                    ProductNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Etag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSearchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime1 = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllProductsTestR", x => x.ProductNumber);
                });

            migrationBuilder.CreateTable(
                name: "SubledgerVoucherGeneralJournalEntryEntitiesTestR",
                columns: table => new
                {
                    Voucher = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecId1 = table.Column<long>(type: "bigint", nullable: false),
                    Etag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralJournalEntry = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferId = table.Column<long>(type: "bigint", nullable: true),
                    RecVersion1 = table.Column<int>(type: "int", nullable: true),
                    SubledgerJournalEntry = table.Column<long>(type: "bigint", nullable: true),
                    VoucherDataAreaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Partition1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubledgerVoucherGeneralJournalEntryEntitiesTestR", x => new { x.Voucher, x.RecId1 });
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasureConversionsTestR",
                columns: table => new
                {
                    FromUnitSymbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToUnitSymbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ODataEtag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnerOffset = table.Column<int>(type: "int", nullable: false),
                    OuterOffset = table.Column<int>(type: "int", nullable: false),
                    Rounding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numerator = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<int>(type: "int", nullable: false),
                    Denominator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureConversionsTestR", x => new { x.FromUnitSymbol, x.ToUnitSymbol });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllProductsTestR");

            migrationBuilder.DropTable(
                name: "SubledgerVoucherGeneralJournalEntryEntitiesTestR");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureConversionsTestR");
        }
    }
}
