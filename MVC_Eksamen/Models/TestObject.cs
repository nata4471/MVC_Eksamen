using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Eksamen.Models
{
    public class TestObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Skriv tekst")]
        [Display(Name ="Tekst")]
        public string Text { get; set; }
        [Display(Name = "Dato")]
        public DateTime Posted { get; set; }
    }
}
