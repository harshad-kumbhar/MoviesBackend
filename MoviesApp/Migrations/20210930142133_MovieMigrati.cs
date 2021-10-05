using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class MovieMigrati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(unicode: false, maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PublishedDate = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Rating = table.Column<int>(unicode: false, maxLength: 50, nullable: false),
                    IsLike = table.Column<bool>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
