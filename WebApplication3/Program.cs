using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(()=>  CreateHostBuilder(args).Build().Run());
            CreateSignalRHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                    .ConfigureKestrel(serverOptions =>
                    {
                        // Set properties and call methods on options
                        serverOptions.Listen(IPAddress.Loopback, 3000);
                    })
                    .UseStartup<Startup>();
                });

        public static IHostBuilder CreateSignalRHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                    .ConfigureKestrel(serverOptions =>
                    {
                        // Set properties and call methods on options
                        serverOptions.Listen(IPAddress.Loopback, 3005);
                    })
                    .UseStartup<SignalRStartup>();
                });
    }
}
