using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elcavernas.Govrnz.Registry.WebApi.Docs;
using ElCavernas.Govrnz.Registry.Backend.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatR;

namespace Elcavernas.Govrnz.Registry.WebApi
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        private ILoggerFactory _loggerFactory;
        private ILogger _logger;
        
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
            _hostingEnvironment = env;
            
            _logger = _loggerFactory.CreateLogger(nameof(Startup));
            _logger.LogInformation("Startup instantiated");
        }

        
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("ConfigureServices started");

            services.AddMediatR(typeof(Startup).Assembly, typeof(GetResult).Assembly);
            services.AddSwaggerGen(SwaggerHelper.ConfigureSwaggerGen);

            services.AddMvc().AddJsonOptions(j =>
            {
                j.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                j.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });

            _logger.LogInformation("ConfigureServices complete");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _logger.LogInformation("Configure started");
            
            if (!env.EnvironmentName.Equals("Test"))
            {
                app.UseStaticFiles();
                app.UseSwagger(SwaggerHelper.ConfigureSwagger);
                app.UseSwaggerUI(SwaggerHelper.ConfigureSwaggerUI);
            }

            app.UseMvc();
            _logger.LogInformation("Configure complete");
        }
    }
}
