using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model
{
    public class SecurityViewModel
    {
        [Columna("token")]
        public string token { get; set; }
    }
}
