using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viaje.express.web.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cooperativa()
        {
            return View();
        }
        public IActionResult AdminCooperativa()
        {
            return View();
        }
        public IActionResult Mapa()
        {
            return View();
        }
    }
}
