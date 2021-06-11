using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelUsuario;

namespace viaje.express.model.ModelUserOperadorCooperativa
{
    public class InsertarOperadorCooperativa: InsertarUsuarioCooperativa
    {
        [Columna("id_cooperativa")]
        public int id_cooperativa { get; set; }

        [Columna("id_persona_rol_ejecucion")]
        public int id_persona_rol_ejecucion { get; set; }

        [Columna("modulos")]
        public List<int> modulos { get; set; }

        [Columna("created_by")]
        public int Created_by { get; set; }
    }
}
