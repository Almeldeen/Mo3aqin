using Microsoft.EntityFrameworkCore.Migrations;

namespace Mo3aqin.Migrations
{
    public partial class filtr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[FilterChamp]
     @startdate datetime= NULL
    ,@enddate datetime= NULL
    ,@name nvarchar(max) = NULL
    ,@season nvarchar(max)= NULL
	,@country int= NULL
	,@city nvarchar(MAX) = NULL
	,@game int= NULL 
AS
SELECT DISTINCT 
*
FROM Championships
left join Countries on Championships.CountryId=Countries.CountryId
left join Championship_Games on Championships.ChampId=Championship_Games.ChampId
left join Games on Championship_Games.GameId=Games.GameId
WHERE Championships.StartDate=isnull(@startdate,Championships.StartDate)
and Championships.EndDate=isnull(@enddate,Championships.EndDate)
 and Championships.ChampName LIKE '%' +isnull(@name,Championships.ChampName) + '%'
 and Championships.Season=isnull(@season,Championships.Season)
    and Championships.CountryId =isnull(@country,Championships.CountryId)
	 and Championship_Games.GameId =isnull(@game,Championship_Games.GameId)
    and Championships.City LIKE '%' +isnull(@city,Championships.City) + '%'";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"drop PROCEDURE[dbo].[FilterChamp]";
            migrationBuilder.Sql(sp);
        }
    }
}
