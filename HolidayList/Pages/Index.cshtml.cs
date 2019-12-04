using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;
using QuickTypePlaces;

namespace HolidayList.Pages
{
    public class IndexModel : PageModel
    {
        //WebClient webClient = null;
        public string DownloadData(string jsonendpoint)
        {
            string rawData = "";
            using (WebClient webClient = new WebClient())
            {
                rawData = webClient.DownloadString(jsonendpoint);
            }
            return rawData;
        }

        public void OnGet()
        {
                String CalenderAPIkey = System.IO.File.ReadAllText("APIkey.txt");
                String CalenderData = DownloadData("https://calendarific.com/api/v2/holidays?&country=US&year=2019&api_key=" + CalenderAPIkey);
                String Places = DownloadData("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
                Places[] Place = QuickTypePlaces.Places.FromJson(Places);

                QuickType.Welcome welcome = QuickType.Welcome.FromJson(CalenderData);
                List<QuickType.Holiday> holidays = new List<Holiday>();
                string State = null;
                foreach (QuickTypePlaces.Places Area in Place)
                {
                    if (Area.Country == "United States" && Area.Subcountry == "New York")
                    {

                        State = Area.Subcountry;
                        break;
                    }
                }


                foreach (QuickType.Holiday Holidays in welcome.Response.Holidays)
                {
                    if (Holidays.States.Enum == null)
                    {
                        if ((Holidays.States.StateArray[0].Name) == State)
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
                ViewData["state"] = State;
                ViewData["Places"] = Place;

                String filterid = null;
                foreach (QuickType.Holiday Holidays in welcome.Response.Holidays)
                {
                    if (Holidays.States.Enum == null)
                    {
                        if ((Holidays.States.StateArray[0].Name) == State)
                        {
                            filterid = Holidays.States.StateArray[0].Iso;
                        }
                    }
                }

                String filteredHolidaysList = DownloadData("https://calendarific.com/api/v2/holidays?&country=US&year=2019&api_key=" + CalenderAPIkey + "&location=" + filterid);

                QuickType.Welcome StateHoliday = QuickType.Welcome.FromJson(filteredHolidaysList);

                // return new JsonResult(StateHoliday);

            
        }
    }
}
