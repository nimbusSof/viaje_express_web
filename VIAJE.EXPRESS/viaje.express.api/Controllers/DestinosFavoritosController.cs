using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using viaje.express.data.DataDestinoFavorito;
using viaje.express.model;
using viaje.express.model.ModelDestinoFavorito;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DestinosFavoritosController : ControllerBase
    {

        private readonly ILogger<DestinosFavoritosController> _logger;
        private readonly DestinosFavoritos_db _destinos_user_db;

        private BaseController bc;

        public DestinosFavoritosController(ILogger<DestinosFavoritosController> logger, DestinosFavoritos_db destinos_user_db)
        {
            _logger = logger;
            _destinos_user_db = destinos_user_db;
            bc = new BaseController();
        }

        [HttpPost]
        [Route("insertar/{id_persona_rol}")]
        public Resultado Post_insertar_destino(int id_persona_rol,ModelDestinoFavoritoInsertar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _destinos_user_db.insertar_destinoFavorito(
                       id_persona_rol, model.destino_lat, 
                        model.destino_lon, model.nombre_destino,
                        model.nombre_personalizado);
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
        public Resultado Put_actualizar_destino(ModelDestinoFavoritoActualizar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _destinos_user_db.actualizar_destinoFavorito(
                    model.id_destino, model.destino_lat,
                    model.destino_lon, model.nombre_destino,
                    model.nombre_personalizado, model.id_persona_rol);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }



        [HttpGet]
        [Route("obtener/{id_persona_rol}")]
        public Resultado Get_obtener_destinos_favoritos(
            int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ModelDestinoFavoritoObtener> list_dest = _destinos_user_db.obtener_destinosFavoritos(id_persona_rol);
                
                if (list_dest.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = list_dest;
                    result.Mensaje = "Correcto";
                    result.Exito = true;
                    return result;
                }
                else
                {
                    result.Mensaje = "No se encontro ningún registro";
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



        [HttpDelete]
        [Route("eliminar")]
        public Resultado eliminar_destino(int id_destino, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _destinos_user_db.eliminar_destino_favorito(id_destino);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }


        [HttpGet]
        [Route("obtenerProbando/{id_persona_rol}")]
        public Resultado Get_obtener_probando(
            int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<Probando> list_dest = _destinos_user_db.obtener_probando(id_persona_rol);
               
                if (list_dest.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = list_dest;
                    result.Mensaje = "Correcto";
                    result.Exito = true;
                    return result;
                }
                else
                {
                    result.Mensaje = "No se encontro ningún registro";
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
