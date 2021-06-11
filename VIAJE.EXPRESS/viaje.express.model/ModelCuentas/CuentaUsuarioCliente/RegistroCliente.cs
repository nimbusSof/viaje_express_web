using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelCuentas.CuentaUsuarioCliente
{
    public class RegistroCliente: PerfilUsuario
    {
        [Columna("cedula")]
        public string cedula { get; set; }
    }
}
