using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class addcountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Championships");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Championships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championships_CountryId",
                table: "Championships",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Championships_Countries_CountryId",
                table: "Championships",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championships_Countries_CountryId",
                table: "Championships");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Championships_CountryId",
                table: "Championships");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Championships");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Championships",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
