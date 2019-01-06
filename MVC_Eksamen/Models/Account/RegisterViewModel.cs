using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Eksamen.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress, MaxLength(500)]
        [Display(Name = "Email Adresse")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Brugernavn")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match")]
        [Display(Name = "Gentag adgangskoden")]
        public string ConfirmPassword { get; set; }
    }
}
