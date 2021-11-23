using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class sadas : Migration
    {


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Championships_ChampionshipChampId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ChampionshipChampId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ChampionshipChampId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Nationalities_NationalityId",
                table: "Employees",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Nationalities_NationalityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipChampId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ChampionshipChampId",
                table: "Employees",
                column: "ChampionshipChampId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Championships_ChampionshipChampId",
                table: "Employees",
                column: "ChampionshipChampId",
                principalTable: "Championships",
                principalColumn: "ChampId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
