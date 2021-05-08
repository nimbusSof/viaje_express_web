using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCooperativa
{
    public class Cooperativa
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

        [Columna("activo")]
        public bool activo { get; set; }

        [Columna("created_by")]
        public int Created_by { get; set; }

        [Columna("modified_by")]
        public Nullable<int> Modified_by { get; set; }

        [Columna("deleted_by")]
        public Nullable<int> Deleted_by { get; set; }

    }
}
