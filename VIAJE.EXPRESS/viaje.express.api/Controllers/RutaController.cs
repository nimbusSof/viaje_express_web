using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using viaje.express.data;
using viaje.express.model;

namespace viaje.express.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RutaController : ControllerBase
    {

        private readonly ILogger<RutaController> _logger;
        private readonly RutaBd _rutaBd;

        public RutaController(ILogger<RutaController> logger, RutaBd rutaBd)
        {
            _logger = logger;
            _rutaBd = rutaBd;
        }

        [HttpGet]
        public List<Ruta> Get()
        {       
            
            return _rutaBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public Ruta Get(int id)
        {
            return _rutaBd.Obtener(id);
        }

        [HttpPost]
        public Ruta Post(Ruta model)
        {
            return _rutaBd.Insertar(model.CooperativaId, model.SalidaId, model.DestinoId, model.RutaFecha, model.RutaHora ,model.RutaMonto,model.CreatedBy);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, Ruta model)
        {
            return _rutaBd.Modificar(id, model.CooperativaId, model.SalidaId, model.DestinoId, model.RutaFecha, model.RutaHora, model.RutaMonto,model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 0;
            return _rutaBd.Eliminar(id, deletedBy);
        }

    }



}



