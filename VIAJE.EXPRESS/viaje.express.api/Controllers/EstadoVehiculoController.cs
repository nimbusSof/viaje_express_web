using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelEstadoVehiculo;
using viaje.express.data.DataEstadoVehiculo;
using viaje.express.model;
using Microsoft.Extensions.Logging;


namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstadoVehiculoController : ControllerBase
    {
        private readonly ILogger<EstadoVehiculoController> _logger;
        private readonly EstadoVehiculo_db _estado_vehiculo_db;
        private BaseController bc;


        public EstadoVehiculoController(ILogger<EstadoVehiculoController> logger, EstadoVehiculo_db estado_vehiculo_db)
        {
            _logger = logger;
            _estado_vehiculo_db = estado_vehiculo_db;
            bc = new BaseController();
        }

        [HttpGet]
        public Resultado Get_obtener_vehiculo([FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerEstadoVehiculo> list_est_veh = _estado_vehiculo_db.getEstadoVehiculo();
                if (list_est_veh.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = list_est_veh;
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
