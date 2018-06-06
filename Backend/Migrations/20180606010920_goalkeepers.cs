using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class goalkeepers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "HAND_PLAY",
                table: "PLAYER_STATS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "KICKING",
                table: "PLAYER_STATS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "POSITIONING",
                table: "PLAYER_STATS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "REFLEXES",
                table: "PLAYER_STATS",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HAND_PLAY",
                table: "PLAYER_STATS");

            migrationBuilder.DropColumn(
                name: "KICKING",
                table: "PLAYER_STATS");

            migrationBuilder.DropColumn(
                name: "POSITIONING",
                table: "PLAYER_STATS");

            migrationBuilder.DropColumn(
                name: "REFLEXES",
                table: "PLAYER_STATS");
        }
    }
}
