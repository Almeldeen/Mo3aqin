using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class addchampstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChampStatuses",
                columns: table => new
                {
                    ChampStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampId = table.Column<int>(type: "int", nullable: false),
                    ChampInvChek = table.Column<byte>(type: "tinyint", nullable: false),
                    ChampInvLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegNumChek = table.Column<byte>(type: "tinyint", nullable: false),
                    RegNumlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelegChek = table.Column<byte>(type: "tinyint", nullable: false),
                    SportFreeTimeChek = table.Column<byte>(type: "tinyint", nullable: false),
                    AddresTheauthChek = table.Column<byte>(type: "tinyint", nullable: false),
                    PayOfFeesChek = table.Column<byte>(type: "tinyint", nullable: false),
                    RegByNamesChek = table.Column<byte>(type: "tinyint", nullable: false),
                    RegByNamesLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromisChek = table.Column<byte>(type: "tinyint", nullable: false),
                    BookTicketChek = table.Column<byte>(type: "tinyint", nullable: false),
                    BookTicketLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceChek = table.Column<byte>(type: "tinyint", nullable: false),
                    VisaChek = table.Column<byte>(type: "tinyint", nullable: false),
                    PRChek = table.Column<byte>(type: "tinyint", nullable: false),
                    UniformChek = table.Column<byte>(type: "tinyint", nullable: false),
                    ResultsChek = table.Column<byte>(type: "tinyint", nullable: false),
                    ResultsLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RePortChek = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampStatuses", x => x.ChampStatusId);
                    table.ForeignKey(
                        name: "FK_ChampStatuses_Championships_ChampId",
                        column: x => x.ChampId,
                        principalTable: "Championships",
                        principalColumn: "ChampId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampStatuses_ChampId",
                table: "ChampStatuses",
                column: "ChampId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampStatuses");
        }
    }
}
