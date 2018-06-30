using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionName = "HomeConnection";
            //var connectionName = "WorkConnection";

            // config
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            // services
            var services = new ServiceCollection();

            services.AddLogging();
            services.AddDbContext<FootballManagerContext>(o => o.UseSqlServer(config.GetConnectionString(connectionName)));

            var serviceProvider = services.BuildServiceProvider();
        }
    }
}
