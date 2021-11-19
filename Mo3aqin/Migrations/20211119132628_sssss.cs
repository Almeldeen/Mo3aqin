using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class sssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDetails_Coaches_SupervisorId",
                table: "GameDetails");

            migrationBuilder.DropIndex(
                name: "IX_GameDetails_EmpId",
                table: "GameDetails");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_EmpId",
                table: "GameDetails",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDetails_Employees_SupervisorId",
                table: "GameDetails",
                column: "SupervisorId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDetails_Employees_SupervisorId",
                table: "GameDetails");

            migrationBuilder.DropIndex(
                name: "IX_GameDetails_EmpId",
                table: "GameDetails");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_EmpId",
                table: "GameDetails",
                column: "EmpId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDetails_Coaches_SupervisorId",
                table: "GameDetails",
                column: "SupervisorId",
                principalTable: "Coaches",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
