using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Championship
    {
        [Key]
        public int ChampId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Invitaion { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Season { get; set; }
        public string ChampDuration { get; set; }
        public int EmpsNum { get; set; }
        public int PlayersNum { get; set; }
        public int CoachsNum { get; set; }
        public string Notes { get; set; }
        public championship_Games Championship_Games { get; set; }
    }
}
