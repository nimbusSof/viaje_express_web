using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelUsuario;


namespace viaje.express.model.ModelUserAdministradorCooperativa
{
    public class ActualizarAdministradorCooperativa: ActualizarUsuarioCooperativa
    {
        [Columna("id_cooperativa")]
        public int id_cooperativa { get; set; }

        [Columna("activo")]
        public bool activo { get; set; }

        [Columna("modified_by")]
        public int modified_by { get; set; }
    }
}
