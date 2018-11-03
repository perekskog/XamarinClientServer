using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SimpleShoppingListWebApi
{
    public class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            logger.Info("Hello World from NLog 6");

            BuildWebHost(args).Run();   
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
