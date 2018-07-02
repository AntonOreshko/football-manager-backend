using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using Engine.Jobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

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

            var props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            var factory = new StdSchedulerFactory(props);

            StartQuartz();

            Console.ReadLine();
        }

        private static async Task StartQuartz()
        {
            // construct a scheduler factory
            var props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            var factory = new StdSchedulerFactory(props);

            // get a scheduler
            var sched = await factory.GetScheduler();
            await sched.Start();

            // define the job and tie it to our HelloJob class
            var job = JobBuilder.Create<TestJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 2 seconds
            var trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(2)
                    .RepeatForever())
                .Build();

            await sched.ScheduleJob(job, trigger);
        }
    }
}
