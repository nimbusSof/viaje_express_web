using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
    [Tabla("ruta")]
    public class Ruta
    {

        [Columna("ruta_id")]
        public int RutaId { get; set; }
        
        [Columna("cooperativa_id")]
        public int CooperativaId { get; set; }

        [Columna("salida_id")]
        public int SalidaId { get; set; }

        [Columna("destino_id")]
        public int DestinoId { get; set; }

        [Columna("ruta_fecha")]
        public string RutaFecha { get; set; }

        [Columna("ruta_hora")]
        public TimeSpan RutaHora  { get; set; }
    

        [Columna("ruta_monto")]
        public double RutaMonto { get; set; }

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
