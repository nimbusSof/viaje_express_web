using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viaje.express.web.Views
{
    public class LoginController : Controller
    {
        public IActionResult Index(string nombre)
        {
            ViewBag.Nombre = nombre;
            return View();
        }

         
    }
}
