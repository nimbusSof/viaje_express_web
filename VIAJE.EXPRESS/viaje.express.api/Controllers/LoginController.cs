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
        public Object iniciarLogin(LoginParametros model)
        {
            string token = Guid.NewGuid().ToString();

            BaseResultadoLogin result = _login_Db.login(model.correo, model.clave, token);

            if (result.exito)
            {
                if (result.rol == 1) // 1 -> rol Super Adminitrador
                {
                    ResultadoLoginSuperAdministrador mod = new ResultadoLoginSuperAdministrador();
                    mod.exito = result.exito;
                    mod.id_persona_rol = result.id_persona_rol;
                    mod.rol = result.rol;
                    mod.mensaje = result.mensaje;
                    mod.token = result.token;
                    return mod;
                }
                else if (result.rol == 2) // 2 -> rol Adminitrador Cooperativa
                {
                    ResultadoLoginAdminCoop mod = new ResultadoLoginAdminCoop();
                    mod.exito = result.exito;
                    mod.id_persona_rol = result.id_persona_rol;
                    mod.rol = result.rol;
                    mod.id_cooperativa = result.id_cooperativa;
                    mod.mensaje = result.mensaje;
                    mod.token = result.token;
                    return mod;
                }
                else if (result.rol == 3) // 3 -> rol Operador Cooperativa
                {
                    ResultadoLoginOperador mod = new ResultadoLoginOperador();
                    mod.exito = result.exito;
                    mod.id_persona_rol = result.id_persona_rol;
                    mod.rol = result.rol;
                    mod.id_cooperativa = result.id_cooperativa;
                    mod.mensaje = result.mensaje;
                    mod.token = result.token;
                    return mod;
                }
                else if (result.rol == 4) // 3 -> rol Chofer Cooperativa
                {
                    ResultadoLoginChofer mod = new ResultadoLoginChofer();
                    mod.exito = result.exito;
                    mod.id_persona_rol = result.id_persona_rol;
                    mod.rol = result.rol;
                    mod.id_cooperativa = result.id_cooperativa;
                    mod.id_vehiculo = result.id_vehiculo;
                    mod.mensaje = result.mensaje;
                    mod.token = result.token;
                    return mod;
                } else
                {
                    ResultadoLogin mod = new ResultadoLogin();
                    mod.exito = result.exito;
                    mod.id_persona_rol = result.id_persona_rol;
                    mod.rol = result.rol;
                    mod.mensaje = result.mensaje;
                    mod.token = result.token;
                    return mod;
                }
            }
            else
            {
                ResultadoLoginIncorrecto mod = new ResultadoLoginIncorrecto();
                mod.exito = result.exito;
                mod.mensaje = result.mensaje;
                return mod;
            }
        }

        [HttpPost]
        [Route("Cliente")]
        public ResultadoLoginCliente iniciarLoginCliente(LoginParametros model)
        {
            string token = Guid.NewGuid().ToString();
            return _login_Db.loginCliente(model.correo, model.clave, token);
        }
    }
}
