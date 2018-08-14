
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel.Account
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(6,ErrorMessage ="Min length is 6 characters")]
        [Display(Name = "Username or email", Prompt = "Your user name")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8,ErrorMessage ="Min length is 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string PassWord { get; set; }

        [Required]
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
