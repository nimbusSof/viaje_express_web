using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
    [Tabla("persona_rol")]

       public class PersonaRol
    {
        [Columna("persona_rol_id")]
        public int PersonaRolId { get; set; }
        [Columna("persona_id")]
        public int PersonaId { get; set; }

        [Columna("rol_id")]
        public int RolId { get; set; }

        [Columna("estado_persona_id")]
        public int EstadoPersonaId { get; set; }

        [Columna("created_at")]
        public int CreatedAt{ get; set; }

        [Columna("created_by")]
        public int CreatedBy { get; set; }

        [Columna("modified_at")]
        public int ModifiedAt { get; set; }

        [Columna("modified_by")]
        public int ModifiedBy { get; set; }

        [Columna("deleted_at")]
        public int DeletedAt { get; set; }

        [Columna("deleted_by")]
        public int DeletedBy { get; set; }
    }
}
