using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class RenameChannelsToBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Channels_ChannelId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Channels_ChannelId",
                table: "Contents");

            migrationBuilder.DropTable(
                name: "ChannelPerson");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "Contents",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_ChannelId",
                table: "Contents",
                newName: "IX_Contents_BrandId");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "Bills",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_ChannelId",
                table: "Bills",
                newName: "IX_Bills_BrandId");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", nullable: false),
                    Url = table.Column<string>(type: "varchar(300)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandPerson",
                columns: table => new
                {
                    BrandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandPerson", x => new { x.BrandsId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_BrandPerson_Brands_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "Url" },
                values: new object[] { new Guid("5aa23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "АйТиБорода", null, "https://youtube.com/itbeard" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "Url" },
                values: new object[] { new Guid("6bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тёмный Лес", null, "https://youtube.com/thedarkless" });

            migrationBuilder.CreateIndex(
                name: "IX_BrandPerson_PersonsId",
                table: "BrandPerson",
                column: "PersonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Brands_BrandId",
                table: "Bills",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Brands_BrandId",
                table: "Contents",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Brands_BrandId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Brands_BrandId",
                table: "Contents");

            migrationBuilder.DropTable(
                name: "BrandPerson");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Contents",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_BrandId",
                table: "Contents",
                newName: "IX_Contents_ChannelId");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Bills",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_BrandId",
                table: "Bills",
                newName: "IX_Bills_ChannelId");

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChannelPerson",
                columns: table => new
                {
                    ChannelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelPerson", x => new { x.ChannelsId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_ChannelPerson_Channels_ChannelsId",
                        column: x => x.ChannelsId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "Url" },
                values: new object[] { new Guid("5aa23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "АйТиБорода", null, "https://youtube.com/itbeard" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "Url" },
                values: new object[] { new Guid("6bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тёмный Лес", null, "https://youtube.com/thedarkless" });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelPerson_PersonsId",
                table: "ChannelPerson",
                column: "PersonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Channels_ChannelId",
                table: "Bills",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Channels_ChannelId",
                table: "Contents",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
