using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data;
using viaje.express.model;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolBd _rolBd;



        public RolController (RolBd rolBd)
        {
          
            _rolBd = rolBd;
        }

        
       
        [HttpGet]
        [Route("{id}")]
        public Rol Get(int id)
        {
            return _rolBd.Obtener(id);
        }

    }
}
