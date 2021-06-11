using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelAgendarSolicitudCliente
{
    public class Cliente_ObtenerCarreraProgramadaCompartida
    {
        [Columna("id_agendar_solicitud_cliente")]
        public int id_agendar_solicitud_cliente { get; set; }

        [Columna("incluido")]
        public bool incluido { get; set; }

        [Columna("cedula_chofer")]
        public string cedula_chofer { get; set; }

        [Columna("apellido_chofer")]
        public string apellido_chofer { get; set; }

        [Columna("nombre_chofer")]
        public string nombre_chofer { get; set; }

        [Columna("genero")]
        public string genero { get; set; }

        [Columna("id_vehiculo")]
        public int id_vehiculo { get; set; }

        [Columna("placa")]
        public string placa { get; set; }
     
        [Columna("nro_pasajeros")]
        public int nro_pasajeros { get; set; }

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
    }
}
