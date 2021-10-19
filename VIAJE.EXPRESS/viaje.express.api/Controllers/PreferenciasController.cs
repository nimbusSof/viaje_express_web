using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using viaje.express.model.PreferenciasUsuario;
using viaje.express.data.DataPreferencias;
using viaje.express.model;
using viaje.express.model.ModelDestinoFavorito;
using viaje.express.data.DataDestinoFavorito;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PreferenciasController : ControllerBase
    {
        private readonly ILogger<PreferenciasController> _logger;
        private readonly PreferenciasUsuario_db _prefs_user_db;
        private readonly DestinosFavoritos_db _destinos_user_db;

        private BaseController bc;

        public PreferenciasController(ILogger<PreferenciasController> logger, PreferenciasUsuario_db prefs_user_db, DestinosFavoritos_db destinos_user_db)
        {
            _logger = logger;
            _prefs_user_db = prefs_user_db;
            _destinos_user_db = destinos_user_db;
            bc = new BaseController();
        }

        [HttpPost]
        [Route("insertar")]
        public Resultado Post_insertar_preferencia(PreferenciasUsuario model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _prefs_user_db.insertar_preferencia(model.id_persona_rol, model.idioma);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }


        [HttpPut]
        [Route("actualizar")]
        public Resultado Put_actualizar_preferencia(PreferenciasUsuario model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _prefs_user_db.actualizar_preferencia(model.id_persona_rol, model.idioma);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }


        [HttpGet]
        [Route("obtener")]
        public Resultado Get_obtener_preferencia_usuario(int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                PreferenciasUsuario list_prefs = _prefs_user_db.obtener_preferencia(id_persona_rol);
                if (list_prefs != null)
                {
                    result.Codigo = 1;
                    result.Data = list_prefs;
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
}
