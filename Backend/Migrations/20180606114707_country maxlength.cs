using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class countrymaxlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "COUNTRY",
                table: "PLAYERS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "COUNTRY",
                table: "PLAYERS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);
        }
    }
}
