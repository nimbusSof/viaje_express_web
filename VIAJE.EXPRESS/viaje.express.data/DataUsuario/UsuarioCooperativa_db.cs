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

        public List<UsuarioAdministradorCooperativa> listar_administardor_cooperativa(string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_listar_usuarios_administrador_cooperativa] @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));
            return db.EjecutarConsulta<UsuarioAdministradorCooperativa>(consulta);
        }

        public UsuarioAdministradorCooperativa obtener_administrador_cooperativa(int id)
        {
            Consulta consulta = new Consulta("[proc_obtener_usuario_administrador_cooperativa] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id));
            return db.EjecutarFilaUnica<UsuarioAdministradorCooperativa>(consulta);
        }

        public Resultado insertar_usuario_rol__modulo(int id_persona_rol_ejecucion, int id_persona_rol, int id_modulo)
        {
            Consulta consulta = new Consulta("[proc_persona_rol_modulo] @id_persona_rol_ejecucion, @id_persona_rol, @id_modulo");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol_ejecucion", id_persona_rol_ejecucion));
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_modulo", id_modulo));
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
        }


        public Resultado eliminar_usuario_rol_falla_modulo(int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_eliminar_usuario_insertado] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
    }
}
