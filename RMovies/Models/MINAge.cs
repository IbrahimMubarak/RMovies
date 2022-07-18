
using RMovies.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMovies.Models
{
    public class MINAge : ValidationAttribute
    {

      
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var customer = (Customer)validationContext.ObjectInstance;
                var age = DateTime.Now.Year - customer.birthday.Year;

                return (age >= 18&&age<=80) ? ValidationResult.Success :
                    new ValidationResult("Sorry your age is out of range");
            }
        }
    }
