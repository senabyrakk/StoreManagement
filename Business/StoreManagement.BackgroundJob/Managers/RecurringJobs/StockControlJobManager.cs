using Foundation.Abstraction;
using Foundation.Abstraction.Service;
using Foundation.Dto;
using System.Threading.Tasks;

namespace StoreManagement.BackgroundJob.Managers.RecurringJobs
{
    public class StockControlJobManager
    {
        readonly IProductService _productService;
        private readonly IMailingService _mailService;
        public StockControlJobManager(IProductService productService, IMailingService mailService)
        {
            _productService = productService;
            _mailService = mailService;
        }
        public async Task Process()
        {
            var body = _productService.StockControl();
            await _mailService.SendAsync(new MailDto { Body = body,Subject = "Stok Bildirimi" });
        }
    }
}
