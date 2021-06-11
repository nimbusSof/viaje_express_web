using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelCuentas;
using viaje.express.model.ModelCuentas.CuentaUsuarioChofer;
using viaje.express.data.DataCuentas;
using viaje.express.model.ModelAgendarSolicitudCliente;
using viaje.express.data.DataAgendarSolicitudCliente;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentaChoferController : ControllerBase
    {
        private readonly ILogger<CuentaChoferController> _logger;
        private readonly CuentaUsuarioChofer_db _cuenta_user_db;
        private BaseController bc;
        private readonly AgendarSolicitudCliente_db _agen_solic_cli_db;


        public CuentaChoferController(ILogger<CuentaChoferController> logger, CuentaUsuarioChofer_db cuenta_user_db)
        {
            _logger = logger;
            _cuenta_user_db = cuenta_user_db;
            bc = new BaseController();
            _agen_solic_cli_db = new AgendarSolicitudCliente_db();
        }

        [HttpPut]
        [Route("cambiar_estado_vehiculo/{id_persona_rol}")]
        public Resultado Put_actualizar_estado_vehiculo(int id_persona_rol, ActualizarEstadoVehiculo model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _cuenta_user_db.actualizar_estado_vehiculo(id_persona_rol, model.id_estado_vehiculo);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }


        /* AGENDAR SOLICITUD CLIENTE */
        [HttpPut]
        [Route("cancelar_carrera/{id_persona_rol}")]
        public Resultado Put_cancelar_carrera(int id_persona_rol, CambiosDeEstado model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _agen_solic_cli_db.chofer_cancelar_carrera_cliente(id_persona_rol, model);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPut]
        [Route("comenzar_carrera_cliente/{id_persona_rol}")]
        public Resultado Put_comenzar_carrera_cliente(int id_persona_rol, CambiosDeEstado model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _agen_solic_cli_db.chofer_ejecutar_carrera(id_persona_rol, model);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPut]
        [Route("finalizar_carrera_cliente/{id_persona_rol}")]
        public Resultado Put_finalizar_carrera_cliente(int id_persona_rol, CambiosDeEstado model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _agen_solic_cli_db.chofer_finalizar_carrera_cliente(id_persona_rol, model);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPut]
        [Route("aceptar_solicitud_cliente/{id_persona_rol}")]
        public Resultado Put_aceptar_solicitud_cliente(int id_persona_rol, CambiosDeEstado model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _agen_solic_cli_db.chofer_aceptar_solicitud_cliente(id_persona_rol, model);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPost]
        [Route("listar_carreras_programadas")]
        public Resultado Post_listar_carreras_programadas(Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<Chofer_ObtenerCarreraProgramada> listAgenSolicCli = _agen_solic_cli_db.chofer_listar_carreras_programadas(model.columna, model.nombre, model.offset, model.limit, model.sort);
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
                List<Chofer_Historial_AgendarSolicitudCliente_programada> listHist = _agen_solic_cli_db.chofer_historial_carreras_programadas(id_persona_rol, model.columna, model.nombre, model.offset, model.limit, model.sort);
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
                List<Chofer_Historial_AgendarSolicitudCliente_now> listHist = _agen_solic_cli_db.chofer_historial_carreras_now(id_persona_rol, model.columna, model.nombre, model.offset, model.limit, model.sort);
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
        /*-----------------------------*/
    }
}
