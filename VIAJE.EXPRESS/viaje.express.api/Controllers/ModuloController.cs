using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data.DataModulo;
using viaje.express.model.ModelModulos;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly ILogger<ModuloController> _logger;
        private readonly Modulo_db _modulo_db;
        private BaseController bc;

        public ModuloController(ILogger<ModuloController> logger, Modulo_db modulo_db)
        {
            _logger = logger;
            _modulo_db = modulo_db;
            bc = new BaseController();
        }

        [HttpGet]
        [Route("{id_persona_rol}")]
        public Resultado ObtenerPermisos(int id_persona_rol, [FromHeader] string token="")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ModuloRol> modulo_rol = _modulo_db.getRutasRol(id_persona_rol);
                if (modulo_rol.Count > 0)
                {
                    r.Codigo = 1;
                    r.Data = modulo_rol;
                    r.Mensaje = "Correcto";
                    r.Exito = true;
                    return r;
                }
                else
                {
                    r.Mensaje = "No se encontro ningun registro";
                    return r;
                }
            } else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        [HttpGet]
        [Route("ListarModulo/{id_rol}")]
        public Resultado ListarModuloRol(int id_rol, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                List<AsignarModulo> modulo_rol = _modulo_db.listar_modulo_rol(id_rol);
                if (modulo_rol.Count > 0)
                {
                    r.Codigo = 1;
                    r.Data = modulo_rol;
                    r.Mensaje = "Exitoso";
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
