using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using JoJoMania.Models.Attributes;

namespace JoJoMania.Models
{
    public class JoJo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format(FirstName + " " + LastName); }
        }

        public int Age { get; set; }
        public Part PartDebut { get; set; }

        [Required(ErrorMessage = "MEMBER MUST SELECT A FAVORITE JOJO")]
        public int ID { get; set; }
        public Uri ImageURL { get; set; }
        public string Story { get; set; }

    }
}