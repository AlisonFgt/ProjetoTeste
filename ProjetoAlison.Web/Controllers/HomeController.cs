using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAlison.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account", new { area = "" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Test Alison.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Page for contact.";

            return View();
        }
    }
}