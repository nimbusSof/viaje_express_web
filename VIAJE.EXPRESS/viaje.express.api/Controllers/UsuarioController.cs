using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using viaje.express.data.DataUsuario;
using viaje.express.model.ModelUsuario;
using viaje.express.model;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly Usuario_db _usuario_db;
        private BaseController bc;

        public UsuarioController(ILogger<UsuarioController> logger, Usuario_db usuario_db)
        {
            _logger = logger;
            _usuario_db = usuario_db;
            bc = new BaseController();
        }

        /*[HttpGet]
        [Route("{id_persona_rol}")]
        public Resultado Get_obtener_usuario(int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();

            result.Codigo = 0;
            result.Exito = false;

            if (bc.verificar(token))
            {
                Usuario u = _usuario_db.obtener_usuario(id_persona_rol);             
                if (u != null)
                {  
                    result.Data = u;
                    result.Mensaje = "Correcto";
                    result.Exito = true;
                    return result;
                }
                else
                {
                    result.Mensaje = "No se encontro datos";
                    return result;
                }
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = -1;
                return result;
            }

        }*/
    }
}
