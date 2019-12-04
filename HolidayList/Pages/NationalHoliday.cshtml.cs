using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using worldCitiesNamespace;

namespace HolidayList.Pages
{
    public class NationalHolidaysModel : PageModel
    {
        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                // String Places = webClient.DownloadString("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
                // String holidaysData = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019");
                // WorldCities[] Place = worldCitiesNamespace.WorldCities.FromJson(Places);

                // holidaysNamespace.HolidayList welcome = holidaysNamespace.HolidayList.FromJson(holidaysData);
                //List<holidaysNamespace.HolidayList> holidays = new List<holidaysNamespace.HolidayList>();

                String filteredHolidaysList = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019&type=national");
                holidaysNamespace.HolidayList Holiday = holidaysNamespace.HolidayList.FromJson(filteredHolidaysList);
                ViewData["Holidays"] = Holiday;
            }
        }
    }
}