using System;
using System.Collections.Generic;
using System.Text;

using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelVehiculo;
using viaje.express.model;


namespace viaje.express.data.DataVehiculo
{
    public class Vehiculo_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public Resultado insertar_vehiculo(int id_cooperativa, string placa, string matricula, string color, int created_by)
        {
            Consulta consulta = new Consulta("[proc_insertar_vehiculo] @id_cooperativa, @placa, @matricula, @color, @created_by");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@placa", placa));
            consulta.AgregarParametro(db.CrearParametro("@matricula", matricula));
            consulta.AgregarParametro(db.CrearParametro("@color", color));
            consulta.AgregarParametro(db.CrearParametro("@created_by", created_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado actualizar_vehiculo(int id_vehiculo, string matricula, string color, bool activo, int modified_by)
        {
            Consulta consulta = new Consulta("[proc_actualizar_vehiculo] @id_vehiculo, @matricula, @color, @activo, @modified_by");
            consulta.AgregarParametro(db.CrearParametro("@id_vehiculo", id_vehiculo));
            consulta.AgregarParametro(db.CrearParametro("@matricula", matricula));
            consulta.AgregarParametro(db.CrearParametro("@color", color));
            consulta.AgregarParametro(db.CrearParametro("@activo", activo));
            consulta.AgregarParametro(db.CrearParametro("@modified_by", modified_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public Resultado eliminar_veiculo(int id_vehiculo, int deleted_by)
        {
            Consulta consulta = new Consulta("[proc_eliminar_vehiculo] @id_vehiculo, @deleted_by");
            consulta.AgregarParametro(db.CrearParametro("@id_vehiculo", id_vehiculo));
            consulta.AgregarParametro(db.CrearParametro("@deleted_by", deleted_by));

            return db.EjecutarFilaUnica<Resultado>(consulta);
        }

        public List<ObtenerVehiculo> listar_vehiculo(int id_cooperativa, string columna = null, string nombre = null, int offset = 0, int limit = 100, string sort = "")
        {
            Consulta consulta = new Consulta("[proc_listar_vehiculos] @id_cooperativa, @columna, @nombre, @offset, @limit, @sort");
            consulta.AgregarParametro(db.CrearParametro("@id_cooperativa", id_cooperativa));
            consulta.AgregarParametro(db.CrearParametro("@columna", columna));
            consulta.AgregarParametro(db.CrearParametro("@nombre", nombre));
            consulta.AgregarParametro(db.CrearParametro("@offset", offset));
            consulta.AgregarParametro(db.CrearParametro("@limit", limit));
            consulta.AgregarParametro(db.CrearParametro("@sort", sort));

            return db.EjecutarConsulta<ObtenerVehiculo>(consulta);
        }

        public ObtenerVehiculo obtener_vehiculo(int id_vehiculo)
        {
            Consulta consulta = new Consulta("[proc_obtener_vehiculo] @id_vehiculo");
            consulta.AgregarParametro(db.CrearParametro("@id_vehiculo", id_vehiculo));
            return db.EjecutarFilaUnica<ObtenerVehiculo>(consulta);
        }
    }
}
