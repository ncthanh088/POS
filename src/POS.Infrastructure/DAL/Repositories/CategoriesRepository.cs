using Microsoft.EntityFrameworkCore;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Infrastructure.DAL;

public class CategoryRepository : ICategoryRepository
{
    private readonly POSDbContext _dbContext;

    public CategoryRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _dbContext.Categories
                        .Include(x => x.Items)
                        .Select(x => CategoryDto.Parse(x))
                        .ToListAsync();

        return categories;
    }
}
