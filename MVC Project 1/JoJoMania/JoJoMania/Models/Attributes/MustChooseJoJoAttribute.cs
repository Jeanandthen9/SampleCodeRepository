using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JoJoMania.Models.Data.JoJoRepo;

namespace JoJoMania.Models.Attributes
{
    public class MustChooseJoJoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ((string)value != "" && int.Parse(value.ToString()) >= 0 && int.Parse(value.ToString()) <= 8);
        }
    }
}