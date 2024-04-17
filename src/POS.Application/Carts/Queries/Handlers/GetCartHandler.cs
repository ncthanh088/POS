using MediatR;
using POS.Application.DTO;
using POS.Domain.Entities;
using POS.Domain.Repositories;

namespace POS.Application.Carts.Queries.Handlers;

internal sealed class GetCartHandler : IRequestHandler<GetCart, CartDto>
{
    private readonly IRepository<Cart> _cartRepository;

    public GetCartHandler(IRepository<Cart> cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CartDto> Handle(GetCart request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository
            .FindAsync(x => x.UserId == request.UserId, x => x.Items);

        return cart?.AsDto();
    }
}
