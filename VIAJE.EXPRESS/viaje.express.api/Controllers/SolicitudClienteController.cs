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
    public class SolicitudClienteController : ControllerBase
    {

        private readonly ILogger<SolicitudClienteController> _logger;
        private readonly SolicitudClienteBd _solicitudClienteBd;

        public SolicitudClienteController(ILogger<SolicitudClienteController> logger, SolicitudClienteBd solicitudClienteBd)
        {
            _logger = logger;
            _solicitudClienteBd = solicitudClienteBd;
        }

        [HttpGet]
        public List<SolicitudCliente> Get()
        {


            return _solicitudClienteBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public List<SolicitudCliente> Get(int id)
        {
            return _solicitudClienteBd.Obtener(id);
        }
       
        [HttpPost]
        public SolicitudCliente Post(SolicitudCliente model)
        {
            return _solicitudClienteBd.Insertar(model.PersonaRolId, model.TipoSolicitudId, model.SolicitudClienteSalidaSolCliente, model.SolicitudClienteDestinoSolCliente, model.EstadoSolicitudId, model.CreatedBy);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, SolicitudCliente model)
        {
            return _solicitudClienteBd.Modificar(id, model.PersonaRolId, model.TipoSolicitudId, model.SolicitudClienteSalidaSolCliente, model.SolicitudClienteDestinoSolCliente, model.EstadoSolicitudId, model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 0;
            return _solicitudClienteBd.Eliminar(id, deletedBy);
        }

    }
}