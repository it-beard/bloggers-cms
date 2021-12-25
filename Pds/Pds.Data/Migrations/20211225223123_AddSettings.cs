using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pds.Data.Migrations
{
    public partial class AddSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "varchar(100)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "Description", "Key", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { new Guid("0bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Название первой custom-ссылки в меню навигации", "ExternalLink1_Title", null, "Link #1" },
                    { new Guid("1bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "URL первой custom-ссылки в меню навигации", "ExternalLink1_Url", null, "https://google.com" },
                    { new Guid("2bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Название второй custom-ссылки в меню навигации", "ExternalLink2_Title", null, "Link #2" },
                    { new Guid("3bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "URL второй custom-ссылки в меню навигации", "ExternalLink2_Url", null, "https://youtube.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Key",
                table: "Settings",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
