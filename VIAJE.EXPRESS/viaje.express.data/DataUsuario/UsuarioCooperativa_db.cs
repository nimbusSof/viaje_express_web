using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelUsuario;
using viaje.express.model;

namespace viaje.express.data.DataUsuario
{
    public class UsuarioCooperativa_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();
        

        public Resultado eliminar_usuario_rol_falla_modulo(int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_eliminar_usuario_insertado] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado actualizar_usuario_cooperativa(int id_persona_rol, string cedula, string nombre, string apellido, DateTime fecha_nacimiento, string genero,
            string telefono, string correo, string path_foto, int modified_by)
        {
            Consulta consulta = new Consulta("[proc_actualizar_usuario_cooperativa] @id_persona_rol, @cedula, @nombre, @apellido, @fecha_nacimiento, @genero, "
                + "@telefono, @correo, @path_foto, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@cedula", cedula));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@apellido", apellido));
            consulta.AgregarParametro(db.CrearParametro("@fecha_nacimiento", fecha_nacimiento));
            consulta.AgregarParametro(db.CrearParametro("@genero", genero));
            consulta.AgregarParametro(db.CrearParametro("@telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@correo", correo));
            consulta.AgregarParametro(db.CrearParametro("@path_foto", path_foto));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modified_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado resetear_clave(int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_resetear_clave] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
    }
}
