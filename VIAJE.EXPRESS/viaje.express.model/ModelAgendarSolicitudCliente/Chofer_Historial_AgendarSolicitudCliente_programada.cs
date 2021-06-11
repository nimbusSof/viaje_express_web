using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelAgendarSolicitudCliente
{
    public class Chofer_Historial_AgendarSolicitudCliente_programada
    {
        [Columna("id_agendar_solicitud_cliente")]
        public int id_agendar_solicitud_cliente { get; set; }

        [Columna("id_vehiculo")]
        public int id_vehiculo { get; set; }

        [Columna("placa")]
        public string placa { get; set; }

        [Columna("nro_pasajeros")]
        public int nro_pasajeros { get; set; }

        [Columna("cedula_cliente")]
        public string cedula_cliente { get; set; }

        [Columna("apellido_cliente")]
        public string apellido_cliente { get; set; }

        [Columna("nombre_cliente")]
        public string nombre_cliente { get; set; }

        [Columna("fecha_solicitud")]
        public DateTime fecha_solicitud { get; set; }

        [Columna("hora_solicitud")]
        public string hora_solicitud { get; set; }

        [Columna("distancia")]
        public double distancia { get; set; }

        [Columna("tiempo")]
        public double tiempo { get; set; }

        [Columna("monto")]
        public double monto { get; set; }

        [Columna("tipo_carrera")]
        public string tipo_carrera { get; set; }

        [Columna("tipo_solicitud")]
        public string tipo_solicitud { get; set; }

        [Columna("fecha_creacion")]
        public string fecha_creacion { get; set; }
    }
}
