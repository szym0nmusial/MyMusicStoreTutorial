using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicStoreTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                InitiDatabase(scope);
            }
            host.Run();

        }

        /// <summary>
        /// wype³nienie przyk³adowymi danymi, w ef core zrezygnowano z Initializerów :(
        /// </summary>
        public static void InitiDatabase(IServiceScope scope)
        {
            var services = scope.ServiceProvider;

            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                var context = services.GetRequiredService<Models.MusicStoreEntities>();
                Models.SampleData.Initialize(context);
                context.SaveChanges();
                logger.LogInformation("Seeding Ok.");

            }
            catch (Exception ex)
            {
                logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }

        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
