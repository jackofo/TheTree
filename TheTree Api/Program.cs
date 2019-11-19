using System;
//using TheTreeCore.Entities;
//using Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TheTree_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args)
                .Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

                try
                {
                    logger.LogDebug("Initialization of TheTree APIs...");
                    //var userManager = services.GetRequiredService<UserManager<User>>();
                    //var projectContext = services.GetRequiredService<ProjectContext>();
                    //ProjectContextLocalizationSeed.ProjectSeedAsync(projectContext, userManager, loggerFactory).Wait();
                    //ProjectContextSecuritySeed.ProjectSeedAsync(projectContext, userManager, loggerFactory).Wait();
                    //ProjectContextSeed.ProjectSeedAsync(projectContext, userManager, loggerFactory).Wait();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the DB...");
                }
                finally
                {
                    //LogManager.Shutdown();
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls(urls: "https://localhost:84")
                .UseIISIntegration()
                .UseStartup<Startup>();
        }
    }
}
