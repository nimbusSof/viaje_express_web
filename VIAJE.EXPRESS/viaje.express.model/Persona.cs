
using Nimbussoft.BaseDeDatos;
using System;


namespace viaje.express.model
{
	[Tabla("persona")]
	public class Persona
	{

		public Persona() { }

		[Columna("persona_id")]
		public int IdPersona { get; set; }

		[Columna("persona_cedula")]

		public string CedulaPersona { get; set; }

		[Columna("persona_nombre")]
		public string NombrePersona { get; set; }

		[Columna("persona_apellidos")]
		public string ApellidosPersona { get; set; }

		[Columna("persona_nacimiento")]
		public DateTime NacimientoPersona{ get; set; }

		[Columna("persona_telefono")]
		public string TelefonoPersona { get; set; }

		[Columna("persona_direccion")]
		public string DireccionPersona { get; set; }


		[Columna("persona_correo")]
		public string CorreoPersona { get; set; }

		[Columna("persona_contrasenia")]
		public string ContraseniaPersona { get; set; }//ojo aqui la observacion

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

		[Columna("persona_nombre_usuario")]
		public string PersonaNombreUsuario { get; set; }


	}
}