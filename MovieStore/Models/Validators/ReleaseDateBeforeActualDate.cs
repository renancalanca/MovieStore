using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models.Validators
{
    public class ReleaseDateBeforeActualDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.ReleaseDate > DateTime.Now)
                return new ValidationResult("Release Date should be before actual date");

            return ValidationResult.Success;
        }
    }
}