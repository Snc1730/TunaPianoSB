using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPianoSB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArtistName = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Song_Genres",
                columns: table => new
                {
                    Song_GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song_Genres", x => x.Song_GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Song_GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genres_Song_Genres_Song_GenreId",
                        column: x => x.Song_GenreId,
                        principalTable: "Song_Genres",
                        principalColumn: "Song_GenreId");
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongName = table.Column<string>(type: "text", nullable: true),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    AlbumName = table.Column<string>(type: "text", nullable: true),
                    Length = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Song_GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Song_Genres_Song_GenreId",
                        column: x => x.Song_GenreId,
                        principalTable: "Song_Genres",
                        principalColumn: "Song_GenreId");
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Age", "ArtistName", "Bio" },
                values: new object[,]
                {
                    { 1, 33, "Adele", "British singer-songwriter" },
                    { 2, 30, "Ed Sheeran", "Acclaimed pop artist" },
                    { 3, 40, "Metallica", "Legendary metal band" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Description", "Song_GenreId" },
                values: new object[,]
                {
                    { 1, "Pop", null },
                    { 2, "Rock", null },
                    { 3, "Metal", null }
                });

            migrationBuilder.InsertData(
                table: "Song_Genres",
                columns: new[] { "Song_GenreId", "GenreId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumName", "ArtistId", "Length", "SongName", "Song_GenreId" },
                values: new object[,]
                {
                    { 1, "25", 1, new TimeSpan(0, 0, 4, 55, 0), "Hello", null },
                    { 2, "÷", 2, new TimeSpan(0, 0, 3, 54, 0), "Shape of You", null },
                    { 3, "Metallica", 3, new TimeSpan(0, 0, 5, 29, 0), "Enter Sandman", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Song_GenreId",
                table: "Genres",
                column: "Song_GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Song_GenreId",
                table: "Songs",
                column: "Song_GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Song_Genres");
        }
    }
}
