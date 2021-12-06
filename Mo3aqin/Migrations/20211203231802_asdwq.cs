using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class asdwq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Championships_ChampionshipChampId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Classes_ClassId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ChampionshipChampId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ClassId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_GameDetails_GameId",
                table: "GameDetails");

            migrationBuilder.DropIndex(
                name: "IX_Championship_Games_GameId",
                table: "Championship_Games");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ChampionshipChampId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_GameId",
                table: "GameDetails",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Games_GameId",
                table: "Championship_Games",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameDetails_GameId",
                table: "GameDetails");

            migrationBuilder.DropIndex(
                name: "IX_Championship_Games_GameId",
                table: "Championship_Games");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipChampId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ChampionshipChampId",
                table: "Games",
                column: "ChampionshipChampId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ClassId",
                table: "Games",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_GameId",
                table: "GameDetails",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Games_GameId",
                table: "Championship_Games",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Championships_ChampionshipChampId",
                table: "Games",
                column: "ChampionshipChampId",
                principalTable: "Championships",
                principalColumn: "ChampId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Classes_ClassId",
                table: "Games",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
