using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelDestinoFavorito
{
    public class Probando
    {
       /* [Columna("id_destino")]
        public int id_destino { get; set; }*/

        [Columna("id_persona_rol")]
        public int id_persona_rol { get; set; }

        [Columna("destino_lat")]
        public string destino_lat { get; set; }

        [Columna("destino_lon")]
        public string destino_lon { get; set; }

    }
}
