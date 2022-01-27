using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pds.Data.Migrations
{
    public partial class UpdateBrandTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Brands",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("5aa23fa2-4b73-4a3f-c3d4-08d8d2705c5f"),
                column: "Info",
                value: "https://youtube.com/itbeard");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("6bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"),
                column: "Info",
                value: "https://youtube.com/thedarkless");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Brands",
                type: "varchar(300)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("5aa23fa2-4b73-4a3f-c3d4-08d8d2705c5f"),
                column: "Url",
                value: "https://youtube.com/itbeard");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("6bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"),
                column: "Url",
                value: "https://youtube.com/thedarkless");
        }
    }
}
