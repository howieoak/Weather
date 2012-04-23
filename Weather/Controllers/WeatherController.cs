using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Application.Weather;
using Weather.ModelBinders;
using Weather.Model.Domain;
using Weather.Application.Location;
using Weather.Models;
using Weather.Model.Common;
using System.Collections;
using Weather.Application.Common;
//using System.Globalization;

namespace Weather.Controllers
{
    public class WeatherController : Controller
    {
        //
        // GET: /Weather/

        public ActionResult Index()
        {
            ViewBag.Greeting = "Hello from Weather channel!";
            
            return View();
        }

        [HttpGet]
        public ViewResult Sunrise()
        {
            SunriseFormBinder sfb = new SunriseFormBinder
            {
                Longitude = "10,746092",
                Latitude = "59,912726",
                Date = "2012-03-30"
            };

            SunriseViewModel viewModel = new SunriseViewModel
            {
                SunriseFormBinder = sfb
            };
     
            return View(viewModel);
        }

        [HttpPost]
        public ViewResult Sunrise(SunriseViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string sunrise = WeatherApp.GetSunriseTime(double.Parse(vm.SunriseFormBinder.Latitude), double.Parse(vm.SunriseFormBinder.Longitude), vm.SunriseFormBinder.Date);

                vm.SunriseTime = sunrise;
            }

            return View(vm);
        }

        [HttpGet]
        public ViewResult LocationForecast()
        {
            // Sjekk denne: http://www.html5rocks.com/en/tutorials/geolocation/trip_meter/
            
            //ForecastFormBinder sfb = new ForecastFormBinder
            //{
            //    Longitude = "10,746092",
            //    Latitude = "59,912726",
            //};

            //ForecastViewModel viewModel = new SunriseViewModel
            //{
            //    SunriseFormBinder = sfb
            //};

            return View();
        }

        [HttpPost]
        public ActionResult LocationForecast(String latitude, String longitude)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(latitude) && !string.IsNullOrEmpty(longitude))
            {
                Place place = LocationApp.GetClosestPlace("NO", latitude.ToDoubleComma(), longitude.ToDoubleComma());

                Forecast forecast = WeatherApp.GetWeatherForecast(place);
                forecast.SetImageUrl(true);

                return PartialView("_ForecastUpcomming", forecast);
            }

            return View();
        }


        public ViewResult Forecast(int? id)
        {
            if (!id.HasValue)
            {
                // do some error checking
                throw new NotImplementedException();
            }

            Place place = LocationApp.GetPlace("NO", id.Value);
            Forecast forecast = WeatherApp.GetWeatherForecast(place);
            forecast.SetImageUrl(true); 

            return View(forecast);
        }

        public PartialViewResult ForecastUpcomming(string place)
        {
            string[] mySplit = place.Split(':');
            int placeId = Int32.Parse(mySplit[1]);

            Place myPlace = LocationApp.GetPlace("NO", placeId);
            Forecast forecast = WeatherApp.GetWeatherForecast(myPlace);
            forecast.SetImageUrl(true);

            return PartialView("_ForecastUpcomming", forecast);
        }

        public ViewResult ForecastLongTerm(int? placeId)
        {
            IList<Forecast> forecasts = null;

            if (placeId.HasValue)
            {
                Place place = LocationApp.GetPlace("NO", placeId.Value);
                
                forecasts = WeatherApp.GetWeatherForecastLongTerm(place);
                forecasts.SetImageUrl(true);
            }

            return View(forecasts);
        }

    }
}
