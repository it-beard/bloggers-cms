using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class AddCosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costs_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Costs_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_BrandId",
                table: "Costs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_ContentId",
                table: "Costs",
                column: "ContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costs");
        }
    }
}
