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
    public class AgendarClienteController : ControllerBase
    {

        private readonly ILogger<AgendarClienteController> _logger;
        private readonly AgendarClienteBd _agendarClienteBd;

        public AgendarClienteController(ILogger<AgendarClienteController> logger, AgendarClienteBd agendarClienteBd)
        {
            _logger = logger;
            _agendarClienteBd = agendarClienteBd;
        }

        /*[HttpGet]
        public List<AgendarCliente> Get()
        {
            return _agendarClienteBd.Listar();
        }*/

        [HttpGet]
        public List<Prueba_v1> Get()
        {
            return _agendarClienteBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public AgendarCliente Get(int id)
        {
            return _agendarClienteBd.Obtener(id);
        }

        [HttpPost]
        public Prueba_v1 Post(Prueba_v1 model)
        {
            return _agendarClienteBd.Insertar_Prueba(model.fecha, model.hora, model.distancia, model.lat, model.lng, model.monto);
        }

        /*[HttpPost]
        public AgendarCliente Post(AgendarCliente model)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(model.PersonaRolId + " - " + model.AgendarClienteFecha + " - " + model.AgendarClienteHora + " - " +
                model.AgendarClienteSalida + " - " + model.AgendarClienteDestinoe + " - " + model.EstadoSolicitudId + " - " + model.CreatedBy);
            return _agendarClienteBd.Insertar(model.PersonaRolId, model.AgendarClienteFecha, model.AgendarClienteHora, model.AgendarClienteSalida, model.AgendarClienteDestinoe, model.EstadoSolicitudId, model.CreatedBy);
        }*/

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, AgendarCliente model)
        {
            return _agendarClienteBd.Modificar(id, model.PersonaRolId, model.AgendarClienteFecha, model.AgendarClienteHora, model.AgendarClienteSalida, model.AgendarClienteDestinoe, model.EstadoSolicitudId, model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 1;
            return _agendarClienteBd.Eliminar(id, deletedBy);
        }

    }
}