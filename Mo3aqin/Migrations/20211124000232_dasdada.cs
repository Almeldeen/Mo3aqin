using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class dasdada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "Players");
        }
    }
}
