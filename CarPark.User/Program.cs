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
    WriteTo.File("log.txt"). // txt dosyasýna loglarý kaydeder.
    WriteTo.Seq("http://localhost:5341/") // Log sunucusunda loglarý açar
    .Enrich.WithProperty("ApplicationName","CarPark.User") // hani proje üzerinden iþlem yapýldýðýný tutar
    .Enrich.WithMachineName()  // hangi cihazdan girildiðini tutar
    .CreateLogger();// Seri log entegrasyonu için

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog(); // Serilog entegrasyonu için
    }
}
