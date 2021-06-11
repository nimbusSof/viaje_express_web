using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.data.DataCuentas;
using viaje.express.model.ModelCuentas;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerfilUsuarioController : ControllerBase
    {
        private readonly ILogger<PerfilUsuarioController> _logger;
        private readonly CuentaUsuario_db _cuenta_user_db;
        private BaseController bc;

        public PerfilUsuarioController(ILogger<PerfilUsuarioController> logger, CuentaUsuario_db cuenta_user_db)
        {
            _logger = logger;
            _cuenta_user_db = cuenta_user_db;
            bc = new BaseController();
        }

        [HttpGet]
        [Route("{id_persona_rol}")]
        public Resultado Get_obtener_perfil(int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                ObtenerPerfilUsuario perfil = _cuenta_user_db.obtener_perfil_usuario(id_persona_rol, token);
                if (perfil != null)
                {
                    result.Codigo = 1;
                    result.Data = perfil;
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

        [HttpPut]
        [Route("{id_persona_rol}")]
        public Resultado Put_actualizar_perfil(int id_persona_rol, ActualizarPerfilUsuario model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _cuenta_user_db.actualizar_perfil_usuario(id_persona_rol, model.nombre, model.apellido, 
                    model.fecha_nacimiento, model.genero, model.telefono, model.correo, model.clave, model.path_foto, token,
                    model.modified_by);
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
