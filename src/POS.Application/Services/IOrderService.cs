using POS.Domain.ValueObjects;

namespace POS.Application.Services
{
    public interface IOrderService
    {
        Task<bool> HasPendingOrderAsync(UserId userId);
    }
}
