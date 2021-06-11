using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelVehiculo
{
    public class ObtenerVehiculo
    {
        [Columna("id_vehiculo")]
        public int id_vehiculo { get; set; }

        [Columna("id_cooperativa")]
        public int id_cooperativa { get; set; }

        [Columna("placa")]
        public string placa { get; set; }

        [Columna("matricula")]
        public string matricula { get; set; }

        [Columna("color")]
        public string color { get; set; }

        [Columna("estado_vehiculo")]
        public string estado_vehiculo { get; set; }

        [Columna("activo")]
        public bool activo { get; set; }
    }
}
