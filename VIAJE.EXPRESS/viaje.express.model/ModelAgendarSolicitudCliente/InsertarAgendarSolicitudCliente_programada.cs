using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelAgendarSolicitudCliente
{
    public class InsertarAgendarSolicitudCliente_programada
    {
        [Columna("id_persona_rol")]
        public int id_persona_rol { get; set; }

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

        [Columna("id_tipo_carrera")]
        public int id_tipo_carrera { get; set; }

        [Columna("id_tipo_solicitud")]
        public int id_tipo_solicitud { get; set; }

        [Columna("created_by")]
        public int created_by { get; set; }

    }
}
