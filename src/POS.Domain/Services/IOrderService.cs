using POS.Domain.ValueObjects;

namespace POS.Domain.Services
{
    public interface IOrderService
    {
        Task<bool> HasPendingOrderAsync(UserId userId);
    }
}
