using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class sadaf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "Competitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CoachDecisions",
                columns: table => new
                {
                    DecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachDecisions", x => x.DecId);
                    table.ForeignKey(
                        name: "FK_CoachDecisions_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDecisions",
                columns: table => new
                {
                    DecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDecisions", x => x.DecId);
                    table.ForeignKey(
                        name: "FK_EmployeeDecisions_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "playerDecisions",
                columns: table => new
                {
                    DecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerDecisions", x => x.DecId);
                    table.ForeignKey(
                        name: "FK_playerDecisions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHistories",
                columns: table => new
                {
                    HisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HisDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChampName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlyerNum = table.Column<int>(type: "int", nullable: false),
                    playerRating = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHistories", x => x.HisId);
                    table.ForeignKey(
                        name: "FK_PlayerHistories_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_RaceId",
                table: "Competitions",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachDecisions_CoachId",
                table: "CoachDecisions",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDecisions_EmpId",
                table: "EmployeeDecisions",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_playerDecisions_PlayerId",
                table: "playerDecisions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHistories_PlayerId",
                table: "PlayerHistories",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Races_RaceId",
                table: "Competitions",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Races_RaceId",
                table: "Competitions");

            migrationBuilder.DropTable(
                name: "CoachDecisions");

            migrationBuilder.DropTable(
                name: "EmployeeDecisions");

            migrationBuilder.DropTable(
                name: "playerDecisions");

            migrationBuilder.DropTable(
                name: "PlayerHistories");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_RaceId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "Competitions");
        }
    }
}
