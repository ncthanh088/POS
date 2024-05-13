using POS.WebApp.Models;

namespace POS.WebApp.Services;

public interface IOrderService
{
    Task<Guid> PlaceOrderAsync(PlaceOrderRequest order);
}
