using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Web.Data.Migrations
{
    public partial class EditMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "DiscountRate",
                table: "MembershipTypes",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "DurationInMonth",
                table: "MembershipTypes",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "SignUpFee",
                table: "MembershipTypes",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "DurationInMonth",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "SignUpFee",
                table: "MembershipTypes");
        }
    }
}
