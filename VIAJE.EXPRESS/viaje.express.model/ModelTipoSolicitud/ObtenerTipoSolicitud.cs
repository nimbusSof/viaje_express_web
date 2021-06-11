using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelTipoSolicitud
{
    public class ObtenerTipoSolicitud
    {
        [Columna("id_tipo_solicitud")]
        public int id_tipo_solicitud { get; set; }

        [Columna("descripcion")]
        public string descripcion { get; set; }
    }
}
