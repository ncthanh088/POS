using Microsoft.EntityFrameworkCore;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Infrastructure.DAL
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly POSDbContext _dbContext;

        public CategoriesRepository(POSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _dbContext.Categories
                            .Include(x => x.Products)
                            .Select(x => new CategoryDTO
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Description = x.Description,
                                Icon = x.Icon,
                                Products = x.Products.ToList(),
                            })
                            .ToListAsync();

            return categories;
        }
    }
}
