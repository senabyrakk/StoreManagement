using StoreManagement.BackgroundJob.Managers;
using System;

namespace OVM.Jobs.Schedules
{
    /// <summary>
    /// Oluşturulduktan sonra ayarlanan süre sonrasında tek seferliğine çalışacak job türüdür. 
    /// </summary>
    public static class DelayedJobs
    {
        public static void NewCustomerSendMail(int userId)
        {
            Hangfire.BackgroundJob.Schedule<NewCustomerSendMail>
                 (
                  job => job.Process(userId),
                  TimeSpan.FromSeconds(10)
                  );
        }
    }
}
