using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.data.DataUsuario;
using viaje.express.model.ModelUsuario;
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
        private BaseController bc;

        public UsuarioAdministradorCooperativaController(ILogger<UsuarioAdministradorCooperativaController> logger, UsuarioCooperativa_db usuario_cooperativa_db)
        {
            _logger = logger;
            _usuario_cooperativa_db = usuario_cooperativa_db;
            bc = new BaseController();
        }

        [HttpPost]
        public Resultado Post_insertar_administrador_cooperativa(UsuarioCooperativa model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                string clave = model.cedula;
                Resultado rp = _usuario_cooperativa_db.insertar_usuario_admin_coop(model.cedula, model.nombre, model.apellido, model.fecha_nacimiento,
                        model.genero, model.telefono, model.correo, clave, model.path_foto, model.id_cooperativa, model.Created_by);
                if (rp.Exito)
                {
                    Resultado rm = _usuario_cooperativa_db.insertar_usuario_rol__modulo(
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
                List<UsuarioAdministradorCooperativa> listAdminCoop = _usuario_cooperativa_db.listar_administardor_cooperativa(
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
        [Route("{id}")]
        public Resultado Get_obtener_administrador_cooperativa(int id, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                UsuarioAdministradorCooperativa admin_coop = _usuario_cooperativa_db.obtener_administrador_cooperativa(id);
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
    }
}
