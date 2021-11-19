using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class addtabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Coaches");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Coaches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.NationalityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_NationalityId",
                table: "Coaches",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Nationality_NationalityId",
                table: "Coaches",
                column: "NationalityId",
                principalTable: "Nationality",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Nationality_NationalityId",
                table: "Coaches");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_NationalityId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Coaches");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
