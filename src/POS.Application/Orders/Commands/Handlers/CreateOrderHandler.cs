using MediatR;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;
using POS.Application.Services;
using POS.Application.Repositories;
using POS.Application.Exceptions;

namespace POS.Application.Orders.Commands.Handlers;

internal sealed class CreateOrderHandler : IRequestHandler<CreateOrder>
{
    private readonly IOrderService _orderService;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Cart> _cartRepository;

    public CreateOrderHandler(IOrderService orderService,
                              IRepository<Order> orderRepository,
                              IRepository<Cart> cartRepository)
    {
        _orderService = orderService;
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
    }

    public async Task<Unit> Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.UserId);

        if (await _orderService.HasPendingOrderAsync(userId))
        {
            throw new PendingOrderException(request.UserId);
        }

        var cart = await _cartRepository.FindAsync(x => x.UserId == userId);

        var items = cart.Items
            .Select(x => new Item(x.ProductId, x.ProductName, x.ImageUrl, x.Quantity, x.UnitPrice))
            .ToList();

        // FIXME: Create currency type for "VND", "USD", "YUAN", etc.
        var order = new Order(request.OrderId, request.UserId, items, "USD");
        await _orderRepository.AddAsync(order);

        return Unit.Value;
    }
}
