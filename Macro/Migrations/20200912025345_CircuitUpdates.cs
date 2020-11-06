using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Macro.Migrations
{
    public partial class CircuitUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Circuit");

            migrationBuilder.AddColumn<string>(
                name: "CCSD",
                table: "Circuit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CKT_Type",
                table: "Circuit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DIP",
                table: "Circuit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DInt",
                table: "Circuit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Circuit",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "Circuit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIP",
                table: "Circuit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SInt",
                table: "Circuit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CCSD",
                table: "Circuit");

            migrationBuilder.DropColumn(
                name: "CKT_Type",
                table: "Circuit");

            migrationBuilder.DropColumn(
                name: "DIP",
                table: "Circuit");

            migrationBuilder.DropColumn(
                name: "DInt",
                table: "Circuit");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Circuit");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "Circuit");

            migrationBuilder.DropColumn(
                name: "SIP",
                table: "Circuit");

            migrationBuilder.DropColumn(
                name: "SInt",
                table: "Circuit");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Circuit",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
