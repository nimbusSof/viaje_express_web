using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelEstadoSolicitud;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.data.DataEstadoSolicitud
{
    public class EstadoSolicitud_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public List<ObtenerEstadoSolicitud> getEstadoSolicitud()
        {
            Consulta consulta = new Consulta("[proc_listar_estado_solicitud]");
            return db.EjecutarConsulta<ObtenerEstadoSolicitud>(consulta);
        }
    }
}
