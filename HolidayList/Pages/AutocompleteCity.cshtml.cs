using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolidayList.Pages
{
    public class AutocompleteCityModel : PageModel
    {
        [BindProperty]
        private string Term { get; set; }
        private IList<string> cityNames = new List<string>();
        public JsonResult OnGet()
        {
            Term = HttpContext.Request.Query["term"];
            AddCity("Cincinnati");
            AddCity("New York");
            AddCity("Chicago");
            AddCity("Baltimore");
            return new JsonResult(cityNames);
        }

        private void AddCity(string cityName)
        {
            if (cityName.Contains(Term))
            {
                cityNames.Add(cityName);
            }

        }
    }
}