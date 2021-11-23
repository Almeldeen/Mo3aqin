using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class addplayertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNum = table.Column<int>(type: "int", nullable: false),
                    PassportExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthOfDateImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthOfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalReportImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisableImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilianNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocRecommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Disabality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.GameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_PlayerId",
                table: "PlayerGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClassId",
                table: "Players",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_NationalityId",
                table: "Players",
                column: "NationalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
