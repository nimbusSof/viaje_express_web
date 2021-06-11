using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelCarreraEjecucion;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.data.DataCarreraEjecucion
{
    public class CarreraEjecucion_db
    {
        internal BaseDeDatos db = BaseDeDatos.GetConection();

        public List<ObtenerCarreraEjecucion> getCarreraEjecucion()
        {
            Consulta consulta = new Consulta("[proc_listar_carrera_ejecucion]");
            return db.EjecutarConsulta<ObtenerCarreraEjecucion>(consulta);
        }
    }
}
