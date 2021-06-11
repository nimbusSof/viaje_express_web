using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelRuta;
using viaje.express.data.DataRuta;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly ILogger<RutaController> _logger;
        private readonly Ruta_db _ruta_db;
        private BaseController bc;

        public RutaController(ILogger<RutaController> logger, Ruta_db ruta_db)
        {
            _logger = logger;
            _ruta_db = ruta_db;
            bc = new BaseController();
        }

        [HttpPost]
        public Resultado Post_insertar_ruta(InsertarRuta model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _ruta_db.insertar_ruta(model.id_cooperativa, model.nombre_ruta, model.origen_lat, model.origen_lng, model.destino_lat, model.destino_lng,
                    model.distancia, model.tiempo, model.monto, model.created_by);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPut]
        [Route("{id_ruta}")]
        public Resultado Put_actualizar_ruta(int id_ruta, ActualizarRuta model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _ruta_db.actualizar_ruta(id_ruta, model.nombre_ruta, model.origen_lat, model.origen_lng, model.destino_lat, model.destino_lng,
                    model.distancia, model.tiempo, model.monto, model.activo, model.modified_by);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpDelete]
        [Route("{id_ruta}")]
        public Resultado eliminar_ruta(int id_ruta, eliminarRuta model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _ruta_db.eliminar_ruta(id_ruta, model.deleted_by);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPost]
        [Route("Listar/{id_cooperativa}")]
        public Resultado Post_listar_rutas(int id_cooperativa, Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerRuta> listRutas = _ruta_db.listar_rutas(id_cooperativa, model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listRutas.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = listRutas;
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

        [HttpGet]
        [Route("{id_ruta}")]
        public Resultado Get_obtener_ruta(int id_ruta, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                ObtenerRuta ruta = _ruta_db.obtener_ruta(id_ruta);
                if (ruta != null)
                {
                    result.Codigo = 1;
                    result.Data = ruta;
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

    public class eliminarRuta
    {
        public int deleted_by { get; set; }
    }
}
