using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
     public class ChoferBD
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();


        public List<Chofer> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Chofer] ");

            return db.EjecutarConsulta<Chofer>(consulta);
        }



        public List<ChoferNombre> Listar(int cooperativaId)
        {
            Consulta consulta = new Consulta("[Listar_NombreChofer] @cooperativa_id");
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            return db.EjecutarConsulta<ChoferNombre>(consulta);
        }


        public Chofer Insertar(int cooperativaId, int personaRolId, int vehiculoId,int estadoChoferId, int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Chofer] @cooperativa_id, @persona_rol_id, @vehiculo_id, @estado_chofer_id, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id",  cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@persona_rol_id", personaRolId));
            consulta.AgregarParametro(db.CrearParametro("@vehiculo_id", vehiculoId));
            consulta.AgregarParametro(db.CrearParametro("@estado_chofer_id", estadoChoferId));
            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));
            return db.EjecutarFilaUnica<Chofer>(consulta);



        }

        public Resultado Modificar(int id, int cooperativaId,int personaRolId, int vehiculoId, int estadoChoferId, int? modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Chofer]  @id, @cooperativa_id, @persona_rol_id, @vehiculo_id, @estado_chofer_id, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id",cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@persona_rol_id", personaRolId));
            consulta.AgregarParametro(db.CrearParametro("@vehiculo_id", vehiculoId));
            consulta.AgregarParametro(db.CrearParametro("@estado_chofer_id", estadoChoferId));

            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }


        public Chofer Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Chofer] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarFilaUnica<Chofer>(consulta);
        }

        public ChoferNombre Obtener(int cooperativaId,int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_NombreChofer]   @cooperativa_id, @id");
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));

            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarFilaUnica<ChoferNombre>(consulta);
        }
        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Chofer] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
    }

}
