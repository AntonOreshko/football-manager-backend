using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class enumstostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "COUNTRY",
                table: "USERS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FORMATION",
                table: "SQUADS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "THIRD_POSITION",
                table: "PLAYERS",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "SECOND_POSITION",
                table: "PLAYERS",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "HEIGHT_TYPE",
                table: "PLAYERS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FIRST_POSITION",
                table: "PLAYERS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BODY_TYPE",
                table: "PLAYERS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PLAYER_POSITION",
                table: "FORMATION_POSITIONS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FORMATION_POSITION_TYPE",
                table: "FORMATION_POSITIONS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "COUNTRY",
                table: "CLUBS",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "COUNTRY",
                table: "USERS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "FORMATION",
                table: "SQUADS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "THIRD_POSITION",
                table: "PLAYERS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SECOND_POSITION",
                table: "PLAYERS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HEIGHT_TYPE",
                table: "PLAYERS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "FIRST_POSITION",
                table: "PLAYERS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "BODY_TYPE",
                table: "PLAYERS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "PLAYER_POSITION",
                table: "FORMATION_POSITIONS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "FORMATION_POSITION_TYPE",
                table: "FORMATION_POSITIONS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "COUNTRY",
                table: "CLUBS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);
        }
    }
}
