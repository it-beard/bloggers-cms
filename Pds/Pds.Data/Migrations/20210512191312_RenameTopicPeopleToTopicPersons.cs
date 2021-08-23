using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class RenameTopicPeopleToTopicPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTopic_Persons_PeopleId",
                table: "PersonTopic");

            migrationBuilder.RenameColumn(
                name: "PeopleId",
                table: "PersonTopic",
                newName: "PersonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTopic_Persons_PersonsId",
                table: "PersonTopic",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTopic_Persons_PersonsId",
                table: "PersonTopic");

            migrationBuilder.RenameColumn(
                name: "PersonsId",
                table: "PersonTopic",
                newName: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTopic_Persons_PeopleId",
                table: "PersonTopic",
                column: "PeopleId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
