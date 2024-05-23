using POS.Application.DTO;
using POS.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace POS.Infrastructure.DAL.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly POSDbContext _dbContext;

    public ItemRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ItemDto> GetItemByIdAsync(int ItemId)
    {
        var item = await _dbContext.Items
            .Where(x => x.Id == ItemId && x.IsActived)
            .Include(x => x.Tax)
            .Select(x => ItemDto.Parse(x))
            .FirstOrDefaultAsync();

        return item;
    }

    public async Task<IEnumerable<ItemDto>> GetItemsByCategoryIdAsync(int categoryId)
    {
        var items = await _dbContext.Items
            .Where(x => x.CategoryId == categoryId && x.IsActived)
            .Select(x => ItemDto.Parse(x))
            .ToListAsync();

        return items;
    }

    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
        var items = await _dbContext.Items
            .Where(x => x.IsActived)
            .Select(x => ItemDto.Parse(x))
            .ToListAsync();

        return items;
    }

    public async Task<IEnumerable<ItemDto>> GetCartItemsAsync(IEnumerable<int> itemIds)
    {
        var cartItems = await _dbContext.Items
            .Where(x => itemIds.Contains(x.Id) && x.IsActived)
            .Include(x => x.Tax)
            .Select(x => ItemDto.Parse(x))
            .ToListAsync();

        return cartItems;
    }
}
