using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pds.Data.Migrations
{
    public partial class AddSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Brands_BrandId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Contents_ContentId",
                table: "Gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts");

            migrationBuilder.RenameTable(
                name: "Gifts",
                newName: "Gift");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_ContentId",
                table: "Gift",
                newName: "IX_Gift_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Gifts_BrandId",
                table: "Gift",
                newName: "IX_Gift_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gift",
                table: "Gift",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "varchar(100)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Setting",
                columns: new[] { "Id", "CreatedAt", "Key", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { new Guid("0bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ExternalLink1_Title", null, "Link #1" },
                    { new Guid("1bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ExternalLink1_Url", null, "https://google.com" },
                    { new Guid("2bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ExternalLink2_Title", null, "Link #2" },
                    { new Guid("3bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ExternalLink2_Url", null, "https://youtube.com" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Brands_BrandId",
                table: "Gift",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Contents_ContentId",
                table: "Gift",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Brands_BrandId",
                table: "Gift");

            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Contents_ContentId",
                table: "Gift");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gift",
                table: "Gift");

            migrationBuilder.RenameTable(
                name: "Gift",
                newName: "Gifts");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_ContentId",
                table: "Gifts",
                newName: "IX_Gifts_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_BrandId",
                table: "Gifts",
                newName: "IX_Gifts_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Brands_BrandId",
                table: "Gifts",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Contents_ContentId",
                table: "Gifts",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id");
        }
    }
}
