using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoJoMania.Models;
using JoJoMania.Models.Data.JoJoRepo;
using JoJoMania.Models.Data.MemberRepo;
using JoJoMania.Models.Data.PartRepo;

namespace JoJoMania.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region MEMBERS
        public ActionResult MembersList()
        {
            var membersModel = MemberRepository.GetAll();
            return View(membersModel);
        }

        public ActionResult AddMember()
        {
            var memberModel = new MemberVM();
            memberModel.JoJoItems = JoJoRepository.GetAll();
            memberModel.PartItems = PartRepository.GetAll();
            return View(memberModel);
        }

        [HttpPost]
        public ActionResult AddMember(MemberVM newMember)
        {
            if (ModelState.IsValid)
            {
                newMember.Member.FavJoJo = JoJoRepository.Get(newMember.Member.FavJoJo.ID);
                newMember.Member.FavPart = PartRepository.Get(newMember.Member.FavPart.PartNumber);
                MemberRepository.Add(newMember.Member);
                return RedirectToAction("MembersList");
            }
            else
            {
                // if there were errors in validation, the values in the drop down lists would keep disappearing
                // went to stack overflow to get an answer!

                // we need to RELOAD and REPOPULATE the dropdown
                newMember.JoJoItems = JoJoRepository.GetAll();
                newMember.PartItems = PartRepository.GetAll();
                return View(newMember);
            }
            
        }

        public ActionResult EditMember(int id)
        {
            var memberModel = new MemberVM();

            memberModel.Member = MemberRepository.Get(id);
            memberModel.JoJoItems = JoJoRepository.GetAll();
            memberModel.PartItems = PartRepository.GetAll();

            return View(memberModel);
        }

        [HttpPost]
        public ActionResult EditMember(MemberVM newMember)
        {
            if (!ModelState.IsValid)
            {
                return View(newMember);
            }
            else
            {
                newMember.Member.FavJoJo = JoJoRepository.Get(newMember.Member.FavJoJo.ID);
                newMember.Member.FavPart = PartRepository.Get(newMember.Member.FavPart.PartNumber);
                MemberRepository.Edit(newMember.Member);
                return RedirectToAction("MembersList");
            }
        }

        public ActionResult DeleteMember(int id)
        {
            var memberModel = new MemberVM();
            memberModel.Member = MemberRepository.Get(id);
            return View(memberModel);
        }

        [HttpPost, ActionName("DeleteMember")]
        public ActionResult DeleteMemberConfirmed(int id)
        {
            MemberRepository.Get(id);
            MemberRepository.Delete(id);
            return RedirectToAction("MembersList");
        }
        #endregion

        #region JOJO
        public ActionResult JoJoList()
        {

            var jojoModel = JoJoRepository.GetAll();
            foreach (var joJo in jojoModel)
            {
                joJo.PartDebut = PartRepository.Get(joJo.PartDebut.PartNumber);
            }
            return View(jojoModel);
        }
        #endregion
    }
}