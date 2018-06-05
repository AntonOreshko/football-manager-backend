using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class removeuserregisterdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERS_REGISTER_DATA");

            migrationBuilder.AddColumn<string>(
                name: "LOGIN",
                table: "USERS",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PASSWORD",
                table: "USERS",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LOGIN",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "PASSWORD",
                table: "USERS");

            migrationBuilder.CreateTable(
                name: "USERS_REGISTER_DATA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    LOGIN = table.Column<string>(maxLength: 64, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS_REGISTER_DATA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERS_REGISTER_DATA_USERS_ID",
                        column: x => x.ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
