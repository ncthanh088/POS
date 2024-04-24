using MediatR;
using POS.Domain.Entities;
using POS.Application.Repositories;

namespace POS.Application.Carts.Commands.Handlers;

public class RemoveItemFromCartHandler : IRequestHandler<RemoveItemFromCart>
{
    private readonly IRepository<Cart> _cartRepository;
    private readonly IRepository<Item> _itemRepository;

    public RemoveItemFromCartHandler(IRepository<Cart> cartRepository, IRepository<Item> itemRepository)
    {
        _cartRepository = cartRepository;
        _itemRepository = itemRepository;
    }

    public async Task<Unit> Handle(RemoveItemFromCart request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository
            .FindAsync(x => x.UserId == request.UserId, x => x.Items);

        var item = cart
            .Items
            .FirstOrDefault(x => x.ProductId == request.ProductId);

        await _itemRepository.DeleteAsync(item);

        return Unit.Value;
    }
}
