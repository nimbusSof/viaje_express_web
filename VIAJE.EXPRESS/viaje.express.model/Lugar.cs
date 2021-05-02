using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
    [Tabla("lugar")]
    public class Lugar
    {
        [Columna("lugar_id")]
        public int IdLugar { get; set; }

        [Columna("cooperativa_id")]
        public Nullable<int> CooperativaId { get; set; }

        [Columna("lugar_latitud")]
        public Double LugarLatitud { get; set; }

        [Columna("lugar_longitud")]
        public Double LugarLongitud { get; set; }

        [Columna("lugar_nombre")]
        public String LugarNombre { get; set; }

        [Columna("created_at")]
        public DateTime CreatedAt { get; set; }

        [Columna("created_by")]
        public int CreatedBy { get; set; }

        [Columna("modified_at")]
        public Nullable<DateTime> ModifiedAt { get; set; }

        [Columna("modified_by")]
        public Nullable<int> ModifiedBy { get; set; }

        [Columna("deleted_at")]
        public Nullable<DateTime> DeletedAt { get; set; }

        [Columna("deleted_by")]
        public Nullable<int> DeletedBy { get; set; }



    }

}



