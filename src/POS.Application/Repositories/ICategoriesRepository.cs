using POS.Application.DTO;

namespace POS.Application.Repositories
{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    }
}
