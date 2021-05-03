using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model
{
    public class Listar
    {
        [Columna("columna")]
        public string columna { get; set; }

        [Columna("nombre")]
        public string nombre { get; set; }

        [Columna("offset")]
        public int offset { get; set; }

        [Columna("limit")]
        public int limit { get; set; }

        [Columna("sort")]
        public string sort { get; set; }
    }
}
