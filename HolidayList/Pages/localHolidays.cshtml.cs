using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using holidaysNamespace;
using worldCitiesNamespace;
using System.Net;

namespace HolidayList.Pages
{
    public class localHolidaysModel : PageModel
    {
        public int Length { get; }

        public bool processComplete { get; set; }
        public void OnPost()
        {
            var cityName = Request.Form["cityName"];
            using (WebClient webClient = new WebClient())
            {
                String Places = webClient.DownloadString("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
                String holidaysData = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019");
                WorldCities[] Place = worldCitiesNamespace.WorldCities.FromJson(Places);

                holidaysNamespace.HolidayList welcome = holidaysNamespace.HolidayList.FromJson(holidaysData);
                //List<holidaysNamespace.HolidayList> holidays = new List<holidaysNamespace.HolidayList>();
                string state = null;
                foreach (worldCitiesNamespace.WorldCities Area in Place)
                {
                    if (Area.Country == "United States" && Area.Name == cityName)
                    {
                        state = Area.Subcountry;
                        break;
                    }
                }

                //   foreach (QuickType.Holiday Holidays in welcome.Response.Holidays)
                //    {
                //        if (Holidays.States.Enum == null)
                //        {
                //            if ((Holidays.States.StateArray[0].Name) == state)
                //            {
                //                holidays.Add(Holidays);
                //            }

                //        }
                //        else
                //        {
                //            holidays.Add(Holidays);
                //        }

                //    }

                //    ViewData["Holidays"] = holidays;
                //    ViewData["state"] = state;
                //    ViewData["Places"] = Place;

                String filterid = null;
                foreach (holidaysNamespace.Holiday Holidays in welcome.Response.Holidays)
                {
                    if (Holidays.States.Enum == null)
                    {
                        for (int i = 0; i < Holidays.States.StateArray.Length; i++)
                        {
                            if ((Holidays.States.StateArray[i].Name) == state)
                            {
                                if (Holidays.States.StateArray[i].Exception == null)
                                {
                                    filterid = Holidays.States.StateArray[i].Iso;
                                    break;
                                }

                            }
                        }

                    }
                }

                String filteredHolidaysList = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019&type=local&location=" + filterid);
                holidaysNamespace.HolidayList StateHoliday = holidaysNamespace.HolidayList.FromJson(filteredHolidaysList);

                ViewData["Holidays"] = StateHoliday;
                ViewData["state"] = state;

                processComplete = true;

            }
        }
    }
}