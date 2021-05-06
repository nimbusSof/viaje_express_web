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
                List<Cooperativa> listCoop = _cooperativa_db.listar_cooperativas(model.columna, model.nombre, model.offset, model.limit, model.sort);
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
        [Route("{id}")]
        public Resultado Get_obtener_cooperativa(int id, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                Cooperativa coop = _cooperativa_db.obtener_cooperativa(id);
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
        public Resultado Post_insertar_cooperativa(Cooperativa model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _cooperativa_db.insertar_cooperativa(model.id_persona_rol_admin_coop, model.nombre, model.direccion, model.telefono,
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
        [Route("{id}")]
        public Resultado Post_actualizar_cooperativa(int id, Cooperativa model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _cooperativa_db.actualizar_cooperativa(id, model.nombre, model.direccion, model.telefono,
                model.lat, model.lng, model.activo, model.Modified_by);
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id, Cooperativa model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _cooperativa_db.eliminar_cooperativa(id, model.Deleted_by);
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

    }
}
