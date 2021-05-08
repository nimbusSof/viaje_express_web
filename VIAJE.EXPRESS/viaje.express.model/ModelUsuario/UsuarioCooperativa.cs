using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelUsuario
{
    public class UsuarioCooperativa
    {
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

        [Columna("id_cooperativa")]
        public int id_cooperativa { get; set; }

        [Columna("id_persona_rol_ejecucion")]
        public int id_persona_rol_ejecucion { get; set; }

        [Columna("id_modulo")]
        public int id_modulo { get; set; }


        [Columna("created_by")]
        public int Created_by { get; set; }

        [Columna("modified_by")]
        public Nullable<int> Modified_by { get; set; }

    }
}
