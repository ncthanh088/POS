namespace POS.Application.Services
{
    public interface IOrderService
    {
        Task<bool> HasPendingOrderAsync(Guid userId);
    }
}
