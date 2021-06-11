using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelEstadoVehiculo;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.data.DataEstadoVehiculo
{
    public class EstadoVehiculo_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public List<ObtenerEstadoVehiculo> getEstadoVehiculo()
        {
            Consulta consulta = new Consulta("[proc_listar_estado_vehiculo]");
            return db.EjecutarConsulta<ObtenerEstadoVehiculo>(consulta);
        }
    }
}
