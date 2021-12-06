using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class llsad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Championship_Games");

            migrationBuilder.CreateTable(
                name: "ChampionshipGames",
                columns: table => new
                {
                    ChampGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ChampId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipGames", x => x.ChampGameId);
                    table.ForeignKey(
                        name: "FK_ChampionshipGames_Championships_ChampId",
                        column: x => x.ChampId,
                        principalTable: "Championships",
                        principalColumn: "ChampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionshipGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipGames_ChampId",
                table: "ChampionshipGames",
                column: "ChampId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipGames_GameId",
                table: "ChampionshipGames",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionshipGames");

            migrationBuilder.CreateTable(
                name: "Championship_Games",
                columns: table => new
                {
                    ChampId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_championship_Games", x => new { x.ChampId, x.GameId });
                    table.ForeignKey(
                        name: "FK_Championship_Games_Championships_ChampId",
                        column: x => x.ChampId,
                        principalTable: "Championships",
                        principalColumn: "ChampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Championship_Games_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Games_ChampId",
                table: "Championship_Games",
                column: "ChampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Games_GameId",
                table: "Championship_Games",
                column: "GameId");
        }
    }
}
