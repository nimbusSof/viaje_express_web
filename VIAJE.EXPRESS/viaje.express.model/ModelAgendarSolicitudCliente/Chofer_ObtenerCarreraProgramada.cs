using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelAgendarSolicitudCliente
{
    public class Chofer_ObtenerCarreraProgramada
    {
        [Columna("id_agendar_solicitud_cliente")]
        public int id_agendar_solicitud_cliente { get; set; }

        [Columna("apellido_cliente")]
        public string apellido_cliente { get; set; }

        [Columna("nombre_cliente")]
        public string nombre_cliente { get; set; }

        [Columna("genero")]
        public string genero { get; set; }

        [Columna("origen_lat")]
        public double origen_lat { get; set; }

        [Columna("origen_lng")]
        public double origen_lng { get; set; }

        [Columna("destino_lat")]
        public double destino_lat { get; set; }

        [Columna("destino_lng")]
        public double destino_lng { get; set; }

        [Columna("fecha")]
        public DateTime fecha { get; set; }

        [Columna("hora")]
        public string hora { get; set; }

        [Columna("distancia")]
        public double distancia { get; set; }

        [Columna("tiempo")]
        public double tiempo { get; set; }

        [Columna("monto")]
        public double monto { get; set; }

        [Columna("tipo_solicitud")]
        public string tipo_solicitud { get; set; }

        [Columna("tipo_carrera")]
        public string tipo_carrera { get; set; }
    }
}
