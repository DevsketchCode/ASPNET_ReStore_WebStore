using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using API.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // with Using, it will dispose of the scope and it's resources after it is done
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                // Will create the database if it doesn't exist
                context.Database.Migrate();
                // Will populate the initial products to the database
                DbInitializer.Initialize(context);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Problem migrating data");
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
