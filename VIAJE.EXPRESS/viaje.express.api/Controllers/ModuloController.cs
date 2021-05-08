using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viaje.express.data.DataModulo;
using viaje.express.model.ModelModulos;
using viaje.express.model;
using Microsoft.Extensions.Logging;

namespace viaje.express.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly ILogger<ModuloController> _logger;
        private readonly Modulo_db _modulo_db;
        private BaseController bc;

        public ModuloController(ILogger<ModuloController> logger, Modulo_db modulo_db)
        {
            _logger = logger;
            _modulo_db = modulo_db;
            bc = new BaseController();
        }

        [HttpGet]
        [Route("{id}")]
        public Resultado ObtenerPermisos(int id, [FromHeader] string token="")
        {
            Resultado r = new Resultado();
            r.Exito = false;
            r.Codigo = 0;

            if (bc.verificar(token))
            {
                List<ModuloRol> modulo_rol = _modulo_db.getRutasRol(id);
                if (modulo_rol.Count > 0)
                {
                    r.Codigo = 1;
                    r.Data = modulo_rol;
                    r.Mensaje = "Correcto";
                    r.Exito = true;
                    return r;
                }
                else
                {
                    r.Mensaje = "No se encontro ningun registro";
                    return r;
                }
            } else
            {
                r.Mensaje = bc.mensaje;
                r.Codigo = bc.codigo;
                return r;
            }
        }

        //public int get(int id)
        //{
        //    int loop1, loop2;
        //    NameValueCollection coll;

        //    // Load Header collection into NameValueCollection object.
        //    coll = Request.Headers;

        //    // Put the names of all keys into a string array.
        //    String[] arr1 = coll.AllKeys;
        //    for (loop1 = 0; loop1 < arr1.Length; loop1++)
        //    {
        //        Response.Write("Key: " + arr1[loop1] + "<br>");
        //        // Get all values under this key.
        //        String[] arr2 = coll.GetValues(arr1[loop1]);
        //        for (loop2 = 0; loop2 < arr2.Length; loop2++)
        //        {
        //            Response.Write("Value " + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
        //        }
        //    }
        //    return 0;
        //}
        /*private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        //private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public ActionResult Post(WeatherForecast forecast)
        {

            // Save the weather…
            return Ok();
        }*/

        /*private static HashSet<string> _methods = new HashSet<string> { "POST", "PUT", "PATCH" };
        public void Apply(ActionModel action)
        {
            var model = action.Selectors.OfType<SelectorModel>().SingleOrDefault();
            var mm = model?.EndpointMetadata.OfType<HttpMethodMetadata>().SingleOrDefault();
            if (mm != null && _methods.Intersect(mm.HttpMethods).Any() && action.Parameters.Any(x => x.Attributes.OfType<FromBodyAttribute>().Any()))
            {
                action.Filters.Add(new ConsumesAttribute("application/json"));
            }

        }*/

        /*[HttpGet]
        //Request.ServerVariables["HTTP_USER_AGENT"];
        public string get()
        {
            //Request.Headers.GetValues("XXX");
            //Request.ServerVariables.Get("HTTP_USER_AGENT");
            string str;
            str = Request.ContentType;
            //txt = Request.ContentType.ToString();
            return str;
        }*/
        /*[HttpGet]
        public string get_o([FromHeader]header model)
        {
            return model.key + ": " + model.value;
        }*/
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /*[HttpGet]
        public IEnumerable<WeatherForecast> Get([FromHeader] int cantidadElementos = 5)
        {

            // Nota: esta es otra manera de acceder al valor de la cabecera:
            //var cantidadElementos2 = int.Parse(HttpContext.Request.Headers["cantidadElementos"].ToString());

            var rng = new Random();
            return Enumerable.Range(1, cantidadElementos).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }*/

        /*[HttpGet]
        public string Get([FromHeader] string cantidadElementos)
        {

            // Nota: esta es otra manera de acceder al valor de la cabecera:
            //var cantidadElementos2 = int.Parse(HttpContext.Request.Headers["cantidadElementos"].ToString());
            if(cantidadElementos.Equals(""))
            {
                return "No hay elementos: " + cantidadElementos;
            }
            else
            {
                return "cantidadElementos: " + cantidadElementos;
            }
            
        }*/

    }

    public class header
    {
        public string key { get; set; }
        public string value { get; set; }
    }


    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

}
