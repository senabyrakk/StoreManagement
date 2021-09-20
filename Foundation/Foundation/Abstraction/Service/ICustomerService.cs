using Foundation.Contract;
using System.Collections.Generic;

namespace Foundation.Abstraction.Service
{
    public interface ICustomerService
    {
        CustomerContract Get(int Id);
        List<CustomerContract> GetAll();
        CustomerContract Add(CustomerContract CustomerContract);
        void Update(CustomerContract CustomerContract);
        void Delete(int Id);
    }
}
