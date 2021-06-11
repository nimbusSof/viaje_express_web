using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCuentas
{
    public class ObtenerPerfilUsuario : PerfilUsuario
    {
        [Columna("cedula")]
        public string cedula { get; set; }

        [Columna("rol")]
        public string rol { get; set; }

        [Columna("calificacion")]
        public double calificacion { get; set; }
    }
}
