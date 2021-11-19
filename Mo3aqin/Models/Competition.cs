using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public Game Game { get; set; }
    }
}
