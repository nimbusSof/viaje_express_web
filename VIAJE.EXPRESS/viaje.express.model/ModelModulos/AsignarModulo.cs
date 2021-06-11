using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelModulos
{
    public class AsignarModulo
    {
        [Columna("id_modulo")]
        public int id_modulo { get; set; }
        [Columna("nombre_modulo")]
        public string nombre_modulo { get; set; }
    }
}
