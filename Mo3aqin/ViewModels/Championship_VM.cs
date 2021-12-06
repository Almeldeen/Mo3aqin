using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class Championship_VM
    {
        public int ChampId { get; set; }
        [Required(ErrorMessage = "ادخل الاسم")]
        [MinLength(3, ErrorMessage = "أقل من 3")]
        [MaxLength(50, ErrorMessage = "أكثر من 50")]
        public string ChampName { get; set; }
        [Required(ErrorMessage = "ادخل بداية البطولة")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "ادخل نهاية البطولة")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "ادخل صورة الدعوة")]
        public IFormFile Invitaion { get; set; }
        public string InvitaionStr { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر بلد")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "ادخل مدينة")]
        public string City { get; set; }
        [Required(ErrorMessage = "ادخل الموسم")]
        public string Season { get; set; }
        [Required(ErrorMessage = "ادخل مدة البطولة ")]
        public string ChampDuration { get; set; }
        [Required(ErrorMessage = "ادخل عدد الموظفين")]
        public int EmpsNum { get; set; }
        [Required(ErrorMessage = "ادخل عدد الاعبين")]
        public int PlayersNum { get; set; }
        [Required(ErrorMessage = "ادخل عدد المدربين")]
        public int CoachsNum { get; set; }
        [Required(ErrorMessage = "اختر لعبة علي الاقل")]
        public int[] GameIds { get; set; }
        public string GameIds2 { get; set; }
        public string Notes { get; set; }
    }
}
