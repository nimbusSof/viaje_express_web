using Newtonsoft.Json;
using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using viaje.express.model;

namespace viaje.express.data
{
    public class RutaBd
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Ruta Insertar(int cooperativaId,int salidaId,int destinoId, string rutaFecha, TimeSpan rutaHora, double rutaMonto, int createdBy)
        {
            Consulta consulta = new Consulta("[dbo].[Insertar_Ruta] @cooperativa_id, @salida_id, @destino_id, @ruta_fecha ,@ruta_hora, @ruta_monto, @created_by");

            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@salida_id", salidaId));
            consulta.AgregarParametro(db.CrearParametro("@destino_id", destinoId));
            consulta.AgregarParametro(db.CrearParametro("@ruta_fecha", rutaFecha));
            consulta.AgregarParametro(db.CrearParametro("@ruta_hora", rutaHora));
            consulta.AgregarParametro(db.CrearParametro("@ruta_monto", rutaMonto));
            consulta.AgregarParametro(db.CrearParametro("@created_by", createdBy));

            return db.EjecutarFilaUnica<Ruta>(consulta);
        }

        public Resultado Modificar(int id, int cooperativaId, int salidaId, int destinoId, string rutaFecha, TimeSpan rutaHora, double rutaMonto, int modifiedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Modificar_Ruta] @id, @cooperativa_id, @salida_id, @destino_id, @ruta_fecha,@ruta_hora, @ruta_monto, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@cooperativa_id", cooperativaId));
            consulta.AgregarParametro(db.CrearParametro("@salida_id", salidaId));
            consulta.AgregarParametro(db.CrearParametro("@destino_id", destinoId));
            consulta.AgregarParametro(db.CrearParametro("@ruta_fecha", rutaFecha));
            consulta.AgregarParametro(db.CrearParametro("@ruta_hora", rutaHora));
            consulta.AgregarParametro(db.CrearParametro("@ruta_monto", rutaMonto));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modifiedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado Eliminar(int id, int deletedBy)
        {
            Consulta consulta = new Consulta("[dbo].[Eliminar_Ruta] @id, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id", id));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deletedBy));
            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Ruta Obtener(int id)
        {
            Consulta consulta = new Consulta("[dbo].[Obtener_Insertar_Ruta] @ruta_id");
            consulta.AgregarParametro(db.CrearParametro("@ruta_id", id));
            return db.EjecutarFilaUnica<Ruta>(consulta);
        }
      

        public List<Ruta> Listar()
        {
            Consulta consulta = new Consulta("[Listar_Ruta]");


            return db.EjecutarConsulta<Ruta>(consulta);
        }
    }
}


