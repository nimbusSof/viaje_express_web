using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelUsuario;
using viaje.express.model;

namespace viaje.express.data.DataUsuario
{
    public class Usuario_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        /*public Usuario obtener_usuario(int id)
        {
            Consulta consulta = new Consulta("[proc_obtener_usuario] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id));
            return db.EjecutarFilaUnica<Usuario>(consulta);
        }*/
        

        /*public Resultado insertar_usuario_admin_coop(string cedula, string nombre, string apellido, DateTime fecha_nacimiento, string genero,
            string telefono,string correo, string clave, string foto_path, int id_cooperativa, int created_by)
        {
            int id_rol_admin_cooperativa = 2; // id_rol que va pertenercer el usuario, 2 Administraor Cooperativa
            Consulta consulta = new Consulta("[proc_insertar_usuario_cooperativa] @cedula, @nombre, @apellido, @fecha_nacimiento, @genero, "
                + "@telefono, @correo, @clave, @path_foto, @id_rol, @id_cooperativa, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@cedula", cedula));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@apellido", apellido));
            consulta.AgregarParametro(db.CrearParametro("@fecha_nacimiento", fecha_nacimiento));
            consulta.AgregarParametro(db.CrearParametro("@genero", genero));
            consulta.AgregarParametro(db.CrearParametro("@telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@correo", correo));
            consulta.AgregarParametro(db.CrearParametro("@clave", clave));
            consulta.AgregarParametro(db.CrearParametro("@path_foto", foto_path));
            consulta.AgregarParametro(db.CrearParametro("@id_rol", id_rol_admin_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@created_by", created_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }




        public Resultado insertar_usuario_operador(string cedula, string nombre, string apellido, DateTime fecha_nacimiento, string genero,
            string telefono, string correo, string clave, string foto_path, int id_cooperativa, int created_by)
        {
            int id_rol_operador = 3; // id_rol que va pertenercer el usuario, 3 Operador
            Consulta consulta = new Consulta("[proc_insertar_usuario_cooperativa] @cedula, @nombre, @apellido, @fecha_nacimiento, @genero, "
                + "@telefono, @correo, @clave, @path_foto, @id_rol, @id_cooperativa, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@cedula", cedula));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@apellido", apellido));
            consulta.AgregarParametro(db.CrearParametro("@fecha_nacimiento", fecha_nacimiento));
            consulta.AgregarParametro(db.CrearParametro("@genero", genero));
            consulta.AgregarParametro(db.CrearParametro("@telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@correo", correo));
            consulta.AgregarParametro(db.CrearParametro("@clave", clave));
            consulta.AgregarParametro(db.CrearParametro("@path_foto", foto_path));
            consulta.AgregarParametro(db.CrearParametro("@id_rol", id_rol_operador));
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@created_by", created_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }*/
    }
}
