using System.Threading.Tasks;

namespace StoreManagement.BackgroundJob.Managers.FireAndForgetJobs
{
    public class CartCheckJobManager
    {
        public async Task Process(int productId)
        {
           //sepetler kontrol edilicek. Silinen ürün bulunan sepetler silinecek.

        }
    }
}
