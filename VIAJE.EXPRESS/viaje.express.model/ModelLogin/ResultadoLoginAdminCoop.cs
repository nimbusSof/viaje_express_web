using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;
using viaje.express.model.ModelLogin;

namespace viaje.express.model.ModelLogin
{
    public class ResultadoLoginAdminCoop: SecurityViewModel
	{
		[Columna("exito")]
		public bool exito { get; set; }

		[Columna("id_persona_rol")]
		public int id_persona_rol { get; set; }

		[Columna("id_cooperativa")]
		public int id_cooperativa { get; set; }

		[Columna("rol")]
		public int rol { get; set; }

		[Columna("mensaje")]
		public string mensaje { get; set; }
	}
}
