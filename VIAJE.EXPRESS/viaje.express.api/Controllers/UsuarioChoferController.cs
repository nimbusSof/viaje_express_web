using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelChofer;
using viaje.express.data.DataUsuario;
using viaje.express.data.DataChofer;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioChoferController : ControllerBase
    {
        private readonly ILogger<UsuarioChoferController> _logger;
        private readonly Chofer_db _chofer_db;
        private readonly UsuarioCooperativa_db _usuario_cooperativa_db;
        private BaseController bc;

        public UsuarioChoferController(ILogger<UsuarioChoferController> logger, Chofer_db chofer_db)
        {
            _logger = logger;
            _chofer_db = chofer_db;
            _usuario_cooperativa_db = new UsuarioCooperativa_db();
            bc = new BaseController();
        }

        [HttpPost]
        public Resultado Post_insertar_usuario_chofer(InsertarChofer model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                Resultado r1 = _chofer_db.insertar_usuario_chofer(model.cedula, model.nombre, model.apellido, model.fecha_nacimiento,
                    model.genero, model.telefono, model.correo, model.cedula, model.path_foto, model.created_by);
                if (r1.Exito)
                {
                    Resultado r2 = _chofer_db.insertar_chofer(model.id_cooperativa, r1.Codigo, model.id_vehiculo,
                        model.puntos_licencia, model.created_by);
                    if (r2.Exito)
                    {
                        return r2;
                    }
                    else
                    {
                        _usuario_cooperativa_db.eliminar_usuario_rol_falla_modulo(r1.Codigo);
                        result.Mensaje = r2.Mensaje;
                        return result;
                    }
                }
                else
                {
                    result.Mensaje = r1.Mensaje;
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

        [HttpPut]
        [Route("{id_persona_rol}")]
        public Resultado Put_actualizar_usuario_chofer(int id_persona_rol, ActualizarChofer model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                Resultado r = _usuario_cooperativa_db.actualizar_usuario_cooperativa(id_persona_rol, model.cedula, model.nombre, model.apellido,
                    model.fecha_nacimiento, model.genero, model.telefono, model.correo, model.path_foto, model.modified_by);

                if (r.Exito)
                {
                    return _chofer_db.actualizar_chofer(id_persona_rol, model.id_vehiculo, model.puntos_licencia, model.activo, model.modified_by);
                }
                else
                {
                    result.Mensaje = r.Mensaje;
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

        [HttpPut]
        [Route("reset_clave/{id_persona_rol}")]
        public Resultado Put_resetear_clave(int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _usuario_cooperativa_db.resetear_clave(id_persona_rol);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpDelete]
        [Route("{id_persona_rol}")]
        public Resultado eliminar_chofer(int id_persona_rol, eliminarChofer model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _chofer_db.eliminar_chofer(id_persona_rol, model.deleted_by);
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
        public Resultado Get_listar_choferes(int id_cooperativa, Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerUsuarioChofer> listChoferes= _chofer_db.listar_choferes(id_cooperativa, model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listChoferes.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = listChoferes;
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
        [Route("{id_persona_rol}")]
        public Resultado Get_obtener_chofer(int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                ObtenerUsuarioChofer chofer = _chofer_db.obtener_chofer(id_persona_rol);
                if (chofer != null)
                {
                    result.Codigo = 1;
                    result.Data = chofer;
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

    public class eliminarChofer
    {
        public int deleted_by { get; set; }
    }
}
