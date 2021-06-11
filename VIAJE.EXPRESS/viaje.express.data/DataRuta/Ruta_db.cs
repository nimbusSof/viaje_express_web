using System;
using System.Collections.Generic;
using System.Text;

using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelRuta;
using viaje.express.model;

namespace viaje.express.data.DataRuta
{
    public class Ruta_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado insertar_ruta(int id_cooperativa, string nombre_ruta, double origen_lat, double origen_lng, double destino_lat, double destino_lng, 
            double distancia, double tiempo, double monto, int created_by)
        {
            Consulta consulta = new Consulta("[proc_insertar_ruta] @id_cooperativa, @nombre_ruta, @origen_lat, @origen_lng, @destino_lat, @destino_lng, @distancia, " +
                    "@tiempo, @monto, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@nombre_ruta", nombre_ruta));
            consulta.AgregarParametro(db.CrearParametro("@origen_lat", origen_lat));
            consulta.AgregarParametro(db.CrearParametro("@origen_lng", origen_lng));
            consulta.AgregarParametro(db.CrearParametro("@destino_lat", destino_lat));
            consulta.AgregarParametro(db.CrearParametro("@destino_lng", destino_lng));
            consulta.AgregarParametro(db.CrearParametro("@distancia", distancia));
            consulta.AgregarParametro(db.CrearParametro("@tiempo", tiempo));
            consulta.AgregarParametro(db.CrearParametro("@monto", monto));
            consulta.AgregarParametro(db.CrearParametro("@created_by", created_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado actualizar_ruta(int id_ruta, string nombre_ruta, double origen_lat, double origen_lng, double destino_lat, double destino_lng,
            double distancia, double tiempo, double monto, bool activo, int modified_by)
        {
            Consulta consulta = new Consulta("[proc_actualizar_ruta] @id_ruta, @nombre_ruta, @origen_lat, @origen_lng, @destino_lat, @destino_lng, @distancia, " +
                    "@tiempo, @monto, @activo, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id_ruta", id_ruta));
            consulta.AgregarParametro(db.CrearParametro("@nombre_ruta", nombre_ruta));
            consulta.AgregarParametro(db.CrearParametro("@origen_lat", origen_lat));
            consulta.AgregarParametro(db.CrearParametro("@origen_lng", origen_lng));
            consulta.AgregarParametro(db.CrearParametro("@destino_lat", destino_lat));
            consulta.AgregarParametro(db.CrearParametro("@destino_lng", destino_lng));
            consulta.AgregarParametro(db.CrearParametro("@distancia", distancia));
            consulta.AgregarParametro(db.CrearParametro("@tiempo", tiempo));
            consulta.AgregarParametro(db.CrearParametro("@monto", monto));
            consulta.AgregarParametro(db.CrearParametro("@activo", activo));       
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modified_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado eliminar_ruta(int id_ruta, int deleted_by)
        {
            Consulta consulta = new Consulta("[proc_eliminar_ruta] @id_ruta, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id_ruta", id_ruta));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deleted_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public List<ObtenerRuta> listar_rutas(int id_cooperativa, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_listar_rutas] @id_cooperativa, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<ObtenerRuta>(consulta);
        }

        public ObtenerRuta obtener_ruta(int id_ruta)
        {
            Consulta consulta = new Consulta("[proc_obtener_ruta] @id_ruta");
            consulta.AgregarParametro(db.CrearParametro("@id_ruta", id_ruta));
            return db.EjecutarFilaUnica<ObtenerRuta>(consulta);
        }
    }
}
