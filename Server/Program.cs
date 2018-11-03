using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web;
using Microsoft.Extensions.Logging;

namespace SimpleShoppingListWebApi
{
    public class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            logger.Info("Hello World from NLog 13");

            BuildWebHost(args).Run();   
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureLogging(logging =>
                   {
                       logging.SetMinimumLevel(LogLevel.Trace);
                    })
                   .UseNLog()
                   .UseStartup<Startup>()
                   .Build();
    }
}
