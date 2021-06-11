using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelCuentas;
using viaje.express.model.ModelCuentas.CuentaUsuarioCliente;
using viaje.express.data.DataCuentas;
using viaje.express.model.ModelAgendarSolicitudCliente;
using viaje.express.data.DataAgendarSolicitudCliente;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentaClienteController : ControllerBase
    {
        private readonly ILogger<CuentaClienteController> _logger;
        private readonly CuentaUsuarioCliente_db _cuenta_user_db;
        private readonly CuentaUsuario_db _p_cuenta_user_db;
        private readonly AgendarSolicitudCliente_db _agen_solic_cli_db;
        private BaseController bc;

        public CuentaClienteController(ILogger<CuentaClienteController> logger, CuentaUsuarioCliente_db cuenta_user_db)
        {
            _logger = logger;
            _cuenta_user_db = cuenta_user_db;
            bc = new BaseController();
            _p_cuenta_user_db = new CuentaUsuario_db();
            _agen_solic_cli_db = new AgendarSolicitudCliente_db();
        }

        [HttpPost]
        [Route("registro_cliente")]
        public Resultado Post_registrar_cliente(RegistroCliente model)
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            Resultado r = _cuenta_user_db.registro_cliente(model.cedula, model.nombre, model.apellido, model.fecha_nacimiento,
                model.genero, model.telefono, model.correo, model.clave, model.path_foto);

            if (r.Exito)
            {
                r.Mensaje = "Registro exitoso";
                return r;
            }
            else
            {
                // un usuario de la cooperativa quiere registrarse como clinte
                Resultado r2 = _cuenta_user_db.obtener_usuario_por_cedula(model.cedula);
                if (r2 != null)
                {
                    return r2;
                }
                else
                {
                    return r;
                }
            }
        }

        [HttpPost]
        [Route("registro_persona_rol_cliente")]
        public Resultado Post_ingresar_persona_rol_cliente(model_id_persona model)
        {
            return _cuenta_user_db.insertar_usuario_rol_para_cliente(model.id_persona);
        }

        /* AGENDAR SOLICITUD CLIENTE */
        [HttpPost]
        [Route("insertar_carrera_programada")]
        public Resultado Post_insertar_carrera_programada(InsertarAgendarSolicitudCliente_programada model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _agen_solic_cli_db.cliente_insertar_agendar_solicitud_cliente_carrera_programada(model);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPost]
        [Route("insertar_carrera_justo_ahora")]
        public Resultado Post_insertar_carrera_now(InsertarAgendarSolicitudCliente_now model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _agen_solic_cli_db.cliente_insertar_agendar_solicitud_cliente_carrera_now(model);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPut]
        [Route("cancelar_carrera/{id_persona_rol}")]
        public Resultado Put_cancelar_carrera(int id_persona_rol, CambiosDeEstado model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _agen_solic_cli_db.cliente_cancelar_carrera(id_persona_rol, model);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPut]
        [Route("unirse_carrera_compartida/{id_persona_rol}")]
        public Resultado Put_unirse_carrera_compartida(int id_persona_rol, CambiosDeEstado model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _agen_solic_cli_db.cliente_unirse_carrera_compartida(id_persona_rol, model);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPost]
        [Route("listar_carreras_programadas_compartidas/{id_persona_rol}")]
        public Resultado Post_listar_carreras_programadas_compartidas(int id_persona_rol, Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<Cliente_ObtenerCarreraProgramadaCompartida> listAgenSolicCli = _agen_solic_cli_db.cliente_listar_carreras_programadas_compartidas(id_persona_rol, model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listAgenSolicCli.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = listAgenSolicCli;
                    result.Mensaje = "Correcto";
                    result.Exito = true;
                    return result;
                }
                else
                {
                    result.Mensaje = "No se encontro ningun registro";
                    return result;
                }
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPost]
        [Route("listar_historial_carreras_programadas/{id_persona_rol}")]
        public Resultado Post_listar_historial_carreras_programadas(int id_persona_rol, Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<Cliente_Historial_AgendarSolicitudCliente_programada> listHist = _agen_solic_cli_db.cliente_historial_carreras_programadas(id_persona_rol, model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listHist.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = listHist;
                    result.Mensaje = "Correcto";
                    result.Exito = true;
                    return result;
                }
                else
                {
                    result.Mensaje = "No se encontro ningun registro";
                    return result;
                }
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPost]
        [Route("listar_historial_carreras_justo_ahora/{id_persona_rol}")]
        public Resultado Post_listar_historial_carreras_justo_ahora(int id_persona_rol, Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<Cliente_Historial_AgendarSolicitudCliente_now> listHist = _agen_solic_cli_db.cliente_historial_carreras_now(id_persona_rol, model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listHist.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = listHist;
                    result.Mensaje = "Correcto";
                    result.Exito = true;
                    return result;
                }
                else
                {
                    result.Mensaje = "No se encontro ningun registro";
                    return result;
                }
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }
        /* -------------------------- */
    }

    public class model_id_persona
    {
        public int id_persona { get; set; }
    }
}
