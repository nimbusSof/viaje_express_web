using Nimbussoft.BaseDeDatos;
using System.Collections.Generic;
using viaje.express.model;

namespace viaje.express.data
{
	public class CooperativaBd
	{
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Cooperativa_old Insertar(int? personaRolID, string nombre, string direccion, string telefono, int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Cooperativa] @persona_rol_id, @cooperativa_nombre, @cooperativa_direccion, @cooperativa_telefono, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@persona_rol_id", personaRolID));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_direccion", direccion));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));
            return db.EjecutarFilaUnica<Cooperativa_old>(consulta);
        }

        public Resultado Modificar(int id, int? personaRolID, string nombre, string direccion, string telefono, int? modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Cooperativa] @id, @persona_rol_id, @cooperativa_nombre, @cooperativa_direccion, @cooperativa_telefono, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@persona_rol_id", personaRolID));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_direccion", direccion));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_telefono", telefono));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Cooperativa] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Cooperativa_old Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Cooperativa] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarFilaUnica<Cooperativa_old>(consulta);
        }
        public Cooperativa_old Obtener_Usuario(int id_persona, string aux)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Cooperativa_Usuario] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id_persona));
            return db.EjecutarFilaUnica<Cooperativa_old>(consulta);
        }

        public List<Cooperativa_old> Listar(string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[Listar_Cooperativa] @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<Cooperativa_old>(consulta);
        }
    }
}
