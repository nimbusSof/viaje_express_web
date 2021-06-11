using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCooperativa
{
    public class ActualizarCooperativa
    {
        [Columna("nombre")]
        public string nombre { get; set; }

        [Columna("direccion")]
        public string direccion { get; set; }

        [Columna("telefono")]
        public string telefono { get; set; }

        [Columna("lat")]
        public double lat { get; set; }

        [Columna("lng")]
        public double lng { get; set; }

        [Columna("activo")]
        public bool activo { get; set; }

        [Columna("modified_by")]
        public int modified_by { get; set; }
    }
}
