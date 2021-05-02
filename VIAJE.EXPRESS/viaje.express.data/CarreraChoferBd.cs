using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
    public class CarreraChoferBd
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();


        public List<CarreraChofer> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Carrera_Chofer] ");

            return db.EjecutarConsulta<CarreraChofer>(consulta);
        }

        public CarreraChofer Insertar(int solicitudClienteId, int choferId , int cooperativaId , double carreraChoferMonto, int estadoSolicitud, int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Carrera_Chofer] @solicitud_cliente_id , @chofer_id ,@cooperativa_id , @carrera_chofer_monto, @estado_solicitud, @created_by ");
            consulta.AgregarParametro(db.CrearParametro("@solicitud_cliente_id", solicitudClienteId));
            consulta.AgregarParametro(db.CrearParametro("@chofer_id", choferId));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@carrera_chofer_monto", carreraChoferMonto));
            consulta.AgregarParametro(db.CrearParametro("@estado_solicitud", estadoSolicitud));
            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));
            return db.EjecutarFilaUnica<CarreraChofer>(consulta);



        }

        public Resultado Modificar(int id,int solicitudCliente, int choferId, int cooperativaId, double carreraChoferMonto, int estadoSolicitud, int? modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Carrera_Chofer]  @id, @solicitud_cliente , @chofer_id ,@cooperativa_id , @carrera_chofer_monto, @estado_solicitud, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@solicitud_cliente", solicitudCliente));
            consulta.AgregarParametro(db.CrearParametro("@chofer_id", choferId));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@carrera_chofer_monto", carreraChoferMonto));
            consulta.AgregarParametro(db.CrearParametro("@estado_solicitud", estadoSolicitud));

            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }


        public CarreraChofer Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Carrera_Chofer] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            return db.EjecutarFilaUnica<CarreraChofer>(consulta);
        }

        
        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Carrera_Chofer] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
    }

}