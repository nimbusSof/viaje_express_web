using Nimbussoft.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace viaje.express.model

  {
	[Tabla("solicitud_cliente")]

	public class SolicitudCliente
	{
		[Columna("solicitud_cliente_id")]

		public int SolicitudClienteId { get; set; }

		[Columna("persona_rol_id")]

		public int PersonaRolId { get; set; }

		[Columna("tipo_solicitud_id")]

		public int TipoSolicitudId { get; set; }

		[Columna("solicitud_cliente_salida_solCliente")]

		public string SolicitudClienteSalidaSolCliente { get; set; }


		[Columna("solicitud_cliente_destino_solCliente")]

		public string SolicitudClienteDestinoSolCliente { get; set; }


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
