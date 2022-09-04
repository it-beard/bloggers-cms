using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pds.Data.Migrations
{
    public partial class AddStatusAndCountryToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Clients",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clients");
        }
    }
}
