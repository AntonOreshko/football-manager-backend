using System;
using System.Threading.Tasks;
using Quartz;

namespace Engine.Jobs
{
    public class TestJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Hello world");
        }
    }
}
