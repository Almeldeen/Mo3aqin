using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class ll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Nationality_NationalityId",
                table: "Coaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nationality",
                table: "Nationality");

            migrationBuilder.RenameTable(
                name: "Nationality",
                newName: "Nationalities");

            migrationBuilder.AlterColumn<string>(
                name: "NationalityName",
                table: "Nationalities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nationalities",
                table: "Nationalities",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Nationalities_NationalityId",
                table: "Coaches",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Nationalities_NationalityId",
                table: "Coaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nationalities",
                table: "Nationalities");

            migrationBuilder.RenameTable(
                name: "Nationalities",
                newName: "Nationality");

            migrationBuilder.AlterColumn<int>(
                name: "NationalityName",
                table: "Nationality",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nationality",
                table: "Nationality",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Nationality_NationalityId",
                table: "Coaches",
                column: "NationalityId",
                principalTable: "Nationality",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
