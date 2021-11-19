using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class Coach_VM
    {
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public IFormFile CoachImage { get; set; }
        public IFormFile CivilianCoach { get; set; }
        public IFormFile PassportImage { get; set; }
        public string CoachImageString { get; set; }
        public string CivilianCoachString { get; set; }
        public string PassportImageString { get; set; }
        public DateTime PassportExpDate { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public int NationalityId { get; set; }
        public DateTime Birthdate { get; set; }
        public string MaritalStatus { get; set; }
        public string TimeType { get; set; }
        public string CivilianNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }
        public string Notes { get; set; }
        public byte Active { get; set; }
    }
}
