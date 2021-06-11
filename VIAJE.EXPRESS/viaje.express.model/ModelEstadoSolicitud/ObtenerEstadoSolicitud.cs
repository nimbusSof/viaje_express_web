using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelEstadoSolicitud
{
    public class ObtenerEstadoSolicitud
    {
        [Columna("id_estado_solicitud")]
        public int id_estado_solicitud { get; set; }

        [Columna("descripcion")]
        public string descripcion { get; set; }
    }
}
