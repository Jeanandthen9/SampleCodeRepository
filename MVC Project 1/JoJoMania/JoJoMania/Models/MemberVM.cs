using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoJoMania.Models.Data.JoJoRepo;
using JoJoMania.Models.Data.PartRepo;

namespace JoJoMania.Models
{
    public class MemberVM
    {
        public Member Member { get; set; }

        //[Required(ErrorMessage = "Members MUST choose their favorite JoJo!")]
        //public SelectListItem<JoJo> JoJoItems { get; set; }

        //[Required(ErrorMessage = "Members MUST choose their favorite part of the JoJo series!")]
        //public IEnumerable<Part> PartItems { get; set; }

        [Required(ErrorMessage = "Members MUST choose their favorite JoJo!")]
        public IEnumerable<JoJo> JoJoItems { get; set; }

        [Required(ErrorMessage = "Members MUST choose their favorite part of the JoJo series!")]
        public IEnumerable<Part> PartItems { get; set; }

        //[Required(ErrorMessage = "Members MUST choose their favorite JoJo!")]
        //public string SelectedJoJoID { get; set; }

        //[Required(ErrorMessage = "Members MUST choose their favorite part of the JoJo series!")]
        //public string SelectedPartNum { get; set; }

        public MemberVM()
        {
            Member = new Member();
            JoJoItems = JoJoRepository.GetAll();
            PartItems = PartRepository.GetAll();
        }

        //public void SetJoJoItems(IEnumerable<JoJo> jojos)
        //{
        //    foreach (var jojo in jojos)
        //    {
        //        JoJoItems.Add(new SelectListItem()
        //        {
        //            Value = jojo.ID.ToString(),
        //            Text = jojo.FirstName + " " + jojo.LastName
        //        });
        //    }
        //}

        //public void SetPartItems(IEnumerable<Part> parts)
        //{
        //    foreach (var part in parts)
        //    {
        //        PartItems.(new SelectListItem()
        //        {
        //            Value = part.PartNumber.ToString(),
        //            Text = part.PartName
        //        });
        //    }
        //}

        //public void SetSelectedJoJoAndPart()
        //{
        //    SelectedJoJo = JoJoRepository.Get(SelectedJoJo.ID);
        //    SelectedPart = PartRepository.Get(SelectedPart.PartNumber);
        //}

       
    }
}