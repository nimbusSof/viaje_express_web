using Nimbussoft.BaseDeDatos;

namespace viaje.express.model
{
	public class Resultado
    {

		public Resultado() { }

		[Columna("exito")]
		public bool Exito { get; set; }

		[Columna("codigo")]
		public int Codigo { get; set; }

		[Columna("mensaje")]
		public string Mensaje { get; set; }

		[Columna("data")]
		public object Data { get; set; }	
	}
}
