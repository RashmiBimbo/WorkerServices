using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlIntegrationUI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBServiceDetails",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueryString = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "cross-company=true"),
                    Period = table.Column<int>(type: "int", nullable: false, defaultValue: 30),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altered = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValue: "Running"),
                    LastRun = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TotalRecordsTracked = table.Column<long>(type: "bigint", nullable: true),
                    TotalRecordsAdded = table.Column<long>(type: "bigint", nullable: true),
                    TotalRecordsUpdated = table.Column<long>(type: "bigint", nullable: true),
                    TimeTaken = table.Column<int>(type: "int", nullable: true),
                    NextRun = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Columns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBServiceDetails", x => x.RecId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBServiceDetails");
        }
    }
}
