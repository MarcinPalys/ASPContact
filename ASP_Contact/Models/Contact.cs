using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_Contact.Models
{
    public class Contact
    {
        [HiddenInput]
        public int id { get; set; }
        [Required(ErrorMessage = "Proszę podać imię")]
        [Display(Name = "Imię")]
        public string name { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko")]
        [Display(Name = "Nazwisko")]
        public string surname { get; set; }
        [Required(ErrorMessage = "Proszę podać numer telefonu")]
        [Display(Name = "Telefon")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Proszę podać email")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Proszę podać datę urodzenia")]
        [Display(Name = "Data Urodzenia")]
        public DateTime dateOfBirth { get; set; }
        [Display(Name = "Prirytety")]
        public Priority Priority{ get; set; }
    }
}
