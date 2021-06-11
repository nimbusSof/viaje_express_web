using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using viaje.express.data.DataCooperativa;
using viaje.express.model.ModelCooperativa;
using viaje.express.model;

namespace viaje.express.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CooperativaController : ControllerBase
    {

        private readonly ILogger<CooperativaController> _logger;
        private readonly Cooperativa_db _cooperativa_db;
        private BaseController bc;

        public CooperativaController(ILogger<CooperativaController> logger, Cooperativa_db cooperativa_db)
        {
            _logger = logger;
            _cooperativa_db = cooperativa_db;
            bc = new BaseController();
        }

        [HttpPost]
        [Route("Listar")]
        public Resultado Get_listar_cooperativas(Listar model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerCooperativa> listCoop = _cooperativa_db.listar_cooperativas(model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listCoop.Count > 0)
                {
                    r.Codigo = 1;
                    r.Data = listCoop;
                    r.Mensaje = "Correcto";
                    r.Exito = true;
                    return r;
                }
                else
                {
                    r.Mensaje = "No se encontro ningun registro";
                    return r;
                }
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        [HttpGet]
        [Route("{id_cooperativa}")]
        public Resultado Get_obtener_cooperativa(int id_cooperativa, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                ObtenerCooperativa coop = _cooperativa_db.obtener_cooperativa(id_cooperativa);
                if (coop != null)
                {
                    r.Codigo = 1;
                    r.Data = coop;
                    r.Mensaje = "Correcto";
                    r.Exito = true;
                    return r;
                }
                else
                {
                    r.Mensaje = "No se encontro ningun registro";
                    return r;
                }
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        [HttpPost]
        public Resultado Post_insertar_cooperativa(InsertarCooperativa model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _cooperativa_db.insertar_cooperativa(model.id_persona_rol_admin, model.nombre, model.direccion, model.telefono,
                        model.lat, model.lng, model.activo, model.Created_by);
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        [HttpPut]
        [Route("{id_cooperativa}")]
        public Resultado Post_actualizar_cooperativa(int id_cooperativa, ActualizarCooperativa model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _cooperativa_db.actualizar_cooperativa(id_cooperativa, model.nombre, model.direccion, model.telefono,
                model.lat, model.lng, model.activo, model.modified_by);
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        [HttpDelete]
        [Route("{id_cooperativa}")]
        public Resultado Delete(int id_cooperativa, eliminar_cooperativa model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _cooperativa_db.eliminar_cooperativa(id_cooperativa, model.deleted_by);
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

    }

    public class eliminar_cooperativa
    {
        public int deleted_by { get; set; }
    }
}
