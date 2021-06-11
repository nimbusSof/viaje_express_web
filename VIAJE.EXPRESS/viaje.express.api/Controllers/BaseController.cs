using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data;
using viaje.express.model;

namespace viaje.express.api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly Entities_db _entities_db;
        public string mensaje;
        public int codigo;

        public BaseController()
        {
            _entities_db = new Entities_db();
            mensaje = "Para realizar esta acción necesita autentificarse";
            codigo = -1;
        }

        public bool verificar(string token)
        {
            SecurityViewModel sv = _entities_db.getToken(token);

            if (sv != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public void iniciarLogidn()
        {

        }
    }
}
