using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using Sadad.Core.ApplicationService.Services.HttpClient;
using Sadad.Core.Entities.Model;
using Sadad.Infrastructure.EF.DataBase;
using SadadWebApi.Extensions;

using SadadWebApi.Mapping;
using SadadWebApi.MiddleWare;

namespace WebApplication
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<SadadDbContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("SadadConnectionStrings")));

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingConfiguration)));
            services.AddDependency();
            services.AddHttpClient<HttpClientUser>();
         
            services.AddControllers();
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("SadadTask", new OpenApiInfo { Title = "SadadWebApi", Version = "SadadTask" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
      
       
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/SadadTask/swagger.json", "SadadTask"));

            app.UseHttpsRedirection();

            app.UseRouting(); 

            app.UseAuthorization();


            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
