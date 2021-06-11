using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model.ModelCooperativa
{
    public class Cooperativa
    {

        public int id_cooperativa { get; set; }

        public int id_persona_rol_admin { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }

 
        public string telefono { get; set; }

        public double lat { get; set; }

        public double lng { get; set; }

        public bool activo { get; set; }

        public int Created_by { get; set; }

        public Nullable<int> Modified_by { get; set; }

        public Nullable<int> Deleted_by { get; set; }

    }
}
