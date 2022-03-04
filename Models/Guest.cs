using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kutse_TSYBIREV.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public int Id;
        [Required(ErrorMessage = "Sisesta oma nimi")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sisesta oma email")]
        [RegularExpression(@".+\@.+\..+",ErrorMessage ="Viga emaili sisetamiseks")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Sisesta oma tel.")]
        [RegularExpression(@"\+372.+",ErrorMessage ="Vale telefoni number,Alusta +372...")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Tee oma valik!")]
        public bool? WillAttend { get; set; }
    }
}