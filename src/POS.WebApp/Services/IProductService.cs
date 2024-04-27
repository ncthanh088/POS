using POS.WebApp.Models;

namespace POS.WebApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
