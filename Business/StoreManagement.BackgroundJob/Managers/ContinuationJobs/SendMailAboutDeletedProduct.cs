using Foundation.Abstraction;
using Foundation.Abstraction.Service;
using Foundation.Dto;
using System.Threading.Tasks;

namespace StoreManagement.BackgroundJob.Managers.ContinuationJobs
{
    public class SendMailAboutDeletedProduct
    {
        private readonly IMailingService _mailService;
        private readonly ICustomerService _customerService;
        public SendMailAboutDeletedProduct(IMailingService mailService, ICustomerService customerService)
        {
            _mailService = mailService;
            _customerService = customerService;
        }

        public async Task Process()
        {
            //Sepetinden silinmiş kullanıcılar bulunur.
            //toMail.Add(kullanıcı mail adresleri);
            MailDto mailDto = new MailDto
            {
                Body = "Merhaba, ürünümüz kalmadığı için sepetinizden cıkarılmıştır.",
                Subject = "Sepet Güncelleme Uyarısı",
                //ToEmailss = toMail
            };
            await _mailService.SendAsync(mailDto);
        }
    }
}
