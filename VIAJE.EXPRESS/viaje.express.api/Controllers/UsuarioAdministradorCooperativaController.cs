using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.data.DataUsuario;
using viaje.express.model.ModelUsuario;
using viaje.express.model;
using Microsoft.Extensions.Logging;


namespace viaje.express.api.Controllers
{
    public class UsuarioAdministradorCooperativaController : Controller
    {
        private readonly ILogger<UsuarioAdministradorCooperativa> _logger;
        private readonly Usuario_db _usuario_db;
        private BaseController bc;

        public UsuarioAdministradorCooperativaController(ILogger<UsuarioAdministradorCooperativa> logger, Usuario_db usuario_db)
        {
            _logger = logger;
            _usuario_db = usuario_db;
            bc = new BaseController();
        }

        [HttpPost]
        public Resultado Post_insertar_administrador_cooperativa(UsuarioAdministradorCooperativa model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _usuario_db.insertar_usuario_admin_coop(model.cedula, model.nombre, model.genero,model.apellido, model.fecha_nacimiento,
                        model.telefono, model.correo, model.clave, model.path_foto, model.id_cooperativa, model.Created_by);
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }
    }
}
