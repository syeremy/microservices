﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElCavernas.Govrnz.Extensions.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Elcavernas.Govrnz.Registry.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
//            var appRootPath = Directory.GetCurrentDirectory();
//            BuildWebHost(appRootPath, args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        
        public static IWebHost BuildWebHost(string appRootPath, string[] args)
        {
            var webHostBuilder = GetWebHostBuilder(appRootPath, args);
            return webHostBuilder.Build();
        }

        
        public static IWebHostBuilder GetWebHostBuilder(string appRootPath, string[] args)
        {
            var webHostBuilder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(appRootPath)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var secretsMode = GetSecretsMode(hostingContext.HostingEnvironment);
                    config.AddGovrnanzaConfig(secretsMode, "REGISTRY_CONFIG_FILE");
                })
                .UseStartup<Startup>();

            return webHostBuilder;
        }
        
        private static SecretsMode GetSecretsMode(IHostingEnvironment env)
        {
            if (env.IsProduction())
                return SecretsMode.DockerSecrets;

            var useDockerSecrets = Environment.GetEnvironmentVariable("REGISTRY_USE_DOCKER_SECRETS");
            if (useDockerSecrets != null && useDockerSecrets.Equals("false", StringComparison.OrdinalIgnoreCase))
                return SecretsMode.LocalFile;

            return SecretsMode.DockerSecrets;
        }
    }
}
