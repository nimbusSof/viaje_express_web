using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model
{
	[Tabla("carrera_chofer")]

	public class CarreraChofer
	{
		[Columna("carrera_chofer_id")]

		public int CarreraChoferId { get; set; }

		[Columna("solicitud_cliente_id")]

		public int SolicitudClienteId { get; set; }

		[Columna("chofer_id")]

		public int ChoferId { get; set; }

		[Columna("cooperativa_id")]

		public int CooperativaId { get; set; }

		[Columna("carrera_chofer_monto")]

		public double CarreraChoferMonto { get; set; }

		[Columna("estado_solicitud_id")]

		public int EstadoSolicitudId { get; set; }

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