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

    public class LugarController : ControllerBase
    {

        private readonly ILogger<LugarController> _logger;
        private readonly LugarBd _lugarBd;

        public LugarController(ILogger<LugarController> logger, LugarBd lugarBd)
        {
            _logger = logger;
            _lugarBd = lugarBd;
        }

        [HttpGet]
        public List<Lugar> Get()
        {
            return _lugarBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public Lugar Get(int id)
        {
            return _lugarBd.Obtener(id);
        }

       

        [HttpPost]
        public Lugar Post(Lugar model)
        {
            
            return _lugarBd.Insertar(model.CooperativaId, model.LugarLatitud, model.LugarLongitud, model.LugarNombre, model.CreatedBy);
        }

        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, Lugar model)
        {
            return _lugarBd.Modificar(id, model.CooperativaId, model.LugarLatitud, model.LugarLongitud, model.LugarNombre, model.ModifiedBy);
        }

        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 1;
            return _lugarBd.Eliminar(id, deletedBy);
        }

    }
}
