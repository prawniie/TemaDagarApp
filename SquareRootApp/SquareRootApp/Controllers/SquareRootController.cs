using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRootApp.Controllers
{
    public class SquareRootController : Controller
    {
        [Route("SquareRoot")]
        public IActionResult SquareRoot(int? number)
        {
            return Ok(Math.Sqrt((int)number));
        }
    }
}
