using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class formationincreaselength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FORMATION",
                table: "SQUADS",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FORMATION",
                table: "SQUADS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);
        }
    }
}
