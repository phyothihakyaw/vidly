using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Web.Data.Migrations
{
    public partial class SeedDataToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Genres",
                new string[] { "Id", "Name" },
                new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Sci-fi" },
                    { 4, "Cartoon" },
                    { 5, "Romance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
