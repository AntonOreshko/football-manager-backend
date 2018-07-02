using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Matchstarttime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LEGENDS_HOLLS_OF_FAME_PLAYER_ID",
                table: "LEGENDS");

            migrationBuilder.DropIndex(
                name: "IX_LEGENDS_PLAYER_ID",
                table: "LEGENDS");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "LEGENDS",
                newName: "HOLL_OF_FAME_ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "START_TIME",
                table: "MATCHES",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_LEGENDS_HOLL_OF_FAME_ID",
                table: "LEGENDS",
                column: "HOLL_OF_FAME_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LEGENDS_HOLLS_OF_FAME_HOLL_OF_FAME_ID",
                table: "LEGENDS",
                column: "HOLL_OF_FAME_ID",
                principalTable: "HOLLS_OF_FAME",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LEGENDS_HOLLS_OF_FAME_HOLL_OF_FAME_ID",
                table: "LEGENDS");

            migrationBuilder.DropIndex(
                name: "IX_LEGENDS_HOLL_OF_FAME_ID",
                table: "LEGENDS");

            migrationBuilder.DropColumn(
                name: "START_TIME",
                table: "MATCHES");

            migrationBuilder.RenameColumn(
                name: "HOLL_OF_FAME_ID",
                table: "LEGENDS",
                newName: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_LEGENDS_PLAYER_ID",
                table: "LEGENDS",
                column: "PLAYER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LEGENDS_HOLLS_OF_FAME_PLAYER_ID",
                table: "LEGENDS",
                column: "PLAYER_ID",
                principalTable: "HOLLS_OF_FAME",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
