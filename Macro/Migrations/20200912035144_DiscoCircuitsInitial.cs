using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Macro.Migrations
{
    public partial class DiscoCircuitsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscoCircuits",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CCSD = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    CKT_Type = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    SInt = table.Column<string>(nullable: true),
                    SIP = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    DInt = table.Column<string>(nullable: true),
                    DIP = table.Column<string>(nullable: true),
                    CCO = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoCircuits", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscoCircuits");
        }
    }
}
