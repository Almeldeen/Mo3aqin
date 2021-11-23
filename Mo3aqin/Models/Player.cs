using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string MemberId { get; set; }
        public int PassportNum { get; set; }
        public DateTime PassportExpDate { get; set; }
        public String PassportImg { get; set; }
        public string PlayerImage { get; set; }
        public string PlayerCity { get; set; }
        public string BirthOfDateImage { get; set; }

        public DateTime BirthOfDate { get; set; }
        [ForeignKey("Nationality")]
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }

        public string MaritalStatus { get; set; }
        public string MedicalReportImg { get; set; }
        public string DisableImg { get; set; }
        public string CivilianNumber { get; set; }
        public string WorkPlace { get; set; }
        public string Governorate { get; set; }
        public string Regain { get; set; }
        public string Plot { get; set; }
        public string Gada { get; set; }
        public string ParentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }
        public string OtherNumber { get; set; }
        public string DocRecommendation { get; set; }
        public bool Active { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public string Disabality { get; set; }
        public string Notes { get; set; }
    }
}
