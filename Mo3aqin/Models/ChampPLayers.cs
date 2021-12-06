using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class ChampPLayers
    {
        [Column(Order = 0), Key, ForeignKey("Championship")]
        public int ChampId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Championship Championship { get; set; }
        public Player Player { get; set; }
    }
}
