using Microsoft.EntityFrameworkCore.Migrations;

namespace Pds.Data.Migrations
{
    public partial class UpdateBillData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $"Update bills set PaymentStatus = [Status];" +
                $"Update bills set [Status] = 0;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
