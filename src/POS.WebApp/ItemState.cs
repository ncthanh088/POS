using POS.WebApp.Models;

namespace POS.WebApp;

public class ItemState
{
    public Dictionary<Guid, (Product product, int quantity)> CartItems { get; private set; } = new Dictionary<Guid, (Product product, int quantity)>();

    public event Action OnChange;

    public void AddItemToCart(Product product, int quantity = 1)
    {
        if (CartItems.ContainsKey(product.Id))
        {
            CartItems[product.Id] = (product, CartItems[product.Id].quantity + quantity);
        }
        else
        {
            CartItems.Add(product.Id, (product, quantity));
        }
        NotifyStateChanged();
    }

    public void RemoveItemFromCart(Product product, int quantity = 1)
    {
        if (CartItems.ContainsKey(product.Id))
        {
            var newQuantity = CartItems[product.Id].quantity - quantity;
            if (newQuantity <= 0)
            {
                CartItems.Remove(product.Id);
            }
            else
            {
                CartItems[product.Id] = (product, newQuantity);
            }
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
