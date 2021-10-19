using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using viaje.express.data;
using viaje.express.data.DataLogin;
using viaje.express.data.DataCooperativa;
using viaje.express.data.DataModulo;
using viaje.express.data.DataUsuario;
using viaje.express.data.DataVehiculo;
using viaje.express.data.DataChofer;
using viaje.express.data.DataRuta;
using viaje.express.data.DataEstadoVehiculo;
using viaje.express.data.DataCuentas;

using viaje.express.data.DataTipoSolicitud;
using viaje.express.data.DataEstadoSolicitud;
using viaje.express.data.DataTipoCarrera;
using viaje.express.data.DataCarreraEjecucion;
using viaje.express.data.DataAgendarSolicitudCliente;
using viaje.express.data.DataPreferencias;
using viaje.express.data.DataDestinoFavorito;

namespace viaje.express.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<Login_db>();
            services.AddTransient<Cooperativa_db>();
            services.AddTransient<Modulo_db>();
            services.AddTransient<Entities_db>();
            services.AddTransient<Usuario_db>();
            services.AddTransient<UsuarioCooperativa_db>();
            services.AddTransient<UsuarioAdministradorCooperativa_db>();
            services.AddTransient<UsuarioOperadorCooperativa_db>();
            services.AddTransient<Vehiculo_db>();
            services.AddTransient<Chofer_db>();
            services.AddTransient<Ruta_db>();
            services.AddTransient<EstadoVehiculo_db>();

            services.AddTransient<CuentaUsuario_db>();
            services.AddTransient<CuentaUsuarioChofer_db>();
            services.AddTransient<CuentaUsuarioCliente_db>();
            services.AddTransient<CuentaUsuarioSuperAdministrador_db>();
            services.AddTransient<CuentaUsuarioOperador_db>();
            services.AddTransient<CuentaUserAdminCoop_db>();

            services.AddTransient<TipoSolicitud_db>();
            services.AddTransient<EstadoSolicitud_db>();
            services.AddTransient<TipoCarrera_db>();
            services.AddTransient<CarreraEjecucion_db>();
            services.AddTransient<AgendarSolicitudCliente_db>();

            services.AddTransient<PreferenciasUsuario_db>();
            services.AddTransient<DestinosFavoritos_db>();


            services.AddCors();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "viaje.express.api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "viaje.express.api v1"));
            }

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
