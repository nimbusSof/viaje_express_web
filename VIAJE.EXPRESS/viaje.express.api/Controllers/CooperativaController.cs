using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using viaje.express.data;
using viaje.express.model;

namespace viaje.express.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CooperativaController : ControllerBase
    {

        private readonly ILogger<CooperativaController> _logger;
        private readonly CooperativaBd _cooperativaBd;

        public CooperativaController(ILogger<CooperativaController> logger, CooperativaBd cooperativaBd)
        {
            _logger = logger;
            _cooperativaBd = cooperativaBd;
        }

        [HttpGet]
        public List<Cooperativa> Get()
        {
       
          
            return _cooperativaBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public Cooperativa Get(int id)
        {
            return _cooperativaBd.Obtener(id);
        }
        [HttpGet]
        [Route("{id}/{aux}")]
        public Cooperativa Get(int id, string aux)
        {
            return _cooperativaBd.Obtener_Usuario(id, aux);
        }
        [HttpPost]
        public Cooperativa Post(Cooperativa model)
        {
            return _cooperativaBd.Insertar(model.IdPersonarol, model.Nombrecoop, model.DireccionCoop, model.TelefonoCoop, model.CreatedBy);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, Cooperativa model)
        {
            return _cooperativaBd.Modificar(id,model.IdPersonarol, model.Nombrecoop, model.DireccionCoop, model.TelefonoCoop, model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 0;
            return _cooperativaBd.Eliminar(id, deletedBy );
        }

    }
}
