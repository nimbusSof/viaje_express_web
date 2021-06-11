using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCuentas.CuentaUsuarioChofer
{
    public class ActualizarEstadoVehiculo
    {
        [Columna("id_estado_vehiculo")]
        public int id_estado_vehiculo { get; set; }
    }
}
