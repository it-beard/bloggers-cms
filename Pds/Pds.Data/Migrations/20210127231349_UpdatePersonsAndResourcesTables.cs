using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class UpdatePersonsAndResourcesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Persons_PersonID",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Resources",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Resources",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_PersonID",
                table: "Resources",
                newName: "IX_Resources_PersonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Persons",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Persons_PersonId",
                table: "Resources",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Persons_PersonId",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Resources",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Resources",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_PersonId",
                table: "Resources",
                newName: "IX_Resources_PersonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Persons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Persons_PersonID",
                table: "Resources",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
