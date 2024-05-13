using POS.Domain.Entities;
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
                            .Select(x => new ItemDto
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Description = x.Description,
                                ImageUrl = x.ImageUrl,
                                Vendor = x.Vendor,
                                Price = x.Price,
                                Quantity = x.Quantity,
                                Type = Domain.Enums.ItemType.Other,
                            }).FirstOrDefaultAsync();

        return item;
    }

    public async Task<IEnumerable<ItemDto>> GetItemsByCategoryIdAsync(int categoryId)
    {
        var items = await _dbContext.Items
                    .Where(x => x.CategoryID == categoryId && x.IsActived)
                    .Select(x => new ItemDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        ImageUrl = x.ImageUrl,
                        Vendor = x.Vendor,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Type = Domain.Enums.ItemType.Other,
                    }).ToListAsync();

        return items;
    }

    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
        var items = await _dbContext.Items.Where(x => x.IsActived).ToListAsync();
        return items.Select(x => x.AsDto());
    }

    public Task<IEnumerable<ItemDto>> GetCartItemsAsync(IEnumerable<int> itemIDs)
    {
        throw new NotImplementedException();
    }
}
