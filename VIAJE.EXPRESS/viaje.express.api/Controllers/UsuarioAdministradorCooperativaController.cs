using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.data.DataUsuario;
using viaje.express.data.DataModulo;
using viaje.express.model.ModelUserAdministradorCooperativa;
using viaje.express.model;
using Microsoft.Extensions.Logging;


namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioAdministradorCooperativaController : ControllerBase
    {
        private readonly ILogger<UsuarioAdministradorCooperativaController> _logger;
        private readonly UsuarioCooperativa_db _usuario_cooperativa_db;
        private readonly UsuarioAdministradorCooperativa_db _usuario_admin_coop_db;
        private readonly Modulo_db _modulo_db;
        private BaseController bc;

        public UsuarioAdministradorCooperativaController(ILogger<UsuarioAdministradorCooperativaController> logger, UsuarioAdministradorCooperativa_db usuario_admin_coop_db)
        {
            _logger = logger;
            _usuario_admin_coop_db = usuario_admin_coop_db;
            _usuario_cooperativa_db = new UsuarioCooperativa_db();
            _modulo_db = new Modulo_db();
            bc = new BaseController();
        }

        [HttpPost]
        public Resultado Post_insertar_administrador_cooperativa(IngresarAdministradorCooperativa model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                string clave = model.cedula;
                Resultado rp = _usuario_admin_coop_db.insertar_usuario_admin_coop(model.cedula, model.nombre, model.apellido, model.fecha_nacimiento,
                        model.genero, model.telefono, model.correo, clave, model.path_foto, model.id_cooperativa, model.Created_by);
                if (rp.Exito)
                {
                    Resultado rm = _modulo_db.insertar_usuario_rol_modulo(
                        model.id_persona_rol_ejecucion, rp.Codigo, 3); // 3 -> modulo de operadores
                    if (rm.Exito)
                    {
                        result.Exito = true;
                        result.Mensaje = rp.Mensaje + "\n" + rm.Mensaje;
                        result.Codigo = rp.Codigo;
                        return result;
                    } 
                    else
                    {
                        _usuario_cooperativa_db.eliminar_usuario_rol_falla_modulo(rp.Codigo);
                        result.Mensaje = rm.Mensaje;
                        result.Codigo = rm.Codigo;
                        return result;
                    }
                } else
                {
                    result.Mensaje = rp.Mensaje;
                    result.Codigo = rp.Codigo;
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

        [HttpPost]
        [Route("Listar")]
        public Resultado Get_listar_administrador_cooperativa(Listar model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerAdminitradorCooperativa> listAdminCoop = _usuario_admin_coop_db.listar_administardor_cooperativa(
                    model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listAdminCoop.Count > 0)
                {
                    r.Codigo = 1;
                    r.Data = listAdminCoop;
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
        [Route("{id_persona_rol}")]
        public Resultado Get_obtener_administrador_cooperativa(int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                ObtenerAdminitradorCooperativa admin_coop = _usuario_admin_coop_db.obtener_administrador_cooperativa(id_persona_rol);
                if (admin_coop != null)
                {
                    r.Codigo = 1;
                    r.Data = admin_coop;
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

        [HttpPut]
        [Route("{id_persona_rol}")]
        public Resultado Put_actualizar_administrador_cooperativa(int id_persona_rol, [FromBody] ActualizarAdministradorCooperativa model, [FromHeader] string token = "")
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
                    return _usuario_admin_coop_db.actualizar_administrador_cooperativa(
                    id_persona_rol, model.id_cooperativa, model.activo, model.modified_by);
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
        public Resultado Get_eliminar_administrador_cooperativa(int id_persona_rol, EliminarUsuarioAdminCoop model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _usuario_admin_coop_db.eliminar_administrador_cooperativa(id_persona_rol, model.deleted_by);
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }
    }

    public class EliminarUsuarioAdminCoop
    {
        public int deleted_by { get; set; }
    }
}
