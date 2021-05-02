using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
    public class RutaChoferBd
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public RutaChofer Insertar(int cooperativaId, int choferId , int rutaId ,int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Ruta_Chofer] @cooperativa_id, @chofer_id ,@ruta_id ,@created_by");

            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@chofer_id", choferId));
            consulta.AgregarParametro(db.CrearParametro("@ruta_id", rutaId));
            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));

            return db.EjecutarFilaUnica<RutaChofer>(consulta);
        }

        public Resultado Modificar(int id, int cooperativaId, int choferId, int rutaId,  int modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Ruta_Chofer] @id , @cooperativa_id , @chofer_id , @ruta_id  , @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@chofer_id", choferId));
            consulta.AgregarParametro(db.CrearParametro("@ruta_id", rutaId));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Ruta_Chofer] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public RutaChofer Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Insertar_Ruta_Chofer] @ruta_chofer_id");
            consulta.AgregarParametro(db.CrearParametro("@ruta_chofer_id", id));
            return db.EjecutarFilaUnica<RutaChofer>(consulta);
        }


        public List<RutaChofer> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Ruta_Chofer]");


            return db.EjecutarConsulta<RutaChofer>(consulta);
        }
    }
}

