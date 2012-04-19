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
        public ActionResult Index()
        {
            return View();
        }

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

        public PartialViewResult Search(string place)
        {
            IList<Place> places = LocationApp.GetPlacesThatStartsWith("NO", place);

            return PartialView("_LocationSearchResult", places);
        }

        public JsonResult QuickSearch(string term)
        {
            var places = LocationApp.AutocompleteGetPlacesThatStartsWith("NO", term);
            //var places = LocationApp.AutocompleteGetPlacesTopThatContains("NO", 10, term);
            return Json(places, JsonRequestBehavior.AllowGet);
        }

    }
}
