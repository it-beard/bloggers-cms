using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class UpdateReleaseDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDateUtc",
                table: "Contents",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "EndDateUtc",
                table: "Contents",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Contents",
                newName: "ReleaseDateUtc");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Contents",
                newName: "EndDateUtc");
        }
    }
}
