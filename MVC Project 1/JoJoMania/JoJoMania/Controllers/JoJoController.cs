using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoJoMania.Models;
using JoJoMania.Models.CustomCode;
using JoJoMania.Models.Data;
using JoJoMania.Models.Data.JoJoRepo;
using JoJoMania.Models.Data.PartRepo;

namespace JoJoMania.Controllers
{
    public class JoJoController : Controller
    {
        // GET: JoJo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JoJoList()
        {
            var jojoList = JoJoRepository.GetAll();
            return RedirectToAction("Index", jojoList);
        }

        public ActionResult Part1()
        {
            var part1 = PartRepository.Get(1);
            var jojo1 = JoJoRepository.Get(1);
            PartVM partInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = jojo1.Age,
                    FirstName = jojo1.FirstName,
                    LastName = jojo1.LastName,
                    ID = jojo1.ID,
                    ImageURL = jojo1.ImageURL,
                    PartDebut = jojo1.PartDebut,
                    Story = jojo1.Story
                },
                Part = new Part()
                {
                    PartNumber = part1.PartNumber,
                    PartName = part1.PartName
                }
            };

            return View("PartView", partInfo);
        }

        public ActionResult Part2()
        {
            var part2 = PartRepository.Get(2);
            var jojo2 = JoJoRepository.Get(2);
            PartVM partInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = jojo2.Age,
                    FirstName = jojo2.FirstName,
                    LastName = jojo2.LastName,
                    ID = jojo2.ID,
                    ImageURL = jojo2.ImageURL,
                    PartDebut = jojo2.PartDebut,
                    Story = jojo2.Story
                },
                Part = new Part()
                {
                    PartNumber = part2.PartNumber,
                    PartName = part2.PartName
                }
            };
            return View("PartView", partInfo);
        }

        public ActionResult Part3()
        {
            var part3 = PartRepository.Get(3);
            var jojo3 = JoJoRepository.Get(3);
            PartVM partInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = jojo3.Age,
                    FirstName = jojo3.FirstName,
                    LastName = jojo3.LastName,
                    ID = jojo3.ID,
                    ImageURL = jojo3.ImageURL,
                    PartDebut = jojo3.PartDebut,
                    Story = jojo3.Story
                },
                Part = new Part()
                {
                    PartNumber = part3.PartNumber,
                    PartName = part3.PartName
                }
            };
            return View("PartView", partInfo);
        }

        public ActionResult Part4()
        {
            var part4 = PartRepository.Get(4);
            var jojo4 = JoJoRepository.Get(4);
            PartVM partInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = jojo4.Age,
                    FirstName = jojo4.FirstName,
                    LastName = jojo4.LastName,
                    ID = jojo4.ID,
                    ImageURL = jojo4.ImageURL,
                    PartDebut = jojo4.PartDebut,
                    Story = jojo4.Story
                },
                Part = new Part()
                {
                    PartNumber = part4.PartNumber,
                    PartName = part4.PartName
                }
            };
            return View("PartView", partInfo);
        }

        public ActionResult Part5()
        {
            var part5 = PartRepository.Get(5);
            var jojo5 = JoJoRepository.Get(5);
            PartVM partInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = jojo5.Age,
                    FirstName = jojo5.FirstName,
                    LastName = jojo5.LastName,
                    ID = jojo5.ID,
                    ImageURL = jojo5.ImageURL,
                    PartDebut = jojo5.PartDebut,
                    Story = jojo5.Story
                },
                Part = new Part()
                {
                    PartNumber = part5.PartNumber,
                    PartName = part5.PartName
                }
            };
            return View("PartView", partInfo);
        }

        public ActionResult Part6()
        {
            var part6 = PartRepository.Get(6);
            var jojo6 = JoJoRepository.Get(6);
            PartVM partInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = jojo6.Age,
                    FirstName = jojo6.FirstName,
                    LastName = jojo6.LastName,
                    ID = jojo6.ID,
                    ImageURL = jojo6.ImageURL,
                    PartDebut = jojo6.PartDebut,
                    Story = jojo6.Story
                },
                Part = new Part()
                {
                    PartNumber = part6.PartNumber,
                    PartName = part6.PartName
                }
            };
            return View("PartView", partInfo);
        }

        public ActionResult Part7()
        {
            var part7 = PartRepository.Get(7);
            var jojo7 = JoJoRepository.Get(7);
            PartVM partInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = jojo7.Age,
                    FirstName = jojo7.FirstName,
                    LastName = jojo7.LastName,
                    ID = jojo7.ID,
                    ImageURL = jojo7.ImageURL,
                    PartDebut = jojo7.PartDebut,
                    Story = jojo7.Story
                },
                Part = new Part()
                {
                    PartNumber = part7.PartNumber,
                    PartName = part7.PartName
                }
            };
            return View("PartView", partInfo);
        }

        public ActionResult Part8()
        {
            var part8 = PartRepository.Get(8);
            var jojo8 = JoJoRepository.Get(8);
            PartVM partInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = jojo8.Age,
                    FirstName = jojo8.FirstName,
                    LastName = jojo8.LastName,
                    ID = jojo8.ID,
                    ImageURL = jojo8.ImageURL,
                    PartDebut = jojo8.PartDebut,
                    Story = jojo8.Story
                },
                Part = new Part()
                {
                    PartNumber = part8.PartNumber,
                    PartName = part8.PartName
                }
            };
            return View("PartView", partInfo);
        }

        public ActionResult RandomPart()
        {
           int randomPart = JoJoRandomizer.GetRandomNum(1, 8);

            var randomJoJoPart = PartRepository.Get(randomPart);
            var randomJoJo = JoJoRepository.Get(randomPart);
            PartVM randomPartInfo = new PartVM()
            {
                JoJo = new JoJo()
                {
                    Age = randomJoJo.Age,
                    FirstName = randomJoJo.FirstName,
                    LastName = randomJoJo.LastName,
                    ID = randomJoJo.ID,
                    ImageURL = randomJoJo.ImageURL,
                    PartDebut = randomJoJo.PartDebut,
                    Story = randomJoJo.Story
                },
                Part = new Part()
                {
                    PartNumber = randomJoJoPart.PartNumber,
                    PartName = randomJoJoPart.PartName
                }
            };
            return View("PartView", randomPartInfo);
        }
    }
}