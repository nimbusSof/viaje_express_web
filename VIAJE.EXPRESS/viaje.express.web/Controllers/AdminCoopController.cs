using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viaje.express.web.Controllers
{
    public class AdminCoopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult Operador()
        {
            return View();
        }
    }
}
