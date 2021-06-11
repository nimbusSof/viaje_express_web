using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelEstadoVehiculo
{
    public class ObtenerEstadoVehiculo
    {
        [Columna("id_estado_vehiculo")]
        public int id_estado_vehiculo { get; set; }

        [Columna("descripcion")]
        public string descripcion { get; set; }
    }
}
