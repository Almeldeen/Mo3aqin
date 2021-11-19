using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Coach
    {
        [Key]
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public string CoachImage { get; set; }
        public string CivilianCoach { get; set; }
        public string PassportImage { get; set; }
        public DateTime PassportExpDate { get; set; }
        public string PassportNumber { get; set; }
        
        public DateTime Birthdate { get; set; }
        public string MaritalStatus { get; set; }
        public string TimeType { get; set; }
        public string CivilianNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }
        public string Notes { get; set; }
        public byte Active { get; set; }
        [ForeignKey("Nationality")]
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public Championship Championship { get; set; }
        //public GameDetails GameDetails { get; set; }

    }
}
