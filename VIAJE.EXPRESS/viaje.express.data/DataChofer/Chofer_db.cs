using System;
using System.Collections.Generic;
using System.Text;

using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelChofer;
using viaje.express.model;

namespace viaje.express.data.DataChofer
{
    public class Chofer_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado insertar_chofer(int id_cooperativa, int id_persona_rol_chofer, int id_vehiculo, int puntos_licencia, int created_by)
        {
            Consulta consulta = new Consulta("[proc_insertar_chofer] @id_cooperativa, @id_persona_rol_chofer, @id_vehiculo, @puntos_licencia, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol_chofer", id_persona_rol_chofer));
            consulta.AgregarParametro(db.CrearParametro("@id_vehiculo", id_vehiculo));
            consulta.AgregarParametro(db.CrearParametro("@puntos_licencia", puntos_licencia));
            consulta.AgregarParametro(db.CrearParametro("@created_by", created_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado insertar_usuario_chofer(string cedula, string nombre, string apellido, DateTime fecha_nacimiento, string genero,
            string telefono, string correo, string clave, string path_foto, int created_by)
        {
            int id_rol_chofer = 4; // id_rol Chofer
            Consulta consulta = new Consulta("[proc_insertar_usuario] @cedula, @nombre, @apellido, @fecha_nacimiento, @genero, "
                + "@telefono, @correo, @clave, @path_foto, @id_rol, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@cedula", cedula));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@apellido", apellido));
            consulta.AgregarParametro(db.CrearParametro("@fecha_nacimiento", fecha_nacimiento));
            consulta.AgregarParametro(db.CrearParametro("@genero", genero));
            consulta.AgregarParametro(db.CrearParametro("@telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@correo", correo));
            consulta.AgregarParametro(db.CrearParametro("@clave", clave));
            consulta.AgregarParametro(db.CrearParametro("@path_foto", path_foto));
            consulta.AgregarParametro(db.CrearParametro("@id_rol", id_rol_chofer));
            consulta.AgregarParametro(db.CrearParametro("@created_by", created_by));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
        
        public Resultado actualizar_chofer(int id_persona_rol, int id_vehiculo, int puntos_licencia, bool activo, int modified_by)
        {
            Consulta consulta = new Consulta("[proc_actualizar_chofer] @id_persona_rol, @id_vehiculo, @puntos_licencia, @activo, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@id_vehiculo", id_vehiculo));
            consulta.AgregarParametro(db.CrearParametro("@puntos_licencia", puntos_licencia));
            consulta.AgregarParametro(db.CrearParametro("@activo", activo));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modified_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado eliminar_chofer(int id_persona_rol, int deleted_by)
        {
            Consulta consulta = new Consulta("[proc_eliminar_chofer] @id_persona_rol, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deleted_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public List<ObtenerUsuarioChofer> listar_choferes(int id_cooperativa, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_listar_choferes] @id_cooperativa, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<ObtenerUsuarioChofer>(consulta);
        }

        public ObtenerUsuarioChofer obtener_chofer(int id_persona_rol)
        {
            Consulta consulta = new Consulta("[proc_obtener_chofer] @id_persona_rol");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol", id_persona_rol));
            return db.EjecutarFilaUnica<ObtenerUsuarioChofer>(consulta);
        }
    }
}
