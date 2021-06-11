using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelCarreraEjecucion;
using viaje.express.data.DataCarreraEjecucion;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarreraEjecucionController : ControllerBase
    {
        private readonly ILogger<CarreraEjecucionController> _logger;
        private readonly CarreraEjecucion_db _carrera_ejecucion_db;
        private BaseController bc;

        public CarreraEjecucionController(ILogger<CarreraEjecucionController> logger, CarreraEjecucion_db carrera_ejecucion_db)
        {
            _logger = logger;
            _carrera_ejecucion_db = carrera_ejecucion_db;
            bc = new BaseController();
        }

        [HttpGet]
        public Resultado Get_listar_carrera_ejecicion([FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerCarreraEjecucion> lista = _carrera_ejecucion_db.getCarreraEjecucion();
                if (lista.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = lista;
                    result.Mensaje = "Correcto";
                    result.Exito = true;
                    return result;
                }
                else
                {
                    result.Mensaje = "No se encontro ningun registro";
                    return result;
                }
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }
    }
}
