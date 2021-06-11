using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelTipoCarrera;
using Nimbussoft.BaseDeDatos;


namespace viaje.express.data.DataTipoCarrera
{
    public class TipoCarrera_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public List<ObtenerTipoCarrera> getTipoCarrera()
        {
            Consulta consulta = new Consulta("[proc_listar_tipo_carrera]");
            return db.EjecutarConsulta<ObtenerTipoCarrera>(consulta);
        }
    }
}
