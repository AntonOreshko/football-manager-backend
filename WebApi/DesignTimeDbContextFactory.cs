using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.EntityFramework.Context;

namespace WebApi
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FootballManagerContext>
    {
        public FootballManagerContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<FootballManagerContext>();

            //var connectionString = configuration.GetConnectionString("HomeConnection");
            var connectionString = configuration.GetConnectionString("WorkConnection");

            builder.UseSqlServer(connectionString);

            return new FootballManagerContext(builder.Options);
        }
    }
}
