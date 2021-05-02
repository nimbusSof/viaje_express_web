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
    public class OperadoraController : ControllerBase
    {

        private readonly ILogger<OperadoraController> _logger;
        private readonly OperadoraBD _operadoraBd;

        public OperadoraController(ILogger<OperadoraController> logger, OperadoraBD operadoraBD)
        {
            _logger = logger;
            _operadoraBd = operadoraBD;
        }

        [HttpGet]
        public List<Operadora> Get()
        {
            return _operadoraBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public Operadora Get(int id)
        {
            return _operadoraBd.Obtener(id);
        }

        [HttpPost]
        public Operadora Post(Operadora model)
        {
            return _operadoraBd.Insertar(model.CooperativaId, model.PersonaRolId,model.CreatedBy);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, Operadora model)
        {
            return _operadoraBd.Modificar(id, model.CooperativaId, model.PersonaRolId, model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 0;
            return _operadoraBd.Eliminar(id, deletedBy);
        }

    }
}