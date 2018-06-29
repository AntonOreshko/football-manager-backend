using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class MatchStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GROUP_STAGE",
                table: "MATCHES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "STAGE",
                table: "MATCHES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SUB_STAGE",
                table: "MATCHES",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GROUP_STAGE",
                table: "MATCHES");

            migrationBuilder.DropColumn(
                name: "STAGE",
                table: "MATCHES");

            migrationBuilder.DropColumn(
                name: "SUB_STAGE",
                table: "MATCHES");
        }
    }
}
