using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("LocationForecast", "Weather");
        }

    }
}
