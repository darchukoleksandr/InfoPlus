using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WebApp.Data;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            using (var applicationDbContext = new ApplicationDbContext())
            {
                Console.WriteLine("Ensuring that database is created!");
                applicationDbContext.Database.EnsureCreated();
            }

            host.Run();
        }
    }
}
