using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class Game_VM
    {
        public int GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        public string Notes { get; set; }
        public string CompetitionName { get; set; }
        [Required]
        public int? CompetitionId { get; set; }
    }
}
