using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;

namespace viaje.express.data
{
    public class Prueba_bd
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public List<Prueba_v1> Listar()
        {
            //Consulta consulta = new Consulta("[get_prueba3] ");
            Consulta consulta = new Consulta("[proc_get_prueba] ");

            return db.EjecutarConsulta<Prueba_v1>(consulta);
        }

        public Prueba_v1 Insertar_Prueba(DateTime fecha, string hora, double distancia, double lat, double lng, double monto)
        {
            // proc_prueb_v1 '12-10-1998', '10:44:09 AM', 5.6, 0.040822, -78.143256, 156.2
            //Consulta consulta = new Consulta("[dbo].[proc_prueb_v1] @fecha, @hora, @distancia, @lat, @lng, @monto");
            Consulta consulta = new Consulta("[dbo].[proc_prueb_v2] @fecha, @hora, @distancia, @lat, @lng, @monto");
            consulta.AgregarParametro(db.CrearParametro("@fecha", fecha));
            //consulta.AgregarParametro(db.CrearParametro("@hora", hora.ToString("hh:mm:ss tt")));
            consulta.AgregarParametro(db.CrearParametro("@hora", hora));
            consulta.AgregarParametro(db.CrearParametro("@distancia", distancia));
            consulta.AgregarParametro(db.CrearParametro("@lat", lat));
            consulta.AgregarParametro(db.CrearParametro("@lng", lng));
            consulta.AgregarParametro(db.CrearParametro("@monto", monto));
            return db.EjecutarFilaUnica<Prueba_v1>(consulta);
        }
    }
}
