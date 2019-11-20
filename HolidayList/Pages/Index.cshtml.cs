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
        public JsonResult OnGet()
        {
            {
                String HolidayKey = System.IO.File.ReadAllText("HolidayAPIKey.txt");
                String Places = GetData("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
                String jsonString = GetData("https://calendarific.com/api/v2/holidays?&api_key=" + HolidayKey + "&country=US&year=2019");
                Places[] Place = QuickTypePlaces.Places.FromJson(Places);
                
                QuickType.HolidayData holidayData = QuickType.HolidayData.FromJson(jsonString);
                List <QuickType.Holiday> holidays = new List<Holiday>();
                string state = null;
                foreach (QuickTypePlaces.Places Area in Place)
                {
                    if(Area.Country == "United States" && Area.Subcountry == "New York")
                    {

                        state = Area.Subcountry;
                        break;
                    }
                }


                foreach (QuickType.Holiday Holidays in holidayData.Response.Holidays)
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
                foreach (QuickType.Holiday Holidays in holidayData.Response.Holidays)
                {
                    if (Holidays.States.Enum == null)
                    {
                        if ((Holidays.States.StateArray[0].Name) == state)
                        {
                            filterid = Holidays.States.StateArray[0].Iso;
                        }
                    }
                }

                String filteredHolidaysList = GetData("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019&location="+ filterid);
                QuickType.HolidayData StateHoliday = QuickType.HolidayData.FromJson(filteredHolidaysList);

                return new JsonResult(StateHoliday);

            }             
        }
        public string GetData(string endpoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);
            }
            return downloadedData;
        }
    }
}
