using Quartz;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ScheduledTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Case 1: Run at time daily
            TimeSpan timeCase1 = new TimeSpan(0, 0, 0);  // 0:00 
            CronScheduleBuilder cronCase1 = CronScheduleBuilder.DailyAtHourAndMinute(timeCase1.Hours, timeCase1.Minutes);
            JobDataMap dataCase1 = new JobDataMap() { new KeyValuePair<string, object>("Mode", "Case 1 - Daily") };
            Thread thread = new Thread(async () => {
                await JobScheduler.StartAsync(cronCase1, dataCase1, true);
            });
            thread.Start();

            //// --------------------------- //
            //// Case 2: Run at time on days of week
            //TimeSpan timeCase2 = new TimeSpan(0, 0, 0); // 0:00 
            //DayOfWeek[] daysCase2 = new DayOfWeek[2] { DayOfWeek.Saturday, DayOfWeek.Sunday };  // Run on weekend
            //CronScheduleBuilder cronCase2 = CronScheduleBuilder.AtHourAndMinuteOnGivenDaysOfWeek(timeCase2.Hours, timeCase2.Minutes, daysCase2);
            //JobDataMap dataCase2 = new JobDataMap();
            //dataCase2.Add("Mode", "Case 2 - Weekend");
            //JobScheduler.Start(cronCase2, dataCase2);

            //// --------------------------- //
            //// Case 3: Run at time on days of weekly
            //TimeSpan timeCase3 = new TimeSpan(8, 0, 0); // 8:00 
            //DayOfWeek dayCase3 = DayOfWeek.Monday;  // Run on Monday
            //CronScheduleBuilder cronCase3 = CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(dayCase3, timeCase3.Hours, timeCase3.Minutes);
            //JobDataMap dataCase3 = new JobDataMap();
            //dataCase3.Add("Mode", "Case 2 - Weekly on Monday");
            //JobScheduler.Start(cronCase3, dataCase3);

            //// --------------------------- //
            //// Case 4: Run at time on days of weekly
            //TimeSpan timeCase4 = new TimeSpan(8, 0, 0); // 8:00 
            //int dayOfMonth = 1;  // Run on Monday
            //CronScheduleBuilder cronCase4 = CronScheduleBuilder.MonthlyOnDayAndHourAndMinute(dayOfMonth, timeCase4.Hours, timeCase4.Minutes);
            //JobDataMap dataCase4 = new JobDataMap();
            //dataCase4.Add("Mode", "Case 4 - First of Month");
            //JobScheduler.Start(cronCase4, dataCase4);

            Console.ReadLine();
        }
    }
}
