using StoreManagement.Domain.Model;

namespace Foundation.Abstraction.Repository
{
    public interface IProductRepository : IEfRepository<Product>
    {
        string StockControl();
    }
}
