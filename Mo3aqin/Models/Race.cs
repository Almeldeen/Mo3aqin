using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Race
    {
        [Key]
        public int RaceId { get; set; }
        public string RaceName { get; set; }
    }
}
