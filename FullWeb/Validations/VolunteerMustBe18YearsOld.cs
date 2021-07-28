using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace FullWeb.Validations
{
    public class VolunteerMustBe18YearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var volunteer = (Volunteer)validationContext.ObjectInstance;

            

            var age = DateTime.Now.Year - volunteer.BirthDate.Year;

            return (age >= 18)
                ?
                 ValidationResult.Success :

                    new ValidationResult("You should be at least 18 years old or have consent from a guardian to volunteer abroad. ");
        }
      
    }
}
