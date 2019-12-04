using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using holidaysNamespace;
using worldCitiesNamespace;

namespace HolidayList.Pages
{
    public class holidayListJsonModel : PageModel
    {
        public JsonResult OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                String Places = webClient.DownloadString("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
                String jsonString = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019");
                WorldCities[] Place = worldCitiesNamespace.WorldCities.FromJson(Places);

                holidaysNamespace.HolidayList HolidayList = holidaysNamespace.HolidayList.FromJson(jsonString);
                List<holidaysNamespace.Holiday> holidays = new List<Holiday>();
                string state = null;
                foreach (worldCitiesNamespace.WorldCities Area in Place)
                {
                    if (Area.Country == "United States" && Area.Subcountry == "New York")
                    {

                        state = Area.Subcountry;
                        break;
                    }
                }


                foreach (holidaysNamespace.Holiday Holidays in HolidayList.Response.Holidays)
                {
                    if (Holidays.States.Enum == null)
                    {
                        if ((Holidays.States.StateArray[0].Name) == state)
                        {
                            holidays.Add(Holidays);
                        }

                    }
                    else
                    {
                        holidays.Add(Holidays);
                    }

                }

                ViewData["Holidays"] = holidays;
                ViewData["state"] = state;
                ViewData["Places"] = Place;

                String filterid = null;
                foreach (holidaysNamespace.Holiday Holidays in HolidayList.Response.Holidays)
                {
                    if (Holidays.States.Enum == null)
                    {
                        if ((Holidays.States.StateArray[0].Name) == state)
                        {
                            filterid = Holidays.States.StateArray[0].Iso;
                        }
                    }
                }

                String filteredHolidaysList = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019&type=local&location=" + filterid);
                holidaysNamespace.HolidayList StateHoliday = holidaysNamespace.HolidayList.FromJson(filteredHolidaysList);

                return new JsonResult(StateHoliday);
            }
        }
    }
}