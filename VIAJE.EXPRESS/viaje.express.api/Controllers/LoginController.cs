using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data.DataLogin;
using viaje.express.model.ModelLogin;


namespace viaje.express.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Login_db _login_Db;

        public LoginController(Login_db login_Db)
        {
            _login_Db = login_Db;
        }

        [HttpPost]
        public ResultadoLogin iniciar(LoginParametros model)
        {
            return _login_Db.login(model.correo, model.clave);
        }
    }
}
