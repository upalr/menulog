using Menulog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menulog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"]; //TUT RouteData is a data structure. building by the routing engine.
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];
            var message = String.Format("{0}::{1} {2}", controller, action, id);
            ViewBag.message = message;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //ViewBag.Location = "Melbourne, Australia";   // TUT: Use of viewbag
            var model = new AboutModel();
            model.Name = "Upal";
            model.Location = "Melbourne, Australia";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}