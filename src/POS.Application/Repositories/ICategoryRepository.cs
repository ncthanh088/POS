using POS.Application.DTO;

namespace POS.Application.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}
