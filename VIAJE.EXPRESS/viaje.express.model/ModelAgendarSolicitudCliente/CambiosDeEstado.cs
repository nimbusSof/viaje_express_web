using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelAgendarSolicitudCliente
{
    public class CambiosDeEstado
    {
        [Columna("id_agendar_solicitud_cliente")]
        public int id_agendar_solicitud_cliente { get; set; }
    }
}
