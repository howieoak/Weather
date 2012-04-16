using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Application.Location;
using Weather.Model.Domain;

namespace Weather.Controllers
{
    public class LocationController : Controller
    {
        //
        // GET: /Location/

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult Places()
        {
            IList<Place> places = LocationApp.GetPlacesTop("NO", 20);

            return View(places);
        }

        [HttpGet]
        public ViewResult Churches()
        {
            IList<Place> churches = LocationApp.GetChurchesTop("NO", 20);

            return View(churches);
        }

    }
}
