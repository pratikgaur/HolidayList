//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using QuickType;
//using QuickTypePlaces;

//namespace HolidayList.Pages
//{
//    public class IndexModel : PageModel
//    {
//        //WebClient webClient = null;
//        public JsonResult OnGet()
//        {
//            using (WebClient webClient = new WebClient())
//            {
//                String Places = webClient.DownloadString("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
//                String jsonString = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019");
//                Places[] Place = QuickTypePlaces.Places.FromJson(Places);

//                QuickType.Welcome welcome = QuickType.Welcome.FromJson(jsonString);
//                List <QuickType.Holiday> holidays = new List<Holiday>();
//                string state = null;
//                foreach (QuickTypePlaces.Places Area in Place)
//                {
//                    if(Area.Country == "United States" && Area.Subcountry == "New York")
//                    {

//                        state = Area.Subcountry;
//                        break;
//                    }
//                }


//                foreach (QuickType.Holiday Holidays in welcome.Response.Holidays)
//                {
//                   if (Holidays.States.Enum == null)
//                    {
//                        if ((Holidays.States.StateArray[0].Name) == state)
//                        {
//                            holidays.Add(Holidays);
//                        }

//                    }
//                    else
//                    {
//                        holidays.Add(Holidays);
//                    }

//                }

//                ViewData["Holidays"] = holidays;
//                ViewData["state"] = state;
//                ViewData["Places"] = Place;

//                String filterid = null;
//                foreach (QuickType.Holiday Holidays in welcome.Response.Holidays)
//                {
//                    if (Holidays.States.Enum == null)
//                    {
//                        if ((Holidays.States.StateArray[0].Name) == state)
//                        {
//                            filterid = Holidays.States.StateArray[0].Iso;
//                        }
//                    }
//                }

//                String filteredHolidaysList = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019&location="+ filterid);
//                QuickType.Welcome StateHoliday = QuickType.Welcome.FromJson(filteredHolidaysList);

//                return new JsonResult(StateHoliday);

//            }             
//        }
//    }
//}



// FORMATTING THE JSON DATA FILE FOR THE HOLIDAYS LIST AND SPECIFYING THE REVISED LINK
// FOR THE JSON DATA FILE HOSTED ON GITHUB on line # 111

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickType;

namespace HolidayList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString("https://raw.githubusercontent.com/singhuh/CR/master/holiday.json");
                var holiday = Holiday.FromJson(jsonString);
                ViewData["Holiday"] = holiday;
            }
        }
    }
}
