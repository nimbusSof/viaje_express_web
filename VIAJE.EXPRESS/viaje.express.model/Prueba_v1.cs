using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
    [Tabla("prueba3")]
    public class Prueba_v1
    {
        [Columna("id_prueba")]
        public int id_prueba { get; set; }

        [Columna("fecha")]
        public  DateTime fecha { get; set; }
 
        [Columna("hora")]   
        public string hora { get; set; }
        //public DateTime hora { get; set; }


        // db -> float --> double
        [Columna("distancia")]
        public double distancia { get; set; }

        [Columna("lat")]
        public double lat { get; set; }

        [Columna("lng")]
        public double lng { get; set; }

        [Columna("monto")]
        public double monto { get; set; }
    }
}
