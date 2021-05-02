using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelLogin
{
    public class ResultadoLogin
    {
		[Columna("exito")]
		public bool exito { get; set; }

		[Columna("id_persona")]
		public int id_persona { get; set; }

		[Columna("rol")]
		public int rol { get; set; }

		[Columna("mensaje")]
		public string mensaje { get; set; }
	}
}
