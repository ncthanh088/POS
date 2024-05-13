using POS.Application.DTO;
using POS.Domain.Entities;

namespace POS.Application.Repositories;

public interface IItemRepository
{
    Task<ItemDto> GetItemByIdAsync(int itemID);
    Task<IEnumerable<ItemDto>> GetItemsByCategoryIdAsync(int categoryID);
    Task<IEnumerable<ItemDto>> GetItemsAsync();
    Task<IEnumerable<ItemDto>> GetCartItemsAsync(IEnumerable<int> itemIDs);
}
