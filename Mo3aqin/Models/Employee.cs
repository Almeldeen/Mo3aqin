using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string JopName { get; set; }
        public string EmpImage { get; set; }
        public string CivilianCoach { get; set; }
        public string PassportImage { get; set; }
        public DateTime PassportExpDate { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public DateTime Birthdate { get; set; }
        public string MaritalStatus { get; set; }
        public string TimeType { get; set; }
        public string CivilianNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        //public GameDetails GameDetails { get; set; }
        public Championship Championship { get; set; }
    }
}
