using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class intail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    ChampId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Invitaion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpsNum = table.Column<int>(type: "int", nullable: false),
                    PlayersNum = table.Column<int>(type: "int", nullable: false),
                    CoachsNum = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.ChampId);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilianCoach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilianNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionshipChampId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachId);
                    table.ForeignKey(
                        name: "FK_Coaches_Championships_ChampionshipChampId",
                        column: x => x.ChampionshipChampId,
                        principalTable: "Championships",
                        principalColumn: "ChampId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilianCoach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilianNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionshipChampId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Championships_ChampionshipChampId",
                        column: x => x.ChampionshipChampId,
                        principalTable: "Championships",
                        principalColumn: "ChampId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetitionId = table.Column<int>(type: "int", nullable: true),
                    ChampionshipChampId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Championships_ChampionshipChampId",
                        column: x => x.ChampionshipChampId,
                        principalTable: "Championships",
                        principalColumn: "ChampId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Championship_Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ChampId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassDis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coach_Emp_Games",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach_Emp_Games", x => new { x.CoachId, x.GameId, x.EmpId });
                    table.ForeignKey(
                        name: "FK_Coach_Emp_Games_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coach_Emp_Games_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coach_Emp_Games_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameDetails",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    CoachAssId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    PlayersNum = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDetails", x => new { x.CoachId, x.GameId, x.EmpId, x.CoachAssId, x.SupervisorId });
                    table.ForeignKey(
                        name: "FK_GameDetails_Coaches_CoachAssId",
                        column: x => x.CoachAssId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameDetails_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameDetails_Coaches_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Coaches",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameDetails_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameDetails_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Games_ChampId",
                table: "Championship_Games",
                column: "ChampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Games_GameId",
                table: "Championship_Games",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GameId",
                table: "Classes",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coach_Emp_Games_EmpId",
                table: "Coach_Emp_Games",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_Emp_Games_GameId",
                table: "Coach_Emp_Games",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_ChampionshipChampId",
                table: "Coaches",
                column: "ChampionshipChampId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ChampionshipChampId",
                table: "Employees",
                column: "ChampionshipChampId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_CoachAssId",
                table: "GameDetails",
                column: "CoachAssId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_EmpId",
                table: "GameDetails",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_GameId",
                table: "GameDetails",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_SupervisorId",
                table: "GameDetails",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ChampionshipChampId",
                table: "Games",
                column: "ChampionshipChampId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CompetitionId",
                table: "Games",
                column: "CompetitionId",
                unique: true,
                filter: "[CompetitionId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Championship_Games");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Coach_Emp_Games");

            migrationBuilder.DropTable(
                name: "GameDetails");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
