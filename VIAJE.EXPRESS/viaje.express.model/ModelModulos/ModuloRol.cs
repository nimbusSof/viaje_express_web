using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelModulos
{
    public class ModuloRol
    {
        [Columna("id_modulo")]
        public int id_modulo { get; set; }

        [Columna("descripcion")]
        public string descripcion_modulo { get; set; }

        [Columna("ruta")]
        public string ruta { get; set; }
    }
}
