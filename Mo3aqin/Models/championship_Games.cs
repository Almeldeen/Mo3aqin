using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class championship_Games
    {
        [Column(Order = 1), Key, ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        [Column(Order = 2), Key, ForeignKey("Championship")]
        public int ChampId { get; set; }
        public virtual Championship Championship { get; set; }
    }
}
