using POS.WebApp.Models;

namespace POS.WebApp.Services;

public interface IItemService
{
    Task<IEnumerable<Item>> GetItemsByCategoryIdAsync(int categoryId);
    Task<Item> GetItemAsync(int itemId);
    event Action OnChange;
}
