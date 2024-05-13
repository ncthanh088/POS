using Microsoft.EntityFrameworkCore;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Infrastructure.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly POSDbContext _dbContext;

        public CategoryRepository(POSDbContext dbContext)
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
                                Color = x.Color,
                                Products = x.Products.ToList(),
                            })
                            .ToListAsync();

            return categories;
        }
    }
}
