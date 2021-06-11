using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCarreraEjecucion
{
    public class ObtenerCarreraEjecucion
    {
        [Columna("id_carrera_ejecucion")]
        public int id_carrera_ejecucion { get; set; }

        [Columna("descripcion")]
        public string descripcion { get; set; }
    }
}
