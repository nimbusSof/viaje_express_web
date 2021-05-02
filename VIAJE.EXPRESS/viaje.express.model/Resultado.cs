using Nimbussoft.BaseDeDatos;

namespace viaje.express.model
{
	[Tabla("persona")]
	public class Resultado
    {

		public Resultado() { }

		[Columna("exito")]
		public bool Exito { get; set; }

		[Columna("codigo")]
		public int Codigo { get; set; }

		[Columna("mensaje")]
		public string Mensaje { get; set; }
	}
}
