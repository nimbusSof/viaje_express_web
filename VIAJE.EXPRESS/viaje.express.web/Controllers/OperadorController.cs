using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viaje.express.web.Controllers
{
    public class OperadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Rutas()
        {
            return View();
        }
        public IActionResult Choferes()
        {
            return View();
        }
        public IActionResult Vehiculos()
        {
            return View();
        } 
        public IActionResult MapaVehiculos()
        {
            return View();
        }  
        public IActionResult MapaRutas()
        {
            return View();
        } 
        public IActionResult Solicitudes()
        {
            return View();
        }
    }
}
