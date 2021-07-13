using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CountryData;
using FullWeb.Validations;
namespace FullWeb.Models
{
    public class Volunteer 
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [Display(Name ="First Name(s): ")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name ="Last Name: ")]
        public string Surname { get; set; }

        [Required]
        [VolunteerMustBe18YearsOld]
        [Display(Name ="Enter your date of birth: ")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name ="Select Country of Residence: ")]
        
        public static IEnumerable <string> Country { get; set; } //as a list

        public Project Project { get; set; } //as a list
        public int ProjectId { get; set; }

        public bool NeedsConsent { get; set; }
    }
}
