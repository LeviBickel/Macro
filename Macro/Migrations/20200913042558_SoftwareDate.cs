using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Macro.Migrations
{
    public partial class SoftwareDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "added",
                table: "Software",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "added",
                table: "Software");
        }
    }
}
