using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;


namespace viaje.express.data
{

   public class PersonaRolBd
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public List<PersonaRol> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Persona_Rol] ");
            return db.EjecutarConsulta<PersonaRol>(consulta);
        }

        public PersonaRol Insertar(
            int personaId, int rolId, 
            int estadoPersonaId, 
            int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Persona_Rol] @persona_id, @rol_id, @estado_persona_id, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@persona_id", personaId));
            consulta.AgregarParametro(db.CrearParametro("@rol_id", rolId));
            consulta.AgregarParametro(db.CrearParametro("@estado_persona_id", estadoPersonaId));
            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));
            return db.EjecutarFilaUnica<PersonaRol>(consulta);
        }

        public PersonaRol Modificar(int id,
            int personaId, int rolId,
            int estadoPersonaId,
            int modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Persona_Rol] @id, @persona_id, @rol_id," +
                "@estado_persona_id, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@persona_id", personaId));
            consulta.AgregarParametro(db.CrearParametro("@rol_id", rolId));
            consulta.AgregarParametro(db.CrearParametro("@estado_persona_id", estadoPersonaId));
            consulta.AgregarParametro(db.CrearParametro("@modified_by",modifiedBy));
            return db.EjecutarFilaUnica<PersonaRol>(consulta);
        }


        public PersonaRol Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Persona_Rol] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarFilaUnica<PersonaRol>(consulta);
        }

        public PersonaRol ObtenerPorPersonaRol(int personaId, int rolId)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_PersonaRolChofer]  @persona_id, @rol_id");
            consulta.AgregarParametro(db.CrearParametro("@persona_id", personaId));
            consulta.AgregarParametro(db.CrearParametro("@rol_id", rolId));

            return db.EjecutarFilaUnica<PersonaRol>(consulta);
        }














    }
}
