using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class RemovePersonTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTopics");

            migrationBuilder.DropColumn(
                name: "ArchivedAt",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UnarchivedAt",
                table: "Topics");

            migrationBuilder.CreateTable(
                name: "PersonTopic",
                columns: table => new
                {
                    PeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTopic", x => new { x.PeopleId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_PersonTopic_Persons_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTopic_TopicsId",
                table: "PersonTopic",
                column: "TopicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTopic");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedAt",
                table: "Topics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnarchivedAt",
                table: "Topics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonTopics",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTopics", x => new { x.TopicId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonTopics_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTopics_PersonId",
                table: "PersonTopics",
                column: "PersonId");
        }
    }
}
