using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Coach_Emp_Games
    {
        [Column(Order = 0), Key, ForeignKey("Coach")]
        public int CoachId { get; set; }
        public virtual Coach Coach { get; set; }
        [Column(Order = 1), Key, ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        [Column(Order = 2), Key, ForeignKey("Employee")]
        public int EmpId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
