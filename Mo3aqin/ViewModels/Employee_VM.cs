using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class Employee_VM
    {
        public int EmpId { get; set; }
        [Required(ErrorMessage ="ادخل الاسم")]
        [MinLength(3,ErrorMessage ="أقل من 3")]
        [MaxLength(50, ErrorMessage = "أكثر من 50")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "ادخل المسمى الوظيفى")]
        public string JopName { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public IFormFile EmpImage { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public IFormFile CivilianEmp { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public IFormFile PassportImage { get; set; }
        public string EmpImageString { get; set; }
        public string CivilianEmpString { get; set; }
        public string PassportImageString { get; set; }
        [Required(ErrorMessage = "ادخل تاريخ انتهاء جواز السفر")]
        public DateTime PassportExpDate { get; set; }
        [Required(ErrorMessage = "ادخل رقم جواز السفر")]
        public string PassportNumber { get; set; }
        
        public string Nationality { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر جنسية")]
        public int NationalityId { get; set; }
        [Required(ErrorMessage = "ادخل تاريخ الميلاد")]
        public DateTime Birthdate { get; set; }
        public string MaritalStatus { get; set; }
        public string TimeType { get; set; }
        [Required(ErrorMessage = "ادخل الرقم القومى")]
        public string CivilianNumber { get; set; }
        [Required(ErrorMessage = "ادخل العنوان")]
        public string Address { get; set; }
        [Required(ErrorMessage = "ادخل رقم الهاتف")]
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }
        public string Notes { get; set; }
        public byte Active { get; set; }
    }
}
