using Hangfire;
using StoreManagement.BackgroundJob.Managers.RecurringJobs;

namespace OVM.Jobs.Schedules
{
    /// <summary>
    /// Çok kez tekrarlı işler ve belirtilen CRON süresince çalışır.
    /// </summary>
    
    //[AutomaticRetry(Attempts=1)]
    public static  class RecurringJobs
    {
        public static void Start()
        {
            RecurringJob.AddOrUpdate<StockControlJobManager>(nameof(StockControlJobManager),
               job => job.Process(), "00 00 * * *"
          );
        }
    }
}
