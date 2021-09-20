using Foundation.Abstraction.Repository;
using ScheduleControl.Core.DataAccess.EntityFramework;
using StoreManagement.Domain.Model;
using StoreManagement.Infrastructure.DataContext;
using System.Linq;
using System.Text;

namespace StoreManagement.Infrastructure.Repository
{
    public class ProductRepository : EfEntityRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(StoreDbContext db) : base(db)
        {
        }
        public string StockControl()
        {
                var gruop = _dbContext.Product.GroupBy(x => x.Name).Select(x => new {
                    x.Key,
                    stockCount = x.Count()
                }).ToList();

                StringBuilder message = new StringBuilder();

                foreach (var item in gruop)
                {
                    message.AppendLine($"{item.Key} ürününden toplam {item.stockCount} adet bulunmaktadır.");
                }

                return message.ToString();
            
        }
    }
}
