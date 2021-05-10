
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace viaje.express.model
{
	public class Persona
	{

		public Persona() { }

		public int IdPersona { get; set; }


		public string CedulaPersona { get; set; }

		public string NombrePersona { get; set; }

		public string ApellidosPersona { get; set; }

		public string NacimientoPersona{ get; set; }

		public string TelefonoPersona { get; set; }

		public string DireccionPersona { get; set; }

		public string CorreoPersona { get; set; }

		public string ContraseniaPersona { get; set; }//ojo aqui la observacion

		public DateTime CreatedAt { get; set; }

		public int CreatedBy { get; set; }

		public Nullable<DateTime> ModifiedAt { get; set; }

		public Nullable<int> ModifiedBy { get; set; }

		public Nullable<DateTime> DeletedAt { get; set; }

		public Nullable<int> DeletedBy { get; set; }



		public async Task<List<Persona>> ObtenerPersonaAsync()
		{
			List<Persona> listaper= new List<Persona>();
			var url = "http://localhost:59454/Persona";
			using (var http = new HttpClient())
			{
				var response = await http.GetStringAsync(url);

				var persona = JsonConvert.DeserializeObject<List<Persona>>(response);
				foreach (var p in persona) {
					listaper.Add(p);
				}

				Console.WriteLine(persona);

			}
			return listaper;
		}
	

	}
}