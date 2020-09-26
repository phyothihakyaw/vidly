using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Web.Data.Migrations
{
    public partial class AddNumberAvailableToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "NumberAvailable",
                table: "Movies",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.Sql(
                @"UPDATE Movies SET NumberAvailable = NumberInStock"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberAvailable",
                table: "Movies");
        }
    }
}
