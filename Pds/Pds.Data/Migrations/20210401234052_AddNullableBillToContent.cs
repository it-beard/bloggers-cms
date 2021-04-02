using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class AddNullableBillToContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrimaryContactType",
                table: "Bills",
                newName: "ContactType");

            migrationBuilder.RenameColumn(
                name: "PrimaryContact",
                table: "Bills",
                newName: "ContactName");

            migrationBuilder.AlterColumn<Guid>(
                name: "BillId",
                table: "Contents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Bills",
                type: "varchar(300)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "ContactType",
                table: "Bills",
                newName: "PrimaryContactType");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Bills",
                newName: "PrimaryContact");

            migrationBuilder.AlterColumn<Guid>(
                name: "BillId",
                table: "Contents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
