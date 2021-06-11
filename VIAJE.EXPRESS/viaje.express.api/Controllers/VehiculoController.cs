using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelVehiculo;
using viaje.express.data.DataVehiculo;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly ILogger<VehiculoController> _logger;
        private readonly Vehiculo_db _vehiculo_db;
        private BaseController bc;
        

        public VehiculoController(ILogger<VehiculoController> logger, Vehiculo_db vehiculo_db)
        {
            _logger = logger;
            _vehiculo_db = vehiculo_db;
            bc = new BaseController();
        }

        [HttpPost]
        public Resultado Post_insertar_vehiculo(InsertarVehiculo model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {             
                return _vehiculo_db.insertar_vehiculo(model.id_cooperativa, model.placa, model.matricula,
                    model.color, model.created_by);             
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPut]
        [Route("{id_vehiculo}")]
        public Resultado Post_actualizar_vehiculo(int id_vehiculo, ActualizarVehiculo model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _vehiculo_db.actualizar_vehiculo(id_vehiculo, model.matricula,
                    model.color, model.activo, model.modified_by);            
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpDelete]
        [Route("{id_vehiculo}")]
        public Resultado eliminar_vehiculo(int id_vehiculo, eliminarVehiculo model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return  _vehiculo_db.eliminar_veiculo(id_vehiculo, model.deleted_by);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }

        [HttpPost]
        [Route("Listar/{id_cooperativa}")]
        public Resultado Get_listar_vehiculos(int id_cooperativa, Listar model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerVehiculo> listVehiculo = _vehiculo_db.listar_vehiculo(id_cooperativa, model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listVehiculo.Count > 0)
                {
                    result.Codigo = 1;
                    result.Data = listVehiculo;
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
        [Route("{id_vehiculo}")]
        public Resultado Get_obtener_vehiculo(int id_vehiculo, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                ObtenerVehiculo vehi = _vehiculo_db.obtener_vehiculo(id_vehiculo);
                if (vehi != null)
                {
                    result.Codigo = 1;
                    result.Data = vehi;
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

    public class eliminarVehiculo
    {
        public int deleted_by { get; set; }
    }

}
