using Foundation.Contract;
using System.Collections.Generic;

namespace Foundation.Abstraction.Service
{
    public interface IProductService
    {
        ProductContract Get(int Id);
        List<ProductContract> GetAll();
        ProductContract Add(ProductContract ProductContract);
        void Update(ProductContract ProductContract);
        void Delete(int Id);
        string StockControl();
    }
}
