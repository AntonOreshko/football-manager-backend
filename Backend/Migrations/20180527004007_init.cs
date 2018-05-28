using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BOOSTERS = table.Column<int>(nullable: false),
                    COINS = table.Column<int>(nullable: false),
                    COUNTRY = table.Column<int>(nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLUBS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FOUNDATION_DATE = table.Column<DateTime>(nullable: false),
                    NAME = table.Column<string>(maxLength: 64, nullable: false),
                    USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLUBS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLUBS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "BUILDINGS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    LEVEL = table.Column<int>(nullable: false),
                    FANS_COUNT = table.Column<int>(nullable: true),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUILDINGS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BUILDINGS_CLUBS_ID",
                        column: x => x.ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClubId = table.Column<int>(nullable: true),
                    COUNTRY = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LEVEL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_CLUBS_ClubId",
                        column: x => x.ClubId,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PLAYERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AGE = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<int>(nullable: false),
                    COUNTRY = table.Column<int>(nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    FIRST_POSITION = table.Column<int>(nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    SECOND_POSITION = table.Column<int>(nullable: false),
                    THIRD_POSITION = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAYERS_CLUBS_CLUB_ID",
                        column: x => x.CLUB_ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SQUADS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CLUB_ID = table.Column<int>(nullable: false),
                    IS_ACTIVE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SQUADS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SQUADS_CLUBS_CLUB_ID",
                        column: x => x.CLUB_ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLAYER_STATS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ACCELERATION = table.Column<int>(nullable: false),
                    AGILITY = table.Column<int>(nullable: false),
                    BALL_CONTROL = table.Column<int>(nullable: false),
                    CROSSING = table.Column<int>(nullable: false),
                    FREE_CICKS = table.Column<int>(nullable: false),
                    HEADING = table.Column<int>(nullable: false),
                    INTERCEPTIONS = table.Column<int>(nullable: false),
                    LONG_PASSING = table.Column<int>(nullable: false),
                    LONG_SHOTS = table.Column<int>(nullable: false),
                    PENALTIES = table.Column<int>(nullable: false),
                    SHORT_PASSING = table.Column<int>(nullable: false),
                    SHOTS = table.Column<int>(nullable: false),
                    SPRINT_SPEED = table.Column<int>(nullable: false),
                    STRENGTH = table.Column<int>(nullable: false),
                    TACKLES = table.Column<int>(nullable: false),
                    TALENT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYER_STATS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAYER_STATS_PLAYERS_ID",
                        column: x => x.ID,
                        principalTable: "PLAYERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLAYER_TEMPORARY_STATS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    INJURY = table.Column<int>(nullable: false),
                    INJURY_DATE_TIME = table.Column<DateTime>(nullable: false),
                    MORALE = table.Column<int>(nullable: false),
                    MORALE_DATE_TIME = table.Column<DateTime>(nullable: false),
                    STAMNIA = table.Column<int>(nullable: false),
                    STAMNIA_DATE_TIME = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYER_TEMPORARY_STATS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAYER_TEMPORARY_STATS_PLAYERS_ID",
                        column: x => x.ID,
                        principalTable: "PLAYERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "FORMATION_POSITIONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FORMATION_DATA_ID = table.Column<int>(nullable: false),
                    FORMATION_POSITION_TYPE = table.Column<int>(nullable: false),
                    PLAYER_ID = table.Column<int>(nullable: false),
                    PLAYER_POSITION = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMATION_POSITIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FORMATION_POSITIONS_FORMATION_DATA_FORMATION_DATA_ID",
                        column: x => x.FORMATION_DATA_ID,
                        principalTable: "FORMATION_DATA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLUBS_USER_ID",
                table: "CLUBS",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_ClubId",
                table: "EMPLOYEES",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FORMATION_DATA_SQUAD_ID",
                table: "FORMATION_DATA",
                column: "SQUAD_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FORMATION_POSITIONS_FORMATION_DATA_ID",
                table: "FORMATION_POSITIONS",
                column: "FORMATION_DATA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PLAYERS_CLUB_ID",
                table: "PLAYERS",
                column: "CLUB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SQUADS_CLUB_ID",
                table: "SQUADS",
                column: "CLUB_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BUILDINGS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "FORMATION_POSITIONS");

            migrationBuilder.DropTable(
                name: "PLAYER_STATS");

            migrationBuilder.DropTable(
                name: "PLAYER_TEMPORARY_STATS");

            migrationBuilder.DropTable(
                name: "USERS_REGISTER_DATA");

            migrationBuilder.DropTable(
                name: "FORMATION_DATA");

            migrationBuilder.DropTable(
                name: "PLAYERS");

            migrationBuilder.DropTable(
                name: "SQUADS");

            migrationBuilder.DropTable(
                name: "CLUBS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
