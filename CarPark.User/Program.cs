using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().
    WriteTo.File("log.txt"). // txt dosyas�na loglar� kaydeder.
    WriteTo.Seq("http://localhost:5341/") // Log sunucusunda loglar� a�ar
    .Enrich.WithProperty("ApplicationName","CarPark.User") // hani proje �zerinden i�lem yap�ld���n� tutar
    .Enrich.WithMachineName()  // hangi cihazdan girildi�ini tutar
    .CreateLogger();// Seri log entegrasyonu i�in

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog(); // Serilog entegrasyonu i�in
    }
}
