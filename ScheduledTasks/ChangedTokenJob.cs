using Quartz;
using System;
using System.Threading.Tasks;

namespace ScheduledTasks
{
    public class ChangedTokenJob : IJob

    {
        public string Mode { get; set; }

        public Task Execute(IJobExecutionContext context)
        {
            // To do action.
            return new Task(() => {
                Console.WriteLine($"Hello {Mode}!");
            });
        }
    }
}
