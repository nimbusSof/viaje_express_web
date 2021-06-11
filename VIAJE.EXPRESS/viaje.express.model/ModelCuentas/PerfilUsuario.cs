using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCuentas
{
    public class PerfilUsuario
    {
        [Columna("nombre")]
        public string nombre { get; set; }

        [Columna("apellido")]
        public string apellido { get; set; }

        [Columna("fecha_nacimiento")]
        public DateTime fecha_nacimiento { get; set; }

        [Columna("genero")]
        public string genero { get; set; }

        [Columna("telefono")]
        public string telefono { get; set; }

        [Columna("correo")]
        public string correo { get; set; }

        [Columna("clave")]
        public string clave { get; set; }

        [Columna("path_foto")]
        public string path_foto { get; set; }
    }
}
