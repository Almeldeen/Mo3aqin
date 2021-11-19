using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.ViewModels
{
    public class EditUserViewModel
    {
        public string UserId { get; set; }
        [Required, StringLength(30)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
