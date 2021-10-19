using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelDestinoFavorito
{
    public class ModelDestinoFavoritoObtener
    {
        [Columna("id_destino")]
        public int id_destino { get; set; }

        [Columna("id_persona_rol")]
        public int id_persona_rol { get; set; }

        [Columna("destino_lat")]
        public string destino_lat { get; set; }

        [Columna("destino_lon")]
        public string destino_lon { get; set; }

        [Columna("nombre_destino")]
        public string nombre_destino { get; set; }

        [Columna("nombre_personalizado")]
        public string nombre_personalizado { get; set; }


        [Columna("created_by")]
        public int created_by { get; set; }


        [Columna("created_at")]
        public DateTime created_at { get; set; }


        [Columna("modified_by")]
        public int modified_by { get; set; }


        [Columna("modified_at")]
        public DateTime modified_at { get; set; }
    }
}

