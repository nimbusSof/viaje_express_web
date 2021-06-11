using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelTipoCarrera;
using viaje.express.data.DataTipoCarrera;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoCarreraController : ControllerBase
    {
        private readonly ILogger<TipoCarreraController> _logger;
        private readonly TipoCarrera_db _tipo_carrera_db;
        private BaseController bc;

        public TipoCarreraController(ILogger<TipoCarreraController> logger, TipoCarrera_db tipo_carrera_db)
        {
            _logger = logger;
            _tipo_carrera_db = tipo_carrera_db;
            bc = new BaseController();
        }

        [HttpGet]
        public Resultado Get_listar_tipo_carrera([FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerTipoCarrera> lista = _tipo_carrera_db.getTipoCarrera();
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
