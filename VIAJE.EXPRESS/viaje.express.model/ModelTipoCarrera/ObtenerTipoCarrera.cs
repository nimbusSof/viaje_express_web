using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelTipoCarrera
{
    public class ObtenerTipoCarrera
    {
        [Columna("id_tipo_carrera")]
        public int id_tipo_carrera { get; set; }

        [Columna("descripcion")]
        public string descripcion { get; set; }
    }
}
