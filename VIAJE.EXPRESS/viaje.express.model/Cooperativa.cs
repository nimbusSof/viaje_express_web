using Nimbussoft.BaseDeDatos;
using System;

namespace viaje.express.model
{
	[Tabla("cooperativa")]
	public class Cooperativa
	{

		

		[Columna("cooperativa_id")]
		public int IdCoop { get; set; }

		[Columna("persona_rol_id")]
		public Nullable<int> IdPersonarol { get; set; }

		[Columna("cooperativa_nombre")]
		public string Nombrecoop { get; set; }

		[Columna("cooperativa_direccion")]
		public string DireccionCoop { get; set; }

		[Columna("cooperativa_telefono")]
		public string TelefonoCoop { get; set; }

		[Columna("created_at")]
		public DateTime CreatedAt { get; set; }

		[Columna("created_by")]
		public int CreatedBy { get; set; }

		[Columna("modified_at")]
		public Nullable<DateTime> ModifiedAt { get; set; }

		[Columna("modified_by")]
		public Nullable<int> ModifiedBy { get; set; }

		[Columna("deleted_at")]
		public Nullable<DateTime> DeletedAt { get; set; }

		[Columna("deleted_by")]
		public Nullable<int> DeletedBy { get; set; }

	}
}
