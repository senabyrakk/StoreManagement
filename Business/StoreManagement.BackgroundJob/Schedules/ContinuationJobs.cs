using StoreManagement.BackgroundJob.Managers.ContinuationJobs;
using System.Collections.Generic;

namespace OVM.Jobs.Schedules
{
    /// <summary>
    /// Birbiri ile ilişkili işlerin olduğu zaman çalışan job. Job tetiklenmesi için başka bir job bitmesi gerekiyor
    /// </summary>
    /// <param name="id">İlişkili job id değeri</param>
    public static class ContinuationJobs
    {
        public static void SendMailAboutDeletedProduct(string id)
        {
            Hangfire.BackgroundJob.ContinueJobWith<SendMailAboutDeletedProduct>(
                          parentId: id,
                          job => job.Process());
        }
    }
}
