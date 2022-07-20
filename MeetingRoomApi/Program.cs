using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MeetingRoomApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseDefaultServiceProvider(options =>
                            options.ValidateScopes = true);
                });
    }
}
