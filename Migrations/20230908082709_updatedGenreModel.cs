using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPianoSB.Migrations
{
    public partial class updatedGenreModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Songs_SongId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_SongId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresGenreId = table.Column<int>(type: "integer", nullable: false),
                    SongsSongId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresGenreId, x.SongsSongId });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_SongsSongId",
                        column: x => x.SongsSongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsSongId",
                table: "GenreSong",
                column: "SongsSongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Genres",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_SongId",
                table: "Genres",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Songs_SongId",
                table: "Genres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId");
        }
    }
}
