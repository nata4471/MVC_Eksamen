using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Eksamen.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Brugernavn")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Adgangskoden er forkert")]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string Password { get; set; }



        [Display(Name = "Husk mig")]
        public bool RememberMe { get; set; }

    }
}
