using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Macro.Migrations
{
    public partial class SoftwareInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(nullable: true),
                    SoftwareTitle = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    PurchaseOrder = table.Column<string>(nullable: true),
                    LicenseType = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    Supported = table.Column<bool>(nullable: false),
                    SupportExp = table.Column<DateTime>(nullable: false),
                    TotalKeys = table.Column<int>(nullable: false),
                    UsedKeys = table.Column<int>(nullable: false),
                    LicenseKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Software");
        }
    }
}
