﻿using System;
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
                String HolidayKey = System.IO.File.ReadAllText("HolidayAPIKey.txt");
                String holidaysData = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key="+HolidayKey+"&country=US&year=2019");
                WorldCities[] Place = worldCitiesNamespace.WorldCities.FromJson(Places);

                holidaysNamespace.HolidayList welcome = holidaysNamespace.HolidayList.FromJson(holidaysData);
                string state = null;
                foreach (worldCitiesNamespace.WorldCities Area in Place)
                {
                    if (Area.Country == "United States" && Area.Name == cityName)
                    {
                        state = Area.Subcountry;
                        break;
                    }
                }

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

                String filteredHolidaysList = webClient.DownloadString("https://calendarific.com/api/v2/holidays?&api_key=" + HolidayKey + "&country=US&year=2019&type=local&location=" + filterid);
                holidaysNamespace.HolidayList StateHoliday = holidaysNamespace.HolidayList.FromJson(filteredHolidaysList);

                ViewData["Holidays"] = StateHoliday;
                ViewData["state"] = state;

                processComplete = true;

            }
        }
    }
}