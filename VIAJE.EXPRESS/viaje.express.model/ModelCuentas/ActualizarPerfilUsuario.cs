using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCuentas
{
    public class ActualizarPerfilUsuario: PerfilUsuario
    {
        [Columna("modified_by")]
        public int modified_by { get; set; }
    }
}
