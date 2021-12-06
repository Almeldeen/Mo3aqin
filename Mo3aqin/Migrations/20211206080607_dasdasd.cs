using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class dasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChampionshipGames",
                table: "ChampionshipGames");

            migrationBuilder.DropIndex(
                name: "IX_ChampionshipGames_ChampId",
                table: "ChampionshipGames");

            migrationBuilder.DropIndex(
                name: "IX_ChampionshipGames_GameId",
                table: "ChampionshipGames");

            migrationBuilder.DropColumn(
                name: "ChampGameId",
                table: "ChampionshipGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChampionshipGames",
                table: "ChampionshipGames",
                columns: new[] { "GameId", "ChampId" });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipGames_ChampId",
                table: "ChampionshipGames",
                column: "ChampId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChampionshipGames",
                table: "ChampionshipGames");

            migrationBuilder.DropIndex(
                name: "IX_ChampionshipGames_ChampId",
                table: "ChampionshipGames");

            migrationBuilder.AddColumn<int>(
                name: "ChampGameId",
                table: "ChampionshipGames",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChampionshipGames",
                table: "ChampionshipGames",
                column: "ChampGameId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipGames_ChampId",
                table: "ChampionshipGames",
                column: "ChampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipGames_GameId",
                table: "ChampionshipGames",
                column: "GameId");
        }
    }
}
