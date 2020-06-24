using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieLists",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TmdbID = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Quality = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLists", x => x.MovieID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieLists");
        }
    }
}
