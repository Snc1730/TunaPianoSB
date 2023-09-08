using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPianoSB.Migrations
{
    public partial class changedSongLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Songs",
                type: "text",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1,
                column: "Length",
                value: "4:55");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2,
                column: "Length",
                value: "3:54");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 3,
                column: "Length",
                value: "5:29");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Length",
                table: "Songs",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1,
                column: "Length",
                value: new TimeSpan(0, 0, 4, 55, 0));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2,
                column: "Length",
                value: new TimeSpan(0, 0, 3, 54, 0));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 3,
                column: "Length",
                value: new TimeSpan(0, 0, 5, 29, 0));
        }
    }
}
