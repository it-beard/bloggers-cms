using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class RenameOrderToBillAndUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Contents",
                newName: "BillId");

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryContact = table.Column<string>(type: "varchar(300)", nullable: false),
                    PrimaryContactType = table.Column<int>(type: "int", nullable: false),
                    ChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bills_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ChannelId",
                table: "Bills",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ClientId",
                table: "Bills",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ContentId",
                table: "Bills",
                column: "ContentId",
                unique: true,
                filter: "[ContentId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "Contents",
                newName: "OrderId");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrimaryContact = table.Column<string>(type: "varchar(300)", nullable: false),
                    PrimaryContactType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ChannelId",
                table: "Orders",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContentId",
                table: "Orders",
                column: "ContentId",
                unique: true);
        }
    }
}
