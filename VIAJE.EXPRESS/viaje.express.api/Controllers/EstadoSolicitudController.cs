using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelEstadoSolicitud;
using viaje.express.data.DataEstadoSolicitud;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstadoSolicitudController : ControllerBase
    {
        private readonly ILogger<EstadoSolicitudController> _logger;
        private readonly EstadoSolicitud_db _esta_solic_db;
        private BaseController bc;

        public EstadoSolicitudController(ILogger<EstadoSolicitudController> logger, EstadoSolicitud_db esta_solic_db)
        {
            _logger = logger;
            _esta_solic_db = esta_solic_db;
            bc = new BaseController();
        }

        [HttpGet]
        public Resultado Get_listar_estado_solicitud([FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerEstadoSolicitud> lista = _esta_solic_db.getEstadoSolicitud();
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
