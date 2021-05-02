using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using viaje.express.data;
using viaje.express.model;


namespace viaje.express.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {

        private readonly ILogger<PersonaController> _logger;
        private readonly PersonaBd _personaBd;

        public PersonaController(ILogger<PersonaController> logger, PersonaBd personaBd)
        {
            _logger = logger;
            _personaBd = personaBd;
        }

        [HttpGet]
        public List<Persona> Get()
        {
          
            return _personaBd.Listar();
        }

        [HttpGet]
        [Route("{id}")]
        public Persona Get(int id)
        {
            return _personaBd.Obtener(id);
        }

        [HttpGet]
        [Route("{persona}/{contrasenia}")]
        public Persona Get(string persona,string contrasenia)
        {
            return _personaBd.ObtenerPorLogin(persona, contrasenia);
        }






        [HttpPost]
        public Persona Post(Persona model)
        {
            return _personaBd.Insertar(model.CedulaPersona, model.NombrePersona, model.ApellidosPersona, model.NacimientoPersona, 
                model.TelefonoPersona,model.DireccionPersona, model.CorreoPersona, model.ContraseniaPersona,model.PersonaNombreUsuario,model.CreatedBy);
        }


        [HttpPut]
        [Route("{id}")]
        public Resultado Put(int id, Persona model)
        {
            return _personaBd.Modificar(id, model.CedulaPersona, model.NombrePersona, model.ApellidosPersona, model.NacimientoPersona,
                model.TelefonoPersona, model.DireccionPersona, model.CorreoPersona, model.ContraseniaPersona,model.PersonaNombreUsuario, model.ModifiedBy);
        }


        [HttpDelete]
        [Route("{id}")]
        public Resultado Delete(int id)
        {
            int deletedBy = 0;
            return _personaBd.Eliminar(id, deletedBy);
        }



    }
}
