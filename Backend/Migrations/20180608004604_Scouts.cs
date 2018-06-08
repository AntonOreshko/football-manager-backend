using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Scouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEES_CLUBS_ClubId",
                table: "EMPLOYEES");

            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "EMPLOYEES",
                newName: "CLUB_ID");

            migrationBuilder.RenameIndex(
                name: "IX_EMPLOYEES_ClubId",
                table: "EMPLOYEES",
                newName: "IX_EMPLOYEES_CLUB_ID");

            migrationBuilder.AlterColumn<string>(
                name: "COUNTRY",
                table: "EMPLOYEES",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CLUB_ID",
                table: "EMPLOYEES",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEES_CLUBS_CLUB_ID",
                table: "EMPLOYEES",
                column: "CLUB_ID",
                principalTable: "CLUBS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEES_CLUBS_CLUB_ID",
                table: "EMPLOYEES");

            migrationBuilder.RenameColumn(
                name: "CLUB_ID",
                table: "EMPLOYEES",
                newName: "ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_EMPLOYEES_CLUB_ID",
                table: "EMPLOYEES",
                newName: "IX_EMPLOYEES_ClubId");

            migrationBuilder.AlterColumn<int>(
                name: "COUNTRY",
                table: "EMPLOYEES",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "EMPLOYEES",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEES_CLUBS_ClubId",
                table: "EMPLOYEES",
                column: "ClubId",
                principalTable: "CLUBS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
