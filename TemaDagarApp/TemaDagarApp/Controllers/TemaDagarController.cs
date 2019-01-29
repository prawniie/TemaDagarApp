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

        //List<TemaDag> list = new List<TemaDag>() {

        // new TemaDag
        //{
        //    Name = "Kanelbullens dag",
        //    Date = new DateTime(2019, 1, 21)
        //},
        // new TemaDag
        //{
        //    Name = "Kladdkakans dag",
        //    Date = new DateTime(2019, 2, 24)
        //}
        //};



        public List<TemaDag> CreateListOfThemeDays()
        {
            List<TemaDag> listOfDays = new List<TemaDag>();

            string[] lines = System.IO.File.ReadAllLines(@"..\TemaDagarApp\temadagar.txt");

            //C:\Project\AcceleratedLearning\SquareRootApp\TemaDagarApp\TemaDagarApp\temadagar.txt
            //'Could not find file 'C:\Project\AcceleratedLearning\SquareRootApp\TemaDagarApp\temadagar.txt'.'

            foreach (var item in lines)
            {
                string[] eachDay = item.Split(',');
                TemaDag dag = new TemaDag
                {
                    Date = Convert.ToDateTime(eachDay[0]),
                    Name = eachDay[1]
                };
                listOfDays.Add(dag);
            }
            return listOfDays;
        }




        [Route("temadagar/GetThemeDay"), HttpGet]
        public IActionResult GetThemeDay(DateTime date)
        {

            List<TemaDag> list = CreateListOfThemeDays();

            foreach (var day in list)
            {
                if (day.Date == date)
                {
                    return Ok($"Den {date.ToShortDateString()} är det {day.Name}");
                }

            }

            return BadRequest($"Sorry det finns ingen temadag på datumet {date.ToShortDateString()}");


        }
    }
}
