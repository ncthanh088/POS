using Blazored.LocalStorage;
using POS.WebApp.Models;

namespace POS.WebApp.Services;

public class CartService : ICartService
{
    public event Action OnChange;
    private readonly ILocalStorageService _localStorage;
    private readonly IProductService _productService;

    public IEnumerable<Item> CartItems = [];

    public CartService(ILocalStorageService localStorage, IProductService productService)
    {
        _localStorage = localStorage;
        _productService = productService;
    }

    public async Task AddItemToCartAsync(Item item)
    {
        var product = await _productService.GetProductAsync(item.Id);

        if (product is null)
        {
            // TODO: Handle error
        }

        var cart = await _localStorage.GetItemAsync<List<Item>>("cart");
        if (cart == null)
        {
            cart = new List<Item>();
        }

        var cartItem = cart.Find(x => x.Id == item.Id);
        if (cartItem == null)
        {
            cart.Add(item);
        }
        else
        {
            cartItem.Quantity += 1;
        }

        await _localStorage.SetItemAsync("cart", cart);


        OnChange.Invoke();
    }

    public async Task RemoveCartItemAsync(Item item)
    {
        var cart = await _localStorage.GetItemAsync<List<Item>>("cart");
        if (cart == null)
        {
            return;
        }

        var cartItem = cart.Find(x => x.Id == item.Id);
        if (cartItem != null && cartItem.Quantity == 1)
        {
            cart.Remove(cartItem);
        }
        else
        {
            cartItem.Quantity -= 1;
        }

        await _localStorage.SetItemAsync("cart", cart);
        OnChange.Invoke();
    }

    public async Task<IEnumerable<Item>> GetCartItemsAsync()
    {
        var items = await _localStorage.GetItemAsync<IEnumerable<Item>>("cart");

        CartItems = items;
        return items ?? [];
    }

    public async Task EmptyCart()
    {
        await _localStorage.RemoveItemAsync("cart");
        OnChange.Invoke();
    }
}
