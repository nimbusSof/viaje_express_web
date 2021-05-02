using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
    public class SolicitudClienteBd
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();


        public List<SolicitudCliente> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Solicitud_Cliente] ");

            return db.EjecutarConsulta<SolicitudCliente>(consulta);
        }



       


        public SolicitudCliente Insertar(int personaRolId, int tipoSolicitudId, string solicitudClienteSalida, string solicitudClienteDestino,int estadoSolicitudId, int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Solicitud_Cliente] @persona_rol_id ,@tipo_solicitud_id,@solicitud_cliente_salida, @solicitud_cliente_destino ,@estado_solicitud_id, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@persona_rol_id", personaRolId));
            consulta.AgregarParametro(db.CrearParametro("@tipo_solicitud_id", tipoSolicitudId));
            consulta.AgregarParametro(db.CrearParametro("@solicitud_cliente_salida", solicitudClienteSalida));
            consulta.AgregarParametro(db.CrearParametro("@solicitud_cliente_destino", solicitudClienteDestino));
            consulta.AgregarParametro(db.CrearParametro("@estado_solicitud_id", estadoSolicitudId));

            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));
            return db.EjecutarFilaUnica<SolicitudCliente>(consulta);

        }

        public Resultado Modificar(int id, int personaRolId, int tipoSolicitudId, string solicitudClienteSalida, string solicitudClienteDestino, int estadoSolicitudId, int? modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Solicitud_Cliente]   @id, @persona_rol_id,@tipo_solicitud_id, @solicitud_cliente_salida, @solicitud_cliente_destino, @estado_solicitud_id, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id",id));

            consulta.AgregarParametro(db.CrearParametro("@persona_rol_id", personaRolId));
            consulta.AgregarParametro(db.CrearParametro("@tipo_solicitud_id", tipoSolicitudId));
            consulta.AgregarParametro(db.CrearParametro("@solicitud_cliente_salida", solicitudClienteSalida));
            consulta.AgregarParametro(db.CrearParametro("@solicitud_cliente_destino", solicitudClienteDestino));
            consulta.AgregarParametro(db.CrearParametro("@estado_solicitud_id", estadoSolicitudId));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }


        public List<SolicitudCliente> Obtener(int solicitudClienteId)
        {
            Consulta consulta = new Consulta("[Obtener_Solicitud_Cliente] @id");
            consulta.AgregarParametro(db.CrearParametro("@id", solicitudClienteId));
            return db.EjecutarConsulta<SolicitudCliente>(consulta);
        }

        
        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Solicitud_Cliente] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }
    }

}
