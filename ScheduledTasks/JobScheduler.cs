using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;

namespace ScheduledTasks
{
    public class JobScheduler
    {
        public static async Task StartAsync(CronScheduleBuilder cronStart, JobDataMap data, bool startNow = false)
        {
            TriggerBuilder builder = TriggerBuilder.Create();
            builder.WithSchedule(cronStart);
            if (startNow) builder.StartNow();

            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();
            await scheduler.ScheduleJob(JobBuilder.Create<ChangedTokenJob>().UsingJobData(data).Build(), builder.Build());
        }
    }
}