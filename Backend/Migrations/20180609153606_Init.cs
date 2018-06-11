using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TOURNAMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEVEL = table.Column<int>(nullable: false),
                    CURRENT_STAGE = table.Column<int>(nullable: false),
                    TOURNAMENT_TYPE = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOURNAMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    COUNTRY = table.Column<string>(maxLength: 16, nullable: false),
                    COINS = table.Column<int>(nullable: false),
                    BOOSTERS = table.Column<int>(nullable: false),
                    LOGIN = table.Column<string>(maxLength: 64, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MATCHES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HOME_ID = table.Column<int>(nullable: false),
                    VISITORS_ID = table.Column<int>(nullable: false),
                    TOURNAMENT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCHES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MATCHES_TOURNAMENTS_TOURNAMENT_ID",
                        column: x => x.TOURNAMENT_ID,
                        principalTable: "TOURNAMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLUBS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 64, nullable: false),
                    COUNTRY = table.Column<string>(maxLength: 16, nullable: false),
                    FOUNDATION_DATE = table.Column<DateTime>(nullable: false),
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
                name: "BUILDINGS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEVEL = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    FANS_COUNT = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUILDINGS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BUILDINGS_CLUBS_CLUB_ID",
                        column: x => x.CLUB_ID,
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
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    COUNTRY = table.Column<string>(maxLength: 16, nullable: false),
                    LEVEL = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_CLUBS_CLUB_ID",
                        column: x => x.CLUB_ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATCH_EVENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MATCH_ID = table.Column<int>(nullable: false),
                    MATCH_EVENT_TYPE = table.Column<string>(maxLength: 256, nullable: false),
                    PLAYER_ID = table.Column<int>(nullable: false),
                    MatchId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCH_EVENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MATCH_EVENTS_CLUBS_MATCH_ID",
                        column: x => x.MATCH_ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MATCH_EVENTS_MATCHES_MatchId1",
                        column: x => x.MatchId1,
                        principalTable: "MATCHES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PLAYERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    AGE = table.Column<int>(nullable: false),
                    TALENT = table.Column<int>(nullable: false),
                    COUNTRY = table.Column<string>(maxLength: 16, nullable: false),
                    FIRST_POSITION = table.Column<string>(maxLength: 16, nullable: false),
                    SECOND_POSITION = table.Column<string>(maxLength: 16, nullable: true),
                    THIRD_POSITION = table.Column<string>(maxLength: 16, nullable: true),
                    HEIGHT_TYPE = table.Column<string>(maxLength: 16, nullable: false),
                    BODY_TYPE = table.Column<string>(maxLength: 16, nullable: false),
                    HEIGHT = table.Column<int>(nullable: false),
                    WEIGHT = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<int>(nullable: false)
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
                    IS_ACTIVE = table.Column<bool>(nullable: false),
                    FORMATION = table.Column<string>(maxLength: 64, nullable: false),
                    CLUB_ID = table.Column<int>(nullable: false)
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
                name: "TOURNAMENTS_CLUBS",
                columns: table => new
                {
                    TOURNAMENT_ID = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOURNAMENTS_CLUBS", x => new { x.TOURNAMENT_ID, x.CLUB_ID });
                    table.UniqueConstraint("AK_TOURNAMENTS_CLUBS_CLUB_ID_TOURNAMENT_ID", x => new { x.CLUB_ID, x.TOURNAMENT_ID });
                    table.ForeignKey(
                        name: "FK_TOURNAMENTS_CLUBS_CLUBS_CLUB_ID",
                        column: x => x.CLUB_ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TOURNAMENTS_CLUBS_TOURNAMENTS_TOURNAMENT_ID",
                        column: x => x.TOURNAMENT_ID,
                        principalTable: "TOURNAMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLAYER_STATS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ACCELERATION = table.Column<float>(nullable: false),
                    SPRINT_SPEED = table.Column<float>(nullable: false),
                    SHOTS = table.Column<float>(nullable: false),
                    LONG_SHOTS = table.Column<float>(nullable: false),
                    PENALTIES = table.Column<float>(nullable: false),
                    FREE_CICKS = table.Column<float>(nullable: false),
                    SHORT_PASSING = table.Column<float>(nullable: false),
                    LONG_PASSING = table.Column<float>(nullable: false),
                    CROSSING = table.Column<float>(nullable: false),
                    AGILITY = table.Column<float>(nullable: false),
                    BALL_CONTROL = table.Column<float>(nullable: false),
                    TRICKS = table.Column<float>(nullable: false),
                    INTERCEPTIONS = table.Column<float>(nullable: false),
                    STANDING_TACKLES = table.Column<float>(nullable: false),
                    SLIDING_TACKLES = table.Column<float>(nullable: false),
                    JUMPING = table.Column<float>(nullable: false),
                    STRENGTH = table.Column<float>(nullable: false),
                    HEADING = table.Column<float>(nullable: false),
                    STAMINA = table.Column<float>(nullable: false),
                    HAND_PLAY = table.Column<float>(nullable: false),
                    KICKING = table.Column<float>(nullable: false),
                    REFLEXES = table.Column<float>(nullable: false),
                    POSITIONING = table.Column<float>(nullable: false),
                    TALENT = table.Column<float>(nullable: false)
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
                    STAMNIA = table.Column<int>(nullable: false),
                    STAMNIA_DATE_TIME = table.Column<DateTime>(nullable: false),
                    MORALE = table.Column<int>(nullable: false),
                    MORALE_DATE_TIME = table.Column<DateTime>(nullable: false)
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
                name: "FORMATION_POSITIONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PLAYER_POSITION = table.Column<string>(maxLength: 16, nullable: false),
                    FORMATION_POSITION_TYPE = table.Column<string>(maxLength: 16, nullable: false),
                    PLAYER_ID = table.Column<int>(nullable: false),
                    SQUAD_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMATION_POSITIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FORMATION_POSITIONS_SQUADS_SQUAD_ID",
                        column: x => x.SQUAD_ID,
                        principalTable: "SQUADS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BUILDINGS_CLUB_ID",
                table: "BUILDINGS",
                column: "CLUB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLUBS_USER_ID",
                table: "CLUBS",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_CLUB_ID",
                table: "EMPLOYEES",
                column: "CLUB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FORMATION_POSITIONS_SQUAD_ID",
                table: "FORMATION_POSITIONS",
                column: "SQUAD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MATCH_EVENTS_MATCH_ID",
                table: "MATCH_EVENTS",
                column: "MATCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MATCH_EVENTS_MatchId1",
                table: "MATCH_EVENTS",
                column: "MatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_MATCHES_TOURNAMENT_ID",
                table: "MATCHES",
                column: "TOURNAMENT_ID");

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
                name: "MATCH_EVENTS");

            migrationBuilder.DropTable(
                name: "PLAYER_STATS");

            migrationBuilder.DropTable(
                name: "PLAYER_TEMPORARY_STATS");

            migrationBuilder.DropTable(
                name: "TOURNAMENTS_CLUBS");

            migrationBuilder.DropTable(
                name: "SQUADS");

            migrationBuilder.DropTable(
                name: "MATCHES");

            migrationBuilder.DropTable(
                name: "PLAYERS");

            migrationBuilder.DropTable(
                name: "TOURNAMENTS");

            migrationBuilder.DropTable(
                name: "CLUBS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
