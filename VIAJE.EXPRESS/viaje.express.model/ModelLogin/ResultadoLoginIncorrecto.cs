using System;
using System.Collections.Generic;
using System.Text;
using Nimbussoft.BaseDeDatos;

namespace viaje.express.model.ModelLogin
{
    public class ResultadoLoginIncorrecto
    {

		[Columna("exito")]
		public bool exito { get; set; }

		[Columna("mensaje")]
		public string mensaje { get; set; }
	}
}
