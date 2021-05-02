using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
    public class Rol
    {
        public Rol(){}

        [Columna("rol_id")]
        public int idRol { get; set; }

        [Columna("rol_descripcion")]
        public string descrpcionRol { get; set; }
    }
}
