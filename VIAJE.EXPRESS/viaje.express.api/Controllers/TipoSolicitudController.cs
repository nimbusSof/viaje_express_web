using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelTipoSolicitud;
using viaje.express.data.DataTipoSolicitud;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoSolicitudController : ControllerBase
    {
        private readonly ILogger<TipoSolicitudController> _logger;
        private readonly TipoSolicitud_db _tipo_solic_db;
        private BaseController bc;

        public TipoSolicitudController(ILogger<TipoSolicitudController> logger, TipoSolicitud_db tipo_solic_db)
        {
            _logger = logger;
            _tipo_solic_db = tipo_solic_db;
            bc = new BaseController();
        }

        [HttpGet]
        public Resultado Get_listar_tipo_solicitud([FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerTipoSolicitud> lista = _tipo_solic_db.getTipoSolicitud();
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
