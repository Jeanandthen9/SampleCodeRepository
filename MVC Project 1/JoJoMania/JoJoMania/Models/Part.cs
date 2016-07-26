using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JoJoMania.Models.Attributes;

namespace JoJoMania.Models
{
    public class Part
    {
        public string PartName { get; set; }

        [Required(ErrorMessage = "MEMBER MUST SELECT A FAVORITE JOJO")]
        public int PartNumber { get; set; }
    }
}