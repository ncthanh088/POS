using POS.MultiApp.Models;

namespace POS.MultiApp.Services;

public interface IItemService
{
    Task<IEnumerable<Item>> GetItemsByCategoryIdAsync(int categoryId);
    Task<Item> GetItemAsync(int itemId);
    event Action OnChange;
}
