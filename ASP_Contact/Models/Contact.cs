using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_Contact.Models
{
    public class Contact
    {
        [HiddenInput]
        public int id { get; set; }
        [Required(ErrorMessage = "Proszę podać imię")]
        public string name { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko")]
        public string surname { get; set; }
        [Required(ErrorMessage = "Proszę podać numer telefonu")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Proszę podać email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Proszę podać datę urodzenia")]
        public DateTime dateOfBirth { get; set; }
    }
}
