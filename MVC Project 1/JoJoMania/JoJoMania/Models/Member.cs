using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JoJoMania.Models.Attributes;

namespace JoJoMania.Models
{
    public class Member
    {
        [Required(ErrorMessage = "The username field CANNOT be blank! A member MUST have a user name!")]
        public string UserName { get; set; }

        public int UserID { get; set; }

        [DataType(DataType.Date)]
        [AgeCheck]
        public DateTime AgeDate { get; set; }

        [Required(ErrorMessage = "The age field CANNOT be blank!")]
        [Range(13,110, ErrorMessage = "The age of a member must be AT LEAST 13 years of age, and AT MOST 110 years of age!")]
        public int? Age { get; set; }

        //[MustChooseJoJo(ErrorMessage = "Members MUST choose their favorite JoJo!")]
        //[Required(ErrorMessage = "Members MUST choose their favorite JoJo!")]
        public JoJo FavJoJo { get; set; }

        //[MustChoosePart(ErrorMessage = "Members MUST choose their favorite part of the JoJo series!")]
        //[Required(ErrorMessage = "Members MUST choose their favorite part of the JoJo series!")]
        public Part FavPart { get; set; }

        //[Required(ErrorMessage = "Members MUST choose their favorite JoJo!")]
       // [MustChooseJoJo(ErrorMessage = "Members MUST choose their favorite JoJo!")]
       // public string FavJoJoString { get; set; }

        //[Required(ErrorMessage = "Members MUST choose their favorite part of the JoJo series!")]
       // [MustChoosePart(ErrorMessage = "Members MUST choose their favorite part of the JoJo series!")]
       // public string FavPartString { get; set; }

    }
}