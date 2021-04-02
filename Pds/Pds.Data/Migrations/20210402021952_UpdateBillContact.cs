using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class UpdateBillContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Bills",
                newName: "ContactNameTemp");
            
            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Bills",
                newName: "Contact");
            
            migrationBuilder.RenameColumn(
                name: "ContactNameTemp",
                table: "Bills",
                newName: "ContactName");

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Bills",
                type: "varchar(300)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Bills",
                type: "varchar(300)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldNullable: true);
        }
    }
}
