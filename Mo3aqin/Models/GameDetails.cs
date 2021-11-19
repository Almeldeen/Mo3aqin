using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class GameDetails
    {
        [Column(Order = 0), Key, ForeignKey("Coach")]
        public int CoachId { get; set; }
        public virtual Coach Coach { get; set; }
        [Column(Order = 1), Key, ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        [Column(Order = 2), Key, ForeignKey("Employee")]
        public int EmpId { get; set; }      
        [Column(Order = 3), Key, ForeignKey("Coach2")]
        public int CoachAssId { get; set; }
        public virtual Coach Coach2 { get; set; }
        [Column(Order = 4), Key, ForeignKey("Employee2")]
        public int SupervisorId { get; set; }
        public  Employee Employee2 { get; set; }
        public int PlayersNum { get; set; }
        public string Notes { get; set; }
        
        public virtual Employee Employee { get; set; }


    }
}
