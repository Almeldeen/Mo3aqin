using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class History_VM
    {
        public int HisId { get; set; }
        public DateTime HisDate { get; set; }
        public string ChampName { get; set; }
        public int PlyerNum { get; set; }
        public int playerRating { get; set; }
        public string Notes { get; set; }
      
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
