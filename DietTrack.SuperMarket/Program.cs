using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace DietTrack.SuperMarket
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                await CreateWebHostBuilder(args).Build().RunAsync();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
