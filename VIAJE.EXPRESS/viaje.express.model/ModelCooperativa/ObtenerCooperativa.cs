using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCooperativa
{
    public class ObtenerCooperativa
    {
        [Columna("id_cooperativa")]
        public int id_cooperativa { get; set; }

        [Columna("id_persona_rol_admin")]
        public int id_persona_rol_admin { get; set; }

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

        [Columna("administradores")]
        public int administradores { get; set; }

        [Columna("activo")]
        public bool activo { get; set; }
    }
}
