using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.Storage;

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


            GlobalConfiguration.Configuration.UseSqlServerStorage(config.GetConnectionString(connectionName));

            // services
            var services = new ServiceCollection();

            services.AddLogging();
            services.AddDbContext<FootballManagerContext>(o => o.UseSqlServer(config.GetConnectionString(connectionName)));

            var serviceProvider = services.BuildServiceProvider();

            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");

                RecurringJob.AddOrUpdate(() => Console.Write("Easy!"), Cron.Minutely);

                Console.ReadLine();
            }

            using (var connection = JobStorage.Current.GetConnection())
            {
                foreach (var recurringJob in connection.GetRecurringJobs())
                {
                    RecurringJob.RemoveIfExists(recurringJob.Id);
                }
            }
        }
    }
}
