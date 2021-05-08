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

        

            services.AddTransient<CooperativaBd>();
            services.AddTransient<PersonaBd>();
            services.AddTransient<PersonaRolBd>();

            services.AddTransient<RolBd>();
            services.AddTransient<ChoferBD>();
            services.AddTransient<VehiculoBd>();
            services.AddTransient<OperadoraBD>();
            services.AddTransient<SolicitudClienteBd>();
            services.AddTransient<RutaBd>();
            services.AddTransient<RutaChoferBd>();
            services.AddTransient<CarreraChoferBd>();

            services.AddTransient<AgendarClienteBd>();
            services.AddTransient<LugarBd>();

            services.AddTransient<Prueba_bd>();




            services.AddTransient<Login_db>();
            services.AddTransient<Cooperativa_db>();
            services.AddTransient<Modulo_db>();
            services.AddTransient<Entities_db>();
            services.AddTransient<Usuario_db>();
            services.AddTransient<UsuarioCooperativa_db>();

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
