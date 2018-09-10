using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menulog.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Search(string name = "french")   // TUT: we do not need Index() action here. so replaced with the Search() action
        {
            var message = Server.HtmlEncode(name);

            return Content(message);
        }
    }
}