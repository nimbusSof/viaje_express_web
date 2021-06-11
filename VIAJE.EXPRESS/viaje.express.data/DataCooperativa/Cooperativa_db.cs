using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelCooperativa;
using viaje.express.model;

namespace viaje.express.data.DataCooperativa
{
    public class Cooperativa_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();


        public Resultado insertar_cooperativa(int id_persona_rol_admin, string nombre, string direccion, string telefono,
            double lat, double lng, bool activo, int created_by)
        {
            Consulta consulta = new Consulta("[proc_insertar_cooperativa] @id_persona_rol_admin, @nombre, @direccion, @telefono, " +
            "@lat, @lng, @activo, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@id_persona_rol_admin", id_persona_rol_admin));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@direccion", direccion));
            consulta.AgregarParametro(db.CrearParametro("@telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@lat", lat));
            consulta.AgregarParametro(db.CrearParametro("@lng", lng));
            consulta.AgregarParametro(db.CrearParametro("@activo", activo));
            consulta.AgregarParametro(db.CrearParametro("@created_by", created_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado actualizar_cooperativa(int id_cooperativa, string nombre, string direccion, string telefono,
           double lat, double lng, bool activo, int? modified_by)
        {
            Consulta consulta = new Consulta("[proc_actualizar_cooperativa] @id_cooperativa, @nombre, @direccion, @telefono, " +
            "@lat, @lng, @activo, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@direccion", direccion));
            consulta.AgregarParametro(db.CrearParametro("@telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@lat", lat));
            consulta.AgregarParametro(db.CrearParametro("@lng", lng));
            consulta.AgregarParametro(db.CrearParametro("@activo", activo));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modified_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado eliminar_cooperativa(int id_cooperativa, int? deleted_by)
        {
            Consulta consulta = new Consulta("[proc_eliminar_cooperativa] @id_cooperativa, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deleted_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public List<ObtenerCooperativa> listar_cooperativas(string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_listar_cooperativas] @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<ObtenerCooperativa>(consulta);
        }

        public ObtenerCooperativa obtener_cooperativa(int id)
        {
            Consulta consulta = new Consulta("[proc_obtener_cooperativa] @id_cooperativa");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id));
            return db.EjecutarFilaUnica<ObtenerCooperativa>(consulta);
        }
    }
}
