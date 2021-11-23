using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class dasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Games_GameId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_GameId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ClassId",
                table: "Games",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Classes_ClassId",
                table: "Games",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Classes_ClassId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ClassId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GameId",
                table: "Classes",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Games_GameId",
                table: "Classes",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
