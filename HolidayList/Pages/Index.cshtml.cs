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
        public JsonResult OnGet()
        {
                // Property Initialization and parsing of JSON data
                String state = null;
                String filterid = null;
                List <QuickType.Holiday> stateHolidays = new List<Holiday>();
                String cityData = GetData("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
                String holidayData = GetData("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019");
                QuickTypePlaces.Places[] allCities = QuickTypePlaces.Places.FromJson(cityData);
                QuickType.Welcome allHolidays = QuickType.Welcome.FromJson(holidayData);                
                                                        
                //Choosing "New york" as an example to display the list of holidays for the state
                foreach (QuickTypePlaces.Places city in allCities)
                {
                    if(city.Country == "United States" && city.Subcountry == "New York")
                    {
                        state = city.Subcountry;
                        break;
                    }

                }

                //Populating the list of holidays for New York
                foreach (QuickType.Holiday Holiday in allHolidays.Response.Holidays)
                {
                   // Adding the state-specific holidays to the list
                   if (Holiday.States.Enum == null)
                   {
                        if (((Holiday.States.StateArray[0].Name) == state) && (filterid == "Null"))
                        {
                            stateHolidays.Add(Holiday);
                            filterid = Holiday.States.StateArray[0].Iso;
                        }

                        else if ((Holiday.States.StateArray[0].Name) == state)
                        {
                            stateHolidays.Add(Holiday);
                        }
    
                   }
                   // Adding national holidays to the list
                  else
                  {
                        stateHolidays.Add(Holiday);
                  }
                   
                }                                                                       
                //returning the filtered list of holidays for New York in JSON format
                String filteredHolidaysList = GetData("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019&location="+ filterid);
                return new JsonResult(QuickType.Welcome.FromJson(filteredHolidaysList));                                 
        }

        //Downloading JSON data from APIs
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
