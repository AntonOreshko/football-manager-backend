using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class squadformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FORMATION_POSITIONS_FORMATION_DATA_FORMATION_DATA_ID",
                table: "FORMATION_POSITIONS");

            migrationBuilder.DropTable(
                name: "FORMATION_DATA");

            migrationBuilder.RenameColumn(
                name: "FORMATION_DATA_ID",
                table: "FORMATION_POSITIONS",
                newName: "SQUAD_ID");

            migrationBuilder.RenameIndex(
                name: "IX_FORMATION_POSITIONS_FORMATION_DATA_ID",
                table: "FORMATION_POSITIONS",
                newName: "IX_FORMATION_POSITIONS_SQUAD_ID");

            migrationBuilder.AddColumn<int>(
                name: "FORMATION",
                table: "SQUADS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_FORMATION_POSITIONS_SQUADS_SQUAD_ID",
                table: "FORMATION_POSITIONS",
                column: "SQUAD_ID",
                principalTable: "SQUADS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FORMATION_POSITIONS_SQUADS_SQUAD_ID",
                table: "FORMATION_POSITIONS");

            migrationBuilder.DropColumn(
                name: "FORMATION",
                table: "SQUADS");

            migrationBuilder.RenameColumn(
                name: "SQUAD_ID",
                table: "FORMATION_POSITIONS",
                newName: "FORMATION_DATA_ID");

            migrationBuilder.RenameIndex(
                name: "IX_FORMATION_POSITIONS_SQUAD_ID",
                table: "FORMATION_POSITIONS",
                newName: "IX_FORMATION_POSITIONS_FORMATION_DATA_ID");

            migrationBuilder.CreateTable(
                name: "FORMATION_DATA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FORMATION = table.Column<int>(nullable: false),
                    SQUAD_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMATION_DATA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FORMATION_DATA_SQUADS_SQUAD_ID",
                        column: x => x.SQUAD_ID,
                        principalTable: "SQUADS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FORMATION_DATA_SQUAD_ID",
                table: "FORMATION_DATA",
                column: "SQUAD_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FORMATION_POSITIONS_FORMATION_DATA_FORMATION_DATA_ID",
                table: "FORMATION_POSITIONS",
                column: "FORMATION_DATA_ID",
                principalTable: "FORMATION_DATA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
