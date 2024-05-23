using POS.MultiApp.Models;

namespace POS.MultiApp.Services.Abstractions;

public interface ICartService
{
    Task AddItemToCartAsync(CartItem cartItem);
    Task RemoveCartItemAsync(CartItem cartItem);
    Task UpdateCartInforAsync(CartInfo cartInfo);
    Task PrepareCartInfoDataAsync();
    Task ProcessPaymentAsync();
    Task<CartInfo> GetCartInfoAsync();
    Task EmptyCart();
    event Action OnChange;
}
