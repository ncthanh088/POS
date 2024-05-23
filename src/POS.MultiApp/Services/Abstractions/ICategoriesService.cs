using POS.MultiApp.Models;

namespace POS.MultiApp.Services
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
