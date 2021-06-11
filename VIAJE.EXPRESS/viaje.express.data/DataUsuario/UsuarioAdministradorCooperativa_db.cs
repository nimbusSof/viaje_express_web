using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelUserAdministradorCooperativa;
using viaje.express.model;

namespace viaje.express.data.DataUsuario
{
    public class UsuarioAdministradorCooperativa_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado insertar_usuario_admin_coop(string cedula, string nombre, string apellido, DateTime fecha_nacimiento, string genero,
            string telefono, string correo, string clave, string foto_path, int id_cooperativa, int created_by)
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

        public List<ObtenerAdminitradorCooperativa> listar_administardor_cooperativa(string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_listar_usuarios_administrador_cooperativa] @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));
            return db.EjecutarConsulta<ObtenerAdminitradorCooperativa>(consulta);
        }

        public ObtenerAdminitradorCooperativa obtener_administrador_cooperativa(int id)
        {
            Consulta consulta = new Consulta("[proc_obtener_usuario_administrador_cooperativa] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id));
            return db.EjecutarFilaUnica<ObtenerAdminitradorCooperativa>(consulta);
        }

        public Resultado actualizar_administrador_cooperativa(int id_persona_rol, int id_cooperativa, bool activo, int modified_by)
        {
            Consulta consulta = new Consulta("[proc_actualizar_administrador_cooperativa] @id_persona_rol, @id_cooperativa, @activo, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@activo", activo));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modified_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado eliminar_administrador_cooperativa(int id_persona_rol, int deleted_by)
        {
            Consulta consulta = new Consulta("[proc_eliminar_administrador_cooperativa] @id_persona_rol, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deleted_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

    }
}
