using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Homepage()
        {
            return View();
        }
        public ActionResult Users()
        {
            return RedirectToAction("Users", "Admin");
        }
        public ActionResult Books()
        {
            return RedirectToAction("Books", "Books");
        }
    }
}
