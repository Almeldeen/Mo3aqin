using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserManagementWithIdentity.ViewModels;

namespace Mo3aqin.ViewModels
{
    public class AddUserViewModel
    {
       
        [Required, StringLength(30)]     
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public List<CheckBoxViewModel> Roles { get; set; }
    }
}
