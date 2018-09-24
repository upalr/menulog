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
        MenulogDb _db = new MenulogDb();
        public ActionResult Index(string searchTerm = null) // MVC is going to send null if it does not find any searchTerm but we are passing null here because of passing the Unit Test.
        {
            var controller = RouteData.Values["controller"]; //TUT RouteData is a data structure. building by the routing engine.
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];
            var message = String.Format("{0}::{1} {2}", controller, action, id);
            ViewBag.message = message;

            //var model = _db.Restaurants.ToList();
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select r;

            //TUT: Comprehensive Query Syntex
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select new RestaurantListViewModel
            //            {
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };

            //TUT: Extension Method Syntax
            var model = _db.Restaurants
                           .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                           .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                           .Take(10) // Extra than the Comprehensive Syntex Query
                           .Select(r => new RestaurantListViewModel
                           {
                               Id = r.Id,
                               Name = r.Name,
                               City = r.City,
                               Country = r.Country,
                               CountOfReviews = r.Reviews.Count()
                           });

            return View(model);
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
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}