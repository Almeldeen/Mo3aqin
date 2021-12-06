using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Champ
    {
        public int ChampId { get; set; }
       
        public string ChampName { get; set; }
       
        public DateTime StartDate { get; set; }
       
        public DateTime EndDate { get; set; }
      
        
        public string Invitaion { get; set; }
       
        public int CountryId { get; set; }
        public string City { get; set; }
       
        public string Season { get; set; }
        
        public string ChampDuration { get; set; }
       
        public int EmpsNum { get; set; }
      
        public int PlayersNum { get; set; }
       
        public int CoachsNum { get; set; }
        public string CountryName { get; set; }



        public string GameName { get; set; }
        public string Notes { get; set; }
    }
}
