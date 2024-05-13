using POS.WebApp.Models;

namespace POS.WebApp.Services;

public interface ICartService
{
    Task AddItemToCartAsync(Item item);
    Task RemoveCartItemAsync(Item item);
    Task<IEnumerable<Item>> GetCartItemsAsync();
    Task EmptyCart();
    event Action OnChange;
}
