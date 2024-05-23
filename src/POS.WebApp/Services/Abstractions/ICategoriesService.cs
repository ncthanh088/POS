using POS.WebApp.Models;

namespace POS.WebApp.Services
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
