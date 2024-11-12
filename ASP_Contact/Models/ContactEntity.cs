using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ASP_Contact.Models.Priority;


namespace ASP_Contact.Models
{
    [Table(name:"contacts")]
    public class ContactEntity
    {
        [HiddenInput]
        public int id { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string surname { get; set; }
        [Required]
        [Display(Name = "Telefon")]
        public string phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Data Urodzenia")]
        public DateTime dateOfBirth { get; set; }
        [Display(Name = "Prirytety")]
        public Priority Priority { get; set; }
        public DateTime Created { get; set; }
        public int OrganizationId { get; set; }
        public OrganizationEntity? Organization { get; set; }

    }
}
