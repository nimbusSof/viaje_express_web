using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelDestinoFavorito
{
    public class ModelDestinoFavoritoActualizar
    {
        [Columna("id_persona_rol")]
        public int id_persona_rol { get; set; }

        [Columna("id_destino")]
        public int id_destino { get; set; }

        [Columna("destino_lat")]
        public string destino_lat { get; set; }

        [Columna("destino_lon")]
        public string destino_lon { get; set; }

        [Columna("nombre_destino")]
        public string nombre_destino { get; set; }

        [Columna("nombre_personalizado")]
        public string nombre_personalizado { get; set; }
    }
}

