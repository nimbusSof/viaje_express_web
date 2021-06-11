using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelTipoSolicitud;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.data.DataTipoSolicitud
{
    public class TipoSolicitud_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public List<ObtenerTipoSolicitud> getTipoSolicitud()
        {
            Consulta consulta = new Consulta("[proc_listar_tipo_solicitud]");
            return db.EjecutarConsulta<ObtenerTipoSolicitud>(consulta);
        }
    }
}
