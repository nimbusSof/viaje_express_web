using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelCooperativa;

namespace viaje.express.model.ModelUsuario
{
    public class UsuarioAdministradorCooperativa
    {
        [Columna("id_persona_rol")]
        public int id_persona_rol { get; set; }

        [Columna("cedula")]
        public string cedula { get; set; }

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

        [Columna("path_foto")]
        public string path_foto { get; set; }

        [Columna("nombre_cooperativa")]
        public string nombre_cooperativa { get; set; }

    }
}
