using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using viaje.express.model.ModelModulos;
using viaje.express.data.DataUsuario;
using viaje.express.data.DataModulo;
using viaje.express.model.ModelUserOperadorCooperativa;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioOperadorCooperativaController : ControllerBase
    {
        private readonly ILogger<UsuarioOperadorCooperativaController> _logger;
        private readonly UsuarioCooperativa_db _usuario_cooperativa_db;
        private readonly UsuarioOperadorCooperativa_db _usuario_operador_db;
        private readonly Modulo_db _modulo_db;
        private BaseController bc;

        public UsuarioOperadorCooperativaController(ILogger<UsuarioOperadorCooperativaController> logger, UsuarioOperadorCooperativa_db usuario_operador_db)
        {
            _logger = logger;
            _usuario_operador_db = usuario_operador_db;
            _usuario_cooperativa_db = new UsuarioCooperativa_db();
            _modulo_db = new Modulo_db();
            bc = new BaseController();
        }

        [HttpPost]
        public Resultado Post_insertar_operador_cooperativa(InsertarOperadorCooperativa model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                if(model.modulos.Count == 0)
                {
                    result.Mensaje = "Ningun modulo asignado";
                    return result;
                }

                string clave = model.cedula;
                Resultado rp = _usuario_operador_db.insertar_usuario_operador(model.cedula, model.nombre, model.apellido, model.fecha_nacimiento,
                        model.genero, model.telefono, model.correo, clave, model.path_foto, model.id_cooperativa, model.Created_by);

                if (rp.Exito)
                {
                    int i = 0;
                    for (i = 0; i < model.modulos.Count; i++)
                    {
                        Resultado rm = _modulo_db.insertar_usuario_rol_modulo(
                        model.id_persona_rol_ejecucion, rp.Codigo, model.modulos[i]);
                        if (!rm.Exito)
                        {
                            Resultado r =_usuario_cooperativa_db.eliminar_usuario_rol_falla_modulo(rp.Codigo);
                            result.Mensaje = rm.Mensaje;
                            result.Codigo = rm.Codigo;
                            return result;
                        }
                    }

                    if (i == model.modulos.Count)
                    {
                        result.Exito = true;
                        result.Mensaje = rp.Mensaje;
                        result.Codigo = rp.Codigo;
                        return result;
                    }
                    else
                    {
                        result.Mensaje = "Error al ingresar usuario operador";
                        result.Codigo = 0;
                        return result;
                    }
                }
                else
                {
                    result.Mensaje = rp.Mensaje;
                    result.Codigo = rp.Codigo;
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
        [Route("Listar/{id_cooperativa}")]
        public Resultado Post_listar_operador_cooperativa(int id_cooperativa, Listar model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ObtenerOperadorCooperativa> listOperador = _usuario_operador_db.listar_operador_cooperativa(
                    id_cooperativa, model.columna, model.nombre, model.offset, model.limit, model.sort);
                if (listOperador.Count > 0)
                {
                    for(int i=0; i< listOperador.Count; i++)
                    {
                        List<ModuloRol> list_modulos = _modulo_db.getRutasRol(listOperador[i].id_persona_rol);
                        if(list_modulos.Count > 0)
                        {
                            listOperador[i].modulos = list_modulos;
                        } else
                        {
                            r.Mensaje = "No se pudo obtener los modulos";
                            return r;
                        }
                    }

                    r.Codigo = 1;
                    r.Data = listOperador;
                    r.Mensaje = "Correcto";
                    r.Exito = true;
                    return r;
                                       
                }
                else
                {
                    r.Mensaje = "No se encontro ningun registro";
                    return r;
                }
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        [HttpGet]
        [Route("{id_persona_rol}")]
        public Resultado Get_obtener_operador_cooperativa(int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                ObtenerOperadorCooperativa operador = _usuario_operador_db.obtener_operador_cooperativa(id_persona_rol);
                if (operador != null)
                {
                    List<ModuloRol> list_modulos = _modulo_db.getRutasRol(id_persona_rol);
                    if (list_modulos.Count > 0)
                    {
                        operador.modulos = list_modulos;
                        r.Codigo = 1;
                        r.Data = operador;
                        r.Mensaje = "Correcto";
                        r.Exito = true;
                        return r;
                    }
                    else
                    {
                        r.Mensaje = "No se pudo obtener los modulos";
                        return r;
                    }         
                }
                else
                {
                    r.Mensaje = "No se encontro ningun registro";
                    return r;
                }
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        [HttpPut]
        [Route("{id_persona_rol}")]
        public Resultado Put_actualizar_operador_cooperativa(int id_persona_rol, [FromBody] ActualizarOperadorCooperativa model, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                if (model.modulos.Count == 0)
                {
                    result.Mensaje = "Ningun modulo asignado";
                    return result;
                }

                Resultado r = _usuario_cooperativa_db.actualizar_usuario_cooperativa(id_persona_rol, model.cedula, model.nombre, model.apellido,
                    model.fecha_nacimiento, model.genero, model.telefono, model.correo, model.path_foto, model.modified_by);
                if (r.Exito)
                {
                    if (_modulo_db.eliminar_modulo_persona_rol(id_persona_rol).Exito)
                    {
                        for (int i = 0; i < model.modulos.Count; i++)
                        {
                            Resultado rm = _modulo_db.insertar_usuario_rol_modulo(
                            model.id_persona_rol_ejecucion, id_persona_rol, model.modulos[i]);
                            if (!rm.Exito)
                            {
                                result.Mensaje = rm.Mensaje;
                                result.Codigo = rm.Codigo;
                                return result;
                            }
                        }
                        return _usuario_operador_db.actualizar_operador_cooperativa(
                        id_persona_rol, model.activo, model.modified_by);
                    }
                    else
                    {
                        result.Mensaje = "No se pudo actualizar los modulos del operador cooperativa";
                        return result;
                    }
                }
                else
                {
                    result.Mensaje = r.Mensaje;
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

        [HttpPut]
        [Route("reset_clave/{id_persona_rol}")]
        public Resultado Put_resetear_clave(int id_persona_rol, [FromHeader] string token = "")
        {
            Resultado result = new Resultado();
            result.Exito = false;
            result.Codigo = 0;

            if (bc.verificar(token))
            {
                return _usuario_cooperativa_db.resetear_clave(id_persona_rol);
            }
            else
            {
                result.Mensaje = bc.mensaje;
                result.Codigo = bc.codigo;
                return result;
            }
        }
       

        [HttpDelete]
        [Route("{id_persona_rol}")]
        public Resultado Delete_eliminar_operador_cooperativa(int id_persona_rol, EliminarUsuarioOperadorCooperativa model, [FromHeader] string token = "")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                return _usuario_operador_db.eliminar_operador_cooperativa(id_persona_rol, model.deleted_by);
            }
            else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

    }

    public class EliminarUsuarioOperadorCooperativa
    {
        public int deleted_by { get; set; }
    }
}
