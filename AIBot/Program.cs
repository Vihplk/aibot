using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AIBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AIBot.Core.GlobalConfig.ConnectionString = GlobalConfig.ConnectionString;
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
