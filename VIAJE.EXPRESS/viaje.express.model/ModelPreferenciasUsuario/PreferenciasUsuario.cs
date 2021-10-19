using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.PreferenciasUsuario
{
    public class PreferenciasUsuario
    {
        [Columna("id_persona_rol")]
        public int id_persona_rol { get; set; }

        [Columna("idioma")]
        public string idioma { get; set; }

    }
}
