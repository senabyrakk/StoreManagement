using Foundation.Abstraction;
using Foundation.Abstraction.Service;
using Foundation.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.BackgroundJob.Managers
{
    public class NewCustomerSendMail
    {
        private readonly IMailingService _mailService;
        private readonly ICustomerService _customerService;
        public NewCustomerSendMail(IMailingService mailService, ICustomerService customerService)
        {
            _mailService = mailService;
            _customerService = customerService;
        }

        public async Task Process(int userId)
            {
            var user = _customerService.Get(userId);

            var toMail = new List<string>();
            toMail.Add(user.Email);
            MailDto mailDto = new MailDto
            {
                Body = "Merhaba mağazamıza hoşgeldiniz. Mağazamızın sizlerin güvenliğini koruduğundan emin olabilirsiniz.....(bir takım güvenlik bilgileri):)",
                Subject = "Mağazamıza hoşgeldiniz",
                ToEmailss = toMail
            };
            await _mailService.SendAsync(mailDto);
        }
    }
}
