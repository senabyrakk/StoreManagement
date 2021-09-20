using Foundation.Abstraction;
using Foundation.Contract;
using Foundation.Dto;
using System.Threading.Tasks;

namespace StoreManagement.BackgroundJob.Managers.FireAndForgetJobs
{
    public class NewProductMailJobManager
    {
        private readonly IMailingService _mailService;
        public NewProductMailJobManager(IMailingService mailService)
        {
            _mailService = mailService;
        }

        public async Task Process(MailDto mailMessageDto, ProductContract product)
        {
            mailMessageDto.Subject = "Yeni Ürün Bildirimi";
            mailMessageDto.Body = "Merhaba mağazamıza yeni " + product.Name + " eklenmiştir. Özellikler " + product.Description + ". Mağazamıza bekleriz.";
            await _mailService.SendAsync(mailMessageDto);
        }
    }
}
