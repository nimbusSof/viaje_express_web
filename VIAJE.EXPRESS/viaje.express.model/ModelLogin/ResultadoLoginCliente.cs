using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelLogin
{
    public class ResultadoLoginCliente: SecurityViewModel
    {
		[Columna("exito")]
		public bool exito { get; set; }

		[Columna("id_persona_rol")]
		public int id_persona_rol { get; set; }

		[Columna("rol")]
		public int rol { get; set; }

		[Columna("mensaje")]
		public string mensaje { get; set; }
	}
}
