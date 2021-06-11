using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelVehiculo
{
    public class ActualizarVehiculo
    {
        [Columna("matricula")]
        public string matricula { get; set; }

        [Columna("color")]
        public string color { get; set; }

        [Columna("activo")]
        public bool activo { get; set; }

        [Columna("modified_by")]
        public int modified_by { get; set; }
    }
}
