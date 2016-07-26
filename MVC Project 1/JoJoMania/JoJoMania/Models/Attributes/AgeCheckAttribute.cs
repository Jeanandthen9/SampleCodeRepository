using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoJoMania.Models.Attributes
{
    public class AgeCheckAttribute : RequiredAttribute
    {
        // got this from StackOverflow!
        // custom attribute to check if the age is 13 or over using DateTime calander!
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("You cannot leave this field empty!");
            }

            DateTime date = Convert.ToDateTime(value);

            if (DateTime.Today.AddYears(-13) >= date)
            {
                return ValidationResult.Success;
            }

            else
            {
                return new ValidationResult("Members must be 13 years of age or older to use this website!");
            }
        }

    }
}