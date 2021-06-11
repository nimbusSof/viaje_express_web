using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelAgendarSolicitudCliente;
using viaje.express.data.DataAgendarSolicitudCliente;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendarSolicitudClienteController : ControllerBase
    {
        private readonly ILogger<AgendarSolicitudClienteController> _logger;
        private readonly AgendarSolicitudCliente_db _agen_solic_cli_db;
        private BaseController bc;

        public AgendarSolicitudClienteController(ILogger<AgendarSolicitudClienteController> logger, AgendarSolicitudCliente_db agen_solic_cli_db)
        {
            _logger = logger;
            _agen_solic_cli_db = agen_solic_cli_db;
            bc = new BaseController();
        }
            
        [HttpPost]
        [Route("Listar/{id_cooperativa}")]
        public Resultado Post_listar_agendar_solicitud_cliente(int id_cooperativa, Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<Operador_ObtenerAgendarSolicitudCliente> listAgenSolicCli = _agen_solic_cli_db.operador_listar_agenda_solicitud_cliente(id_cooperativa, model.columna, model.nombre, model.offset, model.limit, model.sort);
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


        [HttpGet]
        [Route("listar_clientes_carrera_compartida/{id_agendar_solicitud_cliente}")]
        public Resultado Get_listar_clientes_carrera_compartida(int id_agendar_solicitud_cliente, Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerPersonaCarreraCompartida> listCliComp = _agen_solic_cli_db.operador_listar_personas_carrera_compartida(id_agendar_solicitud_cliente);
                if (listCliComp.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = listCliComp;
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
    }
}
