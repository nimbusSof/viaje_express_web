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
    public class CarreraChoferController : ControllerBase
    {

        private readonly ILogger<CarreraChoferController> _logger;
        private readonly CarreraChoferBd _carreraChoferBd;

        public CarreraChoferController(ILogger<CarreraChoferController> logger, CarreraChoferBd carreraChoferBd)
        {
            _logger = logger;
            _carreraChoferBd = carreraChoferBd;
        }

        [HttpGet]
        public List<CarreraChofer> Get()
        {
            return _carreraChoferBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public CarreraChofer Get(int id)
        {
            return _carreraChoferBd.Obtener(id);
        }

      
        [HttpPost]
        public CarreraChofer Post(CarreraChofer model)
        {
            return _carreraChoferBd.Insertar(model.SolicitudClienteId, model.ChoferId, model.CooperativaId, model.CarreraChoferMonto, model.EstadoSolicitudId, model.CreatedBy);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, CarreraChofer model)
        {
            return _carreraChoferBd.Modificar(id, model.SolicitudClienteId, model.ChoferId, model.CooperativaId, model.CarreraChoferMonto, model.EstadoSolicitudId, model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 1;
            return _carreraChoferBd.Eliminar(id, deletedBy);
        }

    }
}