using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model
{
    public class ParametrosLogin
    {
        [Columna("correo")]
        public string correo { get; set; }

        [Columna("clave")]
        public string clave { get; set; }
    }
}
