using Microsoft.AspNetCore.Http;
using Mo3aqin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class Player_VM
    {
        public int PlayerId { get; set; }
        [Required(ErrorMessage ="أدخل الاسم")]
        public string PlayerName { get; set; }
        [Required(ErrorMessage = "أدخل رقم العضوية")]
        public string MemberId { get; set; }
        [Required(ErrorMessage = "أدخل رقم الجواز")]
        public string PassportNum { get; set; }
      
        public DateTime PassportExpDate { get; set; }
        public DateTime RegDate { get; set; }
       
        public IFormFile PassportImg { get; set; }
        public string PassportImgStr { get; set; }
        
        public IFormFile PlayerImage { get; set; }
        public string PlayerImageStr { get; set; }
       
        public IFormFile PlayerCityImg { get; set; }
        public string PlayerCityImgStr { get; set; }
       
        public IFormFile BirthOfDateImage { get; set; }
        public string BirthOfDateImageStr { get; set; }
       
        public DateTime BirthOfDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر جنسية")]
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }

        public string MaritalStatus { get; set; }
        
        public IFormFile MedicalReportImg { get; set; }
        public string MedicalReportImgStr { get; set; }
       
        public IFormFile DisableImg { get; set; }
        public string DisableImgStr { get; set; }
        [Required(ErrorMessage = "أدخل الرقم المدنى")]
        public string CivilianNumber { get; set; }
        [Required(ErrorMessage = "أدخل مكان العمل")]
        public string WorkPlace { get; set; }
        [Required(ErrorMessage = "أدخل المحافظة")]
        public string Governorate { get; set; }
        [Required(ErrorMessage = "أدخل المنطقة")]
        public string Regain { get; set; }
        public string Plot { get; set; }
        public string Gada { get; set; }
        [Required(ErrorMessage = "أدخل رقم الوالد")]
        public string ParentNumber { get; set; }
        [Required(ErrorMessage = "أدخل رقم الهاتف")]
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }
        public string OtherNumber { get; set; }
        public string DocRecommendation { get; set; }
        [Required(ErrorMessage = "أدخل حالة اللاعب")]
        public byte Active { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر الفئة")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        [Required(ErrorMessage = "أدخل  الاعاقة")]
        public string Disabality { get; set; }
        [Required(ErrorMessage = "اختر لعبة علي الاقل")]
        public int[] GameIds { get; set; }
        public string GameIds2 { get; set; }
        public string Notes { get; set; }
    }
}
