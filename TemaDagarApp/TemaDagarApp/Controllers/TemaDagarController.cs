using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaDagarApp.Models;

namespace TemaDagarApp.Controllers
{
    public class TemaDagarController : Controller
    {

        List<TemaDag> list = new List<TemaDag>() {

         new TemaDag
        {
            Name = "Kanelbullens dag",
            Date = new DateTime(2019, 1, 21)
        },
         new TemaDag
        {
            Name = "Kladdkakans dag",
            Date = new DateTime(2019, 2, 24)
        }
        };


        [Route("temadagar/GetThemeDay"), HttpGet]
        public IActionResult GetThemeDay(TemaDag temaDag)
        {

            foreach (var day in list)
            {
                if (day.Date == temaDag.Date)
                {
                    return Ok($"Den {temaDag.Date.ToShortDateString()} är det {day.Name}");
                }

                else
                {
                    return BadRequest($"Sorry det finns ingen temadag på datumet {temaDag.Date.ToShortDateString()}");
                }

            }

            return Ok($"Den {temaDag.Date} är det {temaDag.Name} dag");

        }
    }
}
