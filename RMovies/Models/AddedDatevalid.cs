using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RMovies.Models
{
    public class AddedDatevalid:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.dateAdded.Year >=DateTime.Now.Year)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is out of range");
            }
        }
    }
    }
