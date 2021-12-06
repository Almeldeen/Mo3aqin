using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class PlayerDecision
    {
        [Key]
        public int DecId { get; set; }
        public DateTime DecDate { get; set; }
        public string DecFile { get; set; }
        public string Notes { get; set; }
        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
