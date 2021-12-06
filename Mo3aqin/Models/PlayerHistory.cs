using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class PlayerHistory
    {
        [Key]
        public int HisId { get; set; }
        public DateTime HisDate { get; set; }
        public string ChampName { get; set; }
        public int PlyerNum { get; set; }
        public int playerRating { get; set; }
        public string Notes { get; set; }
        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
