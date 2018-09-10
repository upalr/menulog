﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menulog.Controllers
{
    public class CuisineController : Controller
    {
        [HttpPost]
        public ActionResult Search(string name = "french")   // TUT: according to the routes, we do not need Index() action here. so replaced with the Search() action
        {
            var message = Server.HtmlEncode(name);

            return Content(message);
            //return RedirectToAction("Index", "Home", new { name = name });
        }

        [HttpGet]
        public ActionResult Search()
        {
            return Content("Search!");
        }
    }
}