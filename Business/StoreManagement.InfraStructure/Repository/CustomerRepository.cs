using Foundation.Abstraction.Repository;
using ScheduleControl.Core.DataAccess.EntityFramework;
using StoreManagement.Domain.Model;
using StoreManagement.Infrastructure.DataContext;

namespace StoreManagement.Infrastructure.Repository
{
    public class CustomerRepository : EfEntityRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(StoreDbContext db) : base(db)
        {
        }
    }
}
