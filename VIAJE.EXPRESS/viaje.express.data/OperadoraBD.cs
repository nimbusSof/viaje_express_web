using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
    public class OperadoraBD
    {

        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Operadora Insertar(int cooperativaId, int personaRolId,  int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Operadora] @cooperativa_id, @persona_rol_id, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@persona_rol_id", personaRolId));

            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));
            return db.EjecutarFilaUnica<Operadora>(consulta);
        }

        public Resultado Modificar(int id, int? cooperativaId, int? personaRolId,  int? modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Operadora] @id, @cooperativa_id,  @persona_rol_id, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@persona_rol_id", personaRolId));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Operadora] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Operadora Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Operadora] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarFilaUnica<Operadora>(consulta);
        }


        public List<Operadora> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Operadora] ");

            return db.EjecutarConsulta<Operadora>(consulta);
        }

    }
}
