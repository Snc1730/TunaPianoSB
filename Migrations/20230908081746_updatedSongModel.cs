using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPianoSB.Migrations
{
    public partial class updatedSongModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
