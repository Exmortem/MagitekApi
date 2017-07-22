using System;
using System.IO;
using MagitekApi.Database;
using MagitekApi.Models;
using Microsoft.AspNetCore.Hosting;

namespace MagitekApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var entry = new MagitekSettings() { Author = "Exmortem", Job = "Scholar", Name = "Exmortem's Great Scholar Routine" };

            //using (var context = MagitekContextFactory.Create())
            //{
            //    context.Add(entry);
            //    context.SaveChanges();
            //}

            var newScholarSettings = new ScholarSettings() { Author = "Exmortem", Job = "Scholar", Name = "The best"};

            using (var context = MagitekContextFactory.Create())
            {
                context.Add(newScholarSettings);
                context.SaveChanges();
            }

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
