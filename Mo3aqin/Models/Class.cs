using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class Class
    {
        [ Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDis { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
