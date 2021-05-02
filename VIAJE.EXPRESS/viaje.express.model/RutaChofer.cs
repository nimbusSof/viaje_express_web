using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
    [Tabla("ruta_chofer")]
    public class RutaChofer
    {
        [Columna("ruta_chofer_id")]
        public int RutaChoferId { get; set; }


        [Columna("cooperativa_id")]
        public int CooperativaId { get; set; }

        [Columna("chofer_id")]
        public int ChoferId { get; set; }


        [Columna("ruta_id")]
        public int RutaId { get; set; }


        [Columna("created_at")]
        public int CreatedAt { get; set; }

        [Columna("created_by")]
        public int CreatedBy { get; set; }

        [Columna("modified_at")]
        public int ModifiedAt { get; set; }

        [Columna("modified_by")]
        public int ModifiedBy { get; set; }

        [Columna("deleted_at")]
        public int DeletedAt { get; set; }

        [Columna("deleted_by")]
        public int DeletedBy { get; set; }
    }
}
