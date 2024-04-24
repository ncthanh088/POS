using POS.Domain.Entities;
using POS.Domain.Enums;
using POS.Application.Repositories;

namespace POS.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> HasPendingOrderAsync(Guid userId)
        {
            return await _orderRepository
                .AnyAsync(x => x.UserId == userId
                    && x.Status == OrderStatus.Created
                    || x.Status == OrderStatus.Approved);
        }
    }
}
