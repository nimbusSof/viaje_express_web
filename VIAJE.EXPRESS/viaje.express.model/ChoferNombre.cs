using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
    public class ChoferNombre
    {
        [Columna("chofer_id")]
        public int ChoferId { get; set; }
        [Columna("persona_nombre")]
        public string PersonaNombre{ get; set; }

        [Columna("persona_apellidos")]
        public string PersonaApellidos{ get; set; }

        [Columna("cooperativa_nombre")]
        public string CooperativaNombre { get; set; }

        [Columna("vehiculo_id")]
        public int VehiculoId { get; set; }

        [Columna("estado_chofer_id")]
        public int EstadoChoferId { get; set; }

    }
}
