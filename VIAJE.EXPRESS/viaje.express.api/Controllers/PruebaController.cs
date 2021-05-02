using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data;
using viaje.express.model;

/*
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data;
using viaje.express.model;
*/

namespace viaje.express.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PruebaController : Controller
    {
        private readonly ILogger<PruebaController> _logger;
        private readonly Prueba_bd _prueba_bd;

        public PruebaController(ILogger<PruebaController> logger, Prueba_bd prueba_bd)
        {
            _logger = logger;
            _prueba_bd = prueba_bd;
        }

        [HttpGet]
        public List<Prueba_v1> Get()
        {
            return _prueba_bd.Listar();
        }

        [HttpPost]
        public Prueba_v1 Post(Prueba_v1 model)
        {
            return _prueba_bd.Insertar_Prueba(model.fecha, model.hora, model.distancia, model.lat, model.lng, model.monto);
        }

    }
}
