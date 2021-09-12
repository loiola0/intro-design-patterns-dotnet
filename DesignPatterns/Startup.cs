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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DesignPatterns.Infra.Singleton;
using DesignPatterns.Domain;
using DesignPatterns.Infra.Repository;
using DesignPatterns.Infra.Repository.EF;
using DesignPatterns.Infra.Facade;

namespace DesignPatterns
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesignPatterns", Version = "v1" });
            });

            services.AddSingleton<SingletonContainer>();

            services.AddTransient<IVeiculoRepository,DesignRepository>();

            services.AddDbContext<DesignContext>(opt => opt.UseInMemoryDatabase("Design"));

            services.AddTransient<IVeiculoDetran,VeiculoDetranFacade>();

            services.Configure<DetranOptions>(Configuration.GetSection("DetranOptions"));

            services.AddHttpClient();

           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesignPatterns v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
