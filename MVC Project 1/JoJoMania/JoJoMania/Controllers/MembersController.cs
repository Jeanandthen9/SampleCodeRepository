﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoJoMania.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }
    }
}