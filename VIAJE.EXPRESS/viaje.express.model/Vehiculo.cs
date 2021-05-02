using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
	[Tabla("vehiculo")]
	public class Vehiculo
    {
		[Columna("vehiculo_id")]

		public int VehiculoId { get; set; }

		[Columna("cooperativa_id")]

		public int CooperativaId { get; set; }

		[Columna("vehiculo_placa_vehiculo")]

		public string VehiculoPlacaVehiculo { get; set; }

		[Columna("vehiculo_color_vehiculo")]

		public string VehiculoColorVehiculo { get; set; }

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
