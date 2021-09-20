using Foundation.Contract;
using Foundation.Dto;
using Hangfire;
using StoreManagement.BackgroundJob.Managers.FireAndForgetJobs;
using System;

namespace OVM.Jobs.Schedules
{
    /// <summary>
    /// Bir kere ve hemen çalışan job türüdür.(Schedules class)
    /// </summary>
    public static class FireAndForgetJobs
    {
        public static void NewProductSendMail(MailDto mailDto, ProductContract product)
        {
            BackgroundJob.Enqueue<NewProductMailJobManager>(x => x.Process(mailDto, product));
        }

        //silinmiş ürün için sepet kontrolü
        public static void CartCheck(int prodctId)
        {
           var jobId =  BackgroundJob.Enqueue<CartCheckJobManager>(x => x.Process(prodctId));

            ContinuationJobs.SendMailAboutDeletedProduct(jobId);
        }
    }
}
