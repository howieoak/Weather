using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Weather.ModelBinders
{
    public class SunriseFormBinder
    {
        [Required(ErrorMessage = "Please enter latitude")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Please enter longitude")]
        public string Longitude { get; set; }
        [Required(ErrorMessage = "Please enter date")]
        //[RegularExpression("dddd-dd-dd", ErrorMessage = "Please enter valid date")]
        public string Date { get; set; }
    }
}