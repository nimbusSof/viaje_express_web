using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelUsuario;

namespace viaje.express.model.ModelChofer
{
    public class ActualizarChofer: ActualizarUsuarioCooperativa
    {
        [Columna("id_vehiculo")]
        public int id_vehiculo { get; set; }

        [Columna("puntos_licencia")]
        public int puntos_licencia { get; set; }

        [Columna("activo")]
        public bool activo { get; set; }

        [Columna("modified_by")]
        public int modified_by { get; set; }
    }
}
