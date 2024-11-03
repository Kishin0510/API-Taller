using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Api_Taller.src.Helpers.Validators
{
    public class GenderValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var valueString = value?.ToString();

            if (valueString != null){
                if(!int.TryParse(valueString, out int GenderId))
                {
                    return new ValidationResult("Género no es válido");
                }
            }  

            return ValidationResult.Success;
        }   
    }
}