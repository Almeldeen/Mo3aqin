using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class PlayerGames
    {
        [Column(Order = 0), Key,ForeignKey("Game")]
        public int GameId { get; set; }
        [Column(Order = 1), Key,ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}
