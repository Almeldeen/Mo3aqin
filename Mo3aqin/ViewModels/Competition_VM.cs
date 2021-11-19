using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class Competition_VM
    {
        public int CompetitionId { get; set; }
        [Required]
        public string CompetitionName { get; set; }
    }
}
