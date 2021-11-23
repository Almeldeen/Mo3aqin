using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class Class_VM
    {
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        public string ClassDis { get; set; }
        //[Required]
        //public int GameId { get; set; }
        //public string GameName { get; set; }
    }
}
