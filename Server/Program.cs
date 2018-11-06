using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleShoppingListWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

           var logger = host.Services.GetRequiredService<ILogger<Program>>();
           logger.LogInformation("Hello World from NLog 16");

            host.Run();   
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureLogging(logging =>
                   {
                       logging.SetMinimumLevel(LogLevel.Trace);
                       logging.ClearProviders();
                       logging.AddConsole();
                    })
                   .UseNLog()
                   .UseStartup<Startup>()
                   .Build();
    }
}
