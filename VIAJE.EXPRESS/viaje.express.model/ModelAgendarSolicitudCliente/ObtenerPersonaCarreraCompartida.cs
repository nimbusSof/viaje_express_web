using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelAgendarSolicitudCliente
{
    public class ObtenerPersonaCarreraCompartida
    {
        [Columna("id_agendar_solicitud_cliente")]
        public int id_agendar_solicitud_cliente { get; set; }

        [Columna("cedula")]
        public string cedula { get; set; }

        [Columna("apellido")]
        public string apellido { get; set; }

        [Columna("nombre")]
        public string nombre { get; set; }

        [Columna("genero")]
        public string genero { get; set; }

        [Columna("correo")]
        public string correo { get; set; }
    }
}
