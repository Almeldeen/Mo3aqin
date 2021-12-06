using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class Decision_VM
    {
        public int DecId { get; set; }
        public DateTime DecDate { get; set; }
        public IFormFile DecFile { get; set; }
        public string DecFileStr { get; set; }
        public string Notes { get; set; }
        public string Name { get; set; }
        public int? Id { get; set; }
        
    }
}
