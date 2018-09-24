using Menulog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menulog.Controllers
{
    public class ReviewsController : Controller
    {
        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var bestReview = from r in _reviews
                             orderby r.Rating descending
                             select r;

            return PartialView("_Review", bestReview.First());
        }

        // GET: Reviews
        public ActionResult Index()
        {
            var model = from r in _reviews
                        orderby r.Id
                        select r;

            return View(model);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            var review = _reviews.Single(r => r.Id == id);

            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = _reviews.Single(r => r.Id == id);
            if (TryUpdateModel(review))   // TUT: For understand more about TryUpdateModel() see video 4."Html Helper"
            {
                //..
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        static List<RestaurantReview> _reviews = new List<RestaurantReview>
            {
            new RestaurantReview{
                Id= 1,
                Rating = 10,
                Body= "Yeammy food"
            },
            new RestaurantReview{
                Id = 2,
                Body = "Amazing coffee",
                Rating=10
            },
            new RestaurantReview{
                Id = 3,
                Body = "bEST pIZZZA",
                Rating = 10
            }
        };
    }
}
