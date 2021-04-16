using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class UpdateContactInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Bills",
                type: "varchar(300)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contact",
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
