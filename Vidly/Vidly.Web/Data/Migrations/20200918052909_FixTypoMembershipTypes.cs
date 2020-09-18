using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Web.Data.Migrations
{
    public partial class FixTypoMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMonth",
                table: "MembershipTypes");

            migrationBuilder.AddColumn<byte>(
                name: "DurationInMonths",
                table: "MembershipTypes",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMonths",
                table: "MembershipTypes");

            migrationBuilder.AddColumn<byte>(
                name: "DurationInMonth",
                table: "MembershipTypes",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
