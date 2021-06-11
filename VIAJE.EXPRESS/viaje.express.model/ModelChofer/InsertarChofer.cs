using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelChofer
{
    public class InsertarChofer
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

        [Columna("id_vehiculo")]
        public int id_vehiculo { get; set; }

        [Columna("puntos_licencia")]
        public int puntos_licencia { get; set; }

        [Columna("created_by")]
        public int created_by { get; set; }
    }
}
