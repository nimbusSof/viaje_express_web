using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viaje.express.web.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        } public IActionResult LoginCliente()
        {
            return View();
        }
    }
}
