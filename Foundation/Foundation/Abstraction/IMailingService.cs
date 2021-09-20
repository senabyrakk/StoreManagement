using Foundation.Dto;
using System.Threading.Tasks;

namespace Foundation.Abstraction
{
    public interface IMailingService
    {
        Task<bool> SendAsync(MailDto mailingDto); 
    }
}
