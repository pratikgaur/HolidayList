using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolidayList.Pages
{
    public class concertFitDisplayModel : PageModel
    {
        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                String artistData = webClient.DownloadString("https://concertfit20191109074437.azurewebsites.net/api");
                // String holidaysData = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=3b2cc4a9fcb58a121947815135fca92694b0f63e&country=US&year=2019");
                ConcertFitResponse.ConcertFit[] artist = ConcertFitResponse.ConcertFit.FromJson(artistData);
                ViewData["Artist"] = artist;
            }
        }
    }
}