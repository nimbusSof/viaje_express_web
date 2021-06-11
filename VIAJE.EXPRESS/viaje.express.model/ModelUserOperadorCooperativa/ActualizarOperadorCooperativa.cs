using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelUsuario;

namespace viaje.express.model.ModelUserOperadorCooperativa
{
    public class ActualizarOperadorCooperativa: ActualizarUsuarioCooperativa
    {
        [Columna("id_persona_rol_ejecucion")]
        public int id_persona_rol_ejecucion { get; set; }

        [Columna("activo")]
        public bool activo { get; set; }

        [Columna("modulos")]
        public List<int> modulos { get; set; }

        [Columna("modified_by")]
        public int modified_by { get; set; }
    }
}
