using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class GameDetail_VM
    {
        public int GameId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر مدب")]
        public int CoachId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر مدرب مساعد")]
        public int EmpId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر موظف")]
        public int CoachAssId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر مشرف")]
        public int SupervisorId { get; set; }
        [Required(ErrorMessage = "ادخل عدد الاعبين")]    
        public int PlayersNum { get; set; }
        public string Notes { get; set; }
    }
}
