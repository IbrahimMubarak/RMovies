using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RMovies.Models
{
    public class Min18YearIfaMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Customer = (Customer)validationContext.ObjectInstance;
            if (Customer.MembershipTypeId == 1)
             return ValidationResult.Success; 
           
            var age = DateTime.Now.Year - Customer.birthday.Year;
            if(age<18)
            {
                return new ValidationResult("Customer should be at least 18 years old to be a member");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

    }
}