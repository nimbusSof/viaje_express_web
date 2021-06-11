using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelVehiculo
{
    public class InsertarVehiculo
    {
        [Columna("id_cooperativa")]
        public int id_cooperativa { get; set; }

        [Columna("placa")]
        public string placa { get; set; }

        [Columna("matricula")]
        public string matricula { get; set; }

        [Columna("color")]
        public string color { get; set; }

        [Columna("created_by")]
        public int created_by { get; set; }
    }
}
