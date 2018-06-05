using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class clubcountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "COUNTRY",
                table: "CLUBS",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COUNTRY",
                table: "CLUBS");
        }
    }
}
