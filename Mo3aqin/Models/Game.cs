using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string GameName { get; set; }
        [ForeignKey("Competition")]
        public int? CompetitionId { get; set; }
        public string Notes { get; set; }
        //public bool Active { get; set; }
        public Competition Competition { get; set; }

        //public GameDetails GameDetails { get; set; }
        //public championship_Games Championship_Games { get; set; }
        //public Class Class { get; set; }
        public List<Championship> Championships { get; set; }
        public List<ChampionshipGames> ChampionshipGames { get; set; }

    }
}
