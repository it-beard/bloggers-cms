using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pds.Data.Migrations
{
    public partial class AddIsArchivedToBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Brands");
        }
    }
}
