using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using integracion.api.Models.Context;

using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

namespace integracion.api
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
            var conn = "data source=agroverde.database.windows.net;initial catalog=IntegracionApp;persist security info=False;user id=useradmin;password=Code1234,;MultipleActiveResultSets=True;TrustServerCertificate=False;Connection Timeout=300;";
             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

             services.AddDbContext<IntegrationDbContext>(opt => opt.UseSqlServer(conn));

services.AddCors(options => { options.AddPolicy("AllowAllOrigins", builder => { builder.AllowAnyOrigin(); builder.AllowAnyMethod(); builder.AllowAnyHeader(); });});               


    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "NominasAPI", Version = "v2" });
    });
            // services.AddCors("*");
          //   services.Add<

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();


            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseMvc();
        }
    }
}
