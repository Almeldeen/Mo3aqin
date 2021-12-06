using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class ChampionshipGames
    {
        //[Key]
        //public int ChampGameId { get; set; }
        //[ForeignKey("Game")]
        //public int GameId { get; set; }
        //public Game Game { get; set; }
        //[ForeignKey("Championship")]
        //public int ChampId { get; set; }
        //public Championship Championship { get; set; }

        //[Column(Order = 0), Key, ForeignKey("Game")]
        public int GameId { get; set; }
        //[Column(Order = 1), Key, ForeignKey("Championship")]
        public int ChampId { get; set; }
        public Game Game { get; set; }
        public Championship Championship { get; set; }
    }
}
