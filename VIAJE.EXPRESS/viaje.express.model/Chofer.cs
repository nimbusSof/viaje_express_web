using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
	[Tabla("chofer")]

	public class Chofer
    {
		[Columna("chofer_id")]

		public int ChoferId { get; set; }

		[Columna("cooperativa_id")]

		public int CooperativaId { get; set; }

		[Columna("persona_rol_id")]

		public int PersonaRolId { get; set; }

		[Columna("vehiculo_id")]

		public int VehiculoId { get; set; }


		[Columna("estado_chofer_id")]

		public int EstadoChoferId { get; set; }

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
