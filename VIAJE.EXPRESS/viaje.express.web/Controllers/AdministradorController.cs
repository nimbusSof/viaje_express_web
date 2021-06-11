using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.model.ModelCooperativa;

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

        public IActionResult DataCooperativa(int? id_Coop)
        {
            Cooperativa cooperativa = new Cooperativa();
            if (id_Coop != null && id_Coop>0)
            {
                
            }

            return PartialView("_crearCooperativa", cooperativa);
        }
    }
}
