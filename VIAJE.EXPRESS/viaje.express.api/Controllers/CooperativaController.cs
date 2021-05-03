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

        public CooperativaController(ILogger<CooperativaController> logger, Cooperativa_db cooperativa_db)
        {
            _logger = logger;
            _cooperativa_db = cooperativa_db;
        }

        [HttpGet]
        public List<Cooperativa> Get_listar_cooperativas(Listar model)
        {
            return _cooperativa_db.listar_cooperativas(model.columna, model.nombre, model.offset, model.limit, model.sort);
        }

        [HttpGet]
        [Route("{id}")]
        public Cooperativa Get_obtener_cooperativa(int id)
        {
            return _cooperativa_db.obtener_cooperativa(id);
        }

        [HttpPost]
        public Resultado Post_insertar_cooperativa(Cooperativa model)
        {
            return _cooperativa_db.insertar_cooperativa(model.id_persona_rol_admin, model.nombre, model.direccion, model.telefono, 
                model.lat, model.lng, model.activo ,model.Created_by);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Post_actualizar_cooperativa(int id, Cooperativa model)
        {
            return _cooperativa_db.actualizar_cooperativa(id, model.nombre, model.direccion, model.telefono, 
                model.lat, model.lng, model.activo, model.Modified_by);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id, Cooperativa model)
        {
            return _cooperativa_db.eliminar_cooperativa(id, model.Deleted_by);
        }

        /*[HttpGet]
        public List<Cooperativa_old> Get()
        {
            return _cooperativaBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public Cooperativa_old Get(int id)
        {
            return _cooperativaBd.Obtener(id);
        }
        [HttpGet]
        [Route("{id}/{aux}")]
        public Cooperativa_old Get(int id, string aux)
        {
            return _cooperativaBd.Obtener_Usuario(id, aux);
        }
        [HttpPost]
        public Cooperativa_old Post(Cooperativa_old model)
        {
            return _cooperativaBd.Insertar(model.IdPersonarol, model.Nombrecoop, model.DireccionCoop, model.TelefonoCoop, model.CreatedBy);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, Cooperativa_old model)
        {
            return _cooperativaBd.Modificar(id,model.IdPersonarol, model.Nombrecoop, model.DireccionCoop, model.TelefonoCoop, model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 0;
            return _cooperativaBd.Eliminar(id, deletedBy );
        }*/

    }
}
