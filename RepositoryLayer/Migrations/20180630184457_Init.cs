using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TOURNAMENTS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEVEL = table.Column<int>(nullable: false),
                    CURRENT_STAGE = table.Column<int>(nullable: false),
                    IS_FINISHED = table.Column<bool>(nullable: false),
                    TOURNAMENT_TYPE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOURNAMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    COUNTRY = table.Column<int>(nullable: false),
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
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    STAGE = table.Column<int>(nullable: false),
                    SUB_STAGE = table.Column<int>(nullable: false),
                    GROUP = table.Column<string>(nullable: true),
                    NUMBER = table.Column<int>(nullable: false),
                    HOME_ID = table.Column<long>(nullable: false),
                    VISITORS_ID = table.Column<long>(nullable: false),
                    TOURNAMENT_ID = table.Column<long>(nullable: false)
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
                name: "TOURNAMENT_PLAYERS",
                columns: table => new
                {
                    TOURNAMENT_ID = table.Column<long>(nullable: false),
                    PLAYER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOURNAMENT_PLAYERS", x => new { x.TOURNAMENT_ID, x.PLAYER_ID });
                    table.ForeignKey(
                        name: "FK_TOURNAMENT_PLAYERS_TOURNAMENTS_TOURNAMENT_ID",
                        column: x => x.TOURNAMENT_ID,
                        principalTable: "TOURNAMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLUBS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 64, nullable: false),
                    COUNTRY = table.Column<int>(nullable: false),
                    FOUNDATION_DATE = table.Column<DateTime>(nullable: false),
                    LEVEL = table.Column<int>(nullable: false, defaultValue: 1),
                    USER_ID = table.Column<long>(nullable: false)
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
                name: "MATCH_EVENTS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MATCH_ID = table.Column<long>(nullable: false),
                    FORMATION = table.Column<int>(nullable: false),
                    PLAYER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCH_EVENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MATCH_EVENTS_MATCHES_MATCH_ID",
                        column: x => x.MATCH_ID,
                        principalTable: "MATCHES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BUILDINGS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEVEL = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<long>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    NAME = table.Column<string>(maxLength: 64, nullable: true),
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
                name: "CLUBS_HISTORY",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLUBS_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLUBS_HISTORY_CLUBS_ID",
                        column: x => x.ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    COUNTRY = table.Column<int>(nullable: false),
                    LEVEL = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<long>(nullable: false),
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
                name: "HOLLS_OF_FAME",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOLLS_OF_FAME", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOLLS_OF_FAME_CLUBS_ID",
                        column: x => x.ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLAYERS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    COUNTRY = table.Column<int>(nullable: false),
                    AGE = table.Column<int>(nullable: false),
                    TALENT = table.Column<int>(nullable: false),
                    POSITION = table.Column<int>(nullable: false),
                    HEIGHT_TYPE = table.Column<int>(nullable: false),
                    BODY_TYPE = table.Column<int>(nullable: false),
                    HEIGHT = table.Column<int>(nullable: false),
                    WEIGHT = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<long>(nullable: false)
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
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<bool>(nullable: false),
                    FORMATION = table.Column<int>(nullable: false),
                    CLUB_ID = table.Column<long>(nullable: false)
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
                name: "TOURNAMENT_CLUBS",
                columns: table => new
                {
                    TOURNAMENT_ID = table.Column<long>(nullable: false),
                    CLUB_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOURNAMENT_CLUBS", x => new { x.TOURNAMENT_ID, x.CLUB_ID });
                    table.ForeignKey(
                        name: "FK_TOURNAMENT_CLUBS_CLUBS_CLUB_ID",
                        column: x => x.CLUB_ID,
                        principalTable: "CLUBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TOURNAMENT_CLUBS_TOURNAMENTS_TOURNAMENT_ID",
                        column: x => x.TOURNAMENT_ID,
                        principalTable: "TOURNAMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SEASON_RESULTS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEAGUE_PLACE = table.Column<int>(nullable: false),
                    SUPERLEAGUE_STAGE = table.Column<int>(nullable: false),
                    CLUB_HISTORY_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEASON_RESULTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SEASON_RESULTS_CLUBS_HISTORY_CLUB_HISTORY_ID",
                        column: x => x.CLUB_HISTORY_ID,
                        principalTable: "CLUBS_HISTORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LEGENDS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LEGEND_TYPE = table.Column<int>(nullable: false),
                    RESULT = table.Column<int>(nullable: false),
                    MATCHES = table.Column<int>(nullable: false),
                    PLAYER_ID = table.Column<long>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEGENDS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LEGENDS_HOLLS_OF_FAME_PLAYER_ID",
                        column: x => x.PLAYER_ID,
                        principalTable: "HOLLS_OF_FAME",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLAYER_SCORES",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    TOTAL_LEAGUE_SCORES = table.Column<int>(nullable: false),
                    TOTAL_LEAGUE_ASSISTS = table.Column<int>(nullable: false),
                    TOTAL_LEAGUE_MATCHES = table.Column<int>(nullable: false),
                    TOTAL_LEAGUE_RATING = table.Column<float>(nullable: false),
                    CURRENT_LEAGUE_SCORES = table.Column<int>(nullable: false),
                    CURRENT_LEAGUE_ASSISTS = table.Column<int>(nullable: false),
                    CURRENT_LEAGUE_MATCHES = table.Column<int>(nullable: false),
                    CURRENT_LEAGUE_RATING = table.Column<float>(nullable: false),
                    TOTAL_SUPERLEAGUE_SCORES = table.Column<int>(nullable: false),
                    TOTAL_SUPERLEAGUE_ASSISTS = table.Column<int>(nullable: false),
                    TOTAL_SUPERLEAGUE_MATCHES = table.Column<int>(nullable: false),
                    TOTAL_SUPERLEAGUE_RATING = table.Column<float>(nullable: false),
                    CURRENT_SUPERLEAGUE_SCORES = table.Column<int>(nullable: false),
                    CURRENT_SUPERLEAGUE_ASSISTS = table.Column<int>(nullable: false),
                    CURRENT_SUPERLEAGUE_MATCHES = table.Column<int>(nullable: false),
                    CURRENT_SUPERLEAGUE_RATING = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYER_SCORES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAYER_SCORES_PLAYERS_ID",
                        column: x => x.ID,
                        principalTable: "PLAYERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLAYER_STATS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    ACCELERATION = table.Column<float>(nullable: false),
                    SPRINT_SPEED = table.Column<float>(nullable: false),
                    SHOTS = table.Column<float>(nullable: false),
                    LONG_SHOTS = table.Column<float>(nullable: false),
                    PENALTIES = table.Column<float>(nullable: false),
                    FREE_KICKS = table.Column<float>(nullable: false),
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
                    POSITIONING = table.Column<float>(nullable: false)
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
                    ID = table.Column<long>(nullable: false),
                    INJURY = table.Column<int>(nullable: false),
                    INJURY_DATE_TIME = table.Column<DateTime>(nullable: false),
                    STAMINA = table.Column<int>(nullable: false),
                    STAMINA_DATE_TIME = table.Column<DateTime>(nullable: false),
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
                    PLAYER_POSITION = table.Column<int>(nullable: false),
                    FORMATION_POSITION_TYPE = table.Column<int>(nullable: false),
                    PLAYER_ID = table.Column<long>(nullable: true),
                    SQUAD_ID = table.Column<long>(nullable: false)
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
                name: "IX_LEGENDS_PLAYER_ID",
                table: "LEGENDS",
                column: "PLAYER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MATCH_EVENTS_MATCH_ID",
                table: "MATCH_EVENTS",
                column: "MATCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MATCHES_TOURNAMENT_ID",
                table: "MATCHES",
                column: "TOURNAMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PLAYERS_CLUB_ID",
                table: "PLAYERS",
                column: "CLUB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SEASON_RESULTS_CLUB_HISTORY_ID",
                table: "SEASON_RESULTS",
                column: "CLUB_HISTORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SQUADS_CLUB_ID",
                table: "SQUADS",
                column: "CLUB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TOURNAMENT_CLUBS_CLUB_ID",
                table: "TOURNAMENT_CLUBS",
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
                name: "LEGENDS");

            migrationBuilder.DropTable(
                name: "MATCH_EVENTS");

            migrationBuilder.DropTable(
                name: "PLAYER_SCORES");

            migrationBuilder.DropTable(
                name: "PLAYER_STATS");

            migrationBuilder.DropTable(
                name: "PLAYER_TEMPORARY_STATS");

            migrationBuilder.DropTable(
                name: "SEASON_RESULTS");

            migrationBuilder.DropTable(
                name: "TOURNAMENT_CLUBS");

            migrationBuilder.DropTable(
                name: "TOURNAMENT_PLAYERS");

            migrationBuilder.DropTable(
                name: "SQUADS");

            migrationBuilder.DropTable(
                name: "HOLLS_OF_FAME");

            migrationBuilder.DropTable(
                name: "MATCHES");

            migrationBuilder.DropTable(
                name: "PLAYERS");

            migrationBuilder.DropTable(
                name: "CLUBS_HISTORY");

            migrationBuilder.DropTable(
                name: "TOURNAMENTS");

            migrationBuilder.DropTable(
                name: "CLUBS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
