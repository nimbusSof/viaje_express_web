using System;
using System.Collections.Generic;
using System.Text;
using viaje.express.model.ModelLogin;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelLogin
{
    public class ResultadoLoginChofer: SecurityViewModel
    {
		[Columna("exito")]
		public bool exito { get; set; }

		[Columna("id_persona_rol")]
		public int id_persona_rol { get; set; }

		[Columna("id_cooperativa")]
		public int id_cooperativa { get; set; }

		[Columna("id_vehiculo")]
		public int id_vehiculo { get; set; }

		[Columna("rol")]
		public int rol { get; set; }

		[Columna("mensaje")]
		public string mensaje { get; set; }
	}
}
