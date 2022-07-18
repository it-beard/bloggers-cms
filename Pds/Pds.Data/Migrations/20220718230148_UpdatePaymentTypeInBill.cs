using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pds.Data.Migrations
{
    public partial class UpdatePaymentTypeInBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // change Тинькофф и Юмани to PersonalAccount
            migrationBuilder.Sql($"Update bills set paymenttype = 4 where paymenttype = 5;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
