using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data;
using viaje.express.model;

namespace viaje.express.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RutaChoferController : ControllerBase
    {

        private readonly ILogger<RutaChoferController> _logger;
        private readonly RutaChoferBd _rutaChoferBd;

        public RutaChoferController(ILogger<RutaChoferController> logger, RutaChoferBd rutaChoferBd)
        {
            _logger = logger;
            _rutaChoferBd = rutaChoferBd;
        }

        [HttpGet]
        public List<RutaChofer> Get()
        {

            return _rutaChoferBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public RutaChofer Get(int id)
        {
            return _rutaChoferBd.Obtener(id);
        }

        [HttpPost]
        public RutaChofer Post(RutaChofer model)
        {
            return _rutaChoferBd.Insertar(model.CooperativaId, model.ChoferId, model.RutaId, model.CreatedBy);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, RutaChofer model)
        {
            return _rutaChoferBd.Modificar(id, model.CooperativaId, model.ChoferId, model.RutaId, model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 0;
            return _rutaChoferBd.Eliminar(id, deletedBy);
        }

    }



}


