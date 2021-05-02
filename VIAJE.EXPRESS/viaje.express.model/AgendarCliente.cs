using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
    [Tabla("agendar_cliente") ]
    public class AgendarCliente
    {
        [Columna("agendar_cliente_id")]
        public int AgendarClienteId { get; set; }

        [Columna("persona_rol_id")]
        public int PersonaRolId { get; set; }

        [Columna("agendar_cliente_fecha")]
        public DateTime AgendarClienteFecha { get; set; }

        [Columna("agendar_cliente_hora")]
        public TimeSpan AgendarClienteHora { get; set; }

        [Columna("agendar_cliente_salida")]
        public string AgendarClienteSalida { get; set; }

        [Columna("agendar_cliente_destinoe")]
        public string AgendarClienteDestinoe { get; set; }

        [Columna("estado_solicitud_id")]
        public int EstadoSolicitudId { get; set; }

        [Columna("created_at")]
        public DateTime CreatedAt { get; set; }

        [Columna("created_by")]
        public int CreatedBy { get; set; }


        [Columna("modified_at")]
        public Nullable<DateTime> ModifiedAt { get; set; }

        [Columna("modified_by")]
        public Nullable<int> ModifiedBy { get; set; }

        [Columna("deleted_at")]
        public Nullable<DateTime> DeletedAt { get; set; }

        [Columna("deleted_by")]
        public Nullable<int> DeletedBy { get; set; }
    }
}
