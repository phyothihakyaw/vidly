using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Web.Data.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "MembershipTypes",
                new string[] { "Id", "Name", "SignUpFee", "DurationInMonths", "DiscountRate" },
                new object[,]
                {
                    {1, "Pay As You Go", 0, 0, 0 },
                    {2, "Monthly", 30, 1, 10 },
                    {3, "Quarterly", 90, 3, 15 },
                    {4, "Annually", 300, 12, 20 },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
