using System;
using System.Collections.Generic;
using System.Text;

using viaje.express.model.ModelCuentas;
using viaje.express.model;
using Nimbussoft.BaseDeDatos;


namespace viaje.express.data.DataCuentas
{
    public class CuentaUsuario_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado actualizar_perfil_usuario(int id_persona_rol, string nombre, string apellido, DateTime fecha_nacimiento, string genero,
            string telefono, string correo, string clave, string path_foto, string token, int modified_by)
        {
            Consulta consulta = new Consulta("[proc_actualizar_usuario_perfil] @id_persona_rol, @nombre, @apellido, @fecha_nacimiento, @genero, "
                + "@telefono, @correo, @clave, @path_foto, @token, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@apellido", apellido));
            consulta.AgregarParametro(db.CrearParametro("@fecha_nacimiento", fecha_nacimiento));
            consulta.AgregarParametro(db.CrearParametro("@genero", genero));
            consulta.AgregarParametro(db.CrearParametro("@telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@correo", correo));
            consulta.AgregarParametro(db.CrearParametro("@clave", clave));
            consulta.AgregarParametro(db.CrearParametro("@path_foto", path_foto));
            consulta.AgregarParametro(db.CrearParametro("@token", token));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modified_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public ObtenerPerfilUsuario obtener_perfil_usuario(int id_persona_rol, string token)
        {
            Consulta consulta = new Consulta("[proc_obtener_cuenta_usuario] @id_persona_rol, @token");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@token", token));
            return db.EjecutarFilaUnica<ObtenerPerfilUsuario>(consulta);
        }
    }
}
