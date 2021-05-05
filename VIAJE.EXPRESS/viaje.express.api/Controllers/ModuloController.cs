using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data.DataModulo;
using viaje.express.model.ModelModulos;
using viaje.express.model;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly Modulo_db _modulo_db;

        public ModuloController(Modulo_db modulo_db)
        {
            _modulo_db = modulo_db;
        }

        [HttpGet]
        [Route("{id}")]
        public Resultado ObtenerPermisos(int id)
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            List<ModuloRol> modulo_rol =  _modulo_db.getRutasRol(id);
            if (modulo_rol.Count > 0)
            {
                r.Exito = true;
                r.Codigo = 1;
                r.data = modulo_rol;
                r.Mensaje = "Correcto";
                return r;
            } else
            {
                r.Mensaje = "No se encontro ningun registro";
                return r;
            }
        }
    }
}
