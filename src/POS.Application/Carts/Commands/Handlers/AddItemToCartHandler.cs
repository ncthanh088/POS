using MediatR;
using POS.Application.Repositories;
using POS.Domain.Entities;
using POS.Application.DTO;
using POS.Application.Exceptions;
using POS.Domain.ValueObjects;

namespace POS.Application.Carts.Commands.Handlers;

internal sealed class AddItemToCartHandler : IRequestHandler<AddItemToCart, CartDto>
{
    private readonly IRepository<Cart> _cartRepository;
    private readonly IRepository<Product> _productRepository;

    public AddItemToCartHandler(IRepository<Cart> cartRepository, IRepository<Product> productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    public async Task<CartDto> Handle(AddItemToCart request, CancellationToken cancellationToken)
    {
        var (userId, itemId, itemQuantity) = request;

        var itemToPay = await _productRepository
            .FindAsync(x => x.Id == new ProductId(itemId))
            ?? throw new ItemNotFoundException(itemId);

        if (itemToPay.Quantity < itemQuantity)
            throw new ItemOutOfStockException(itemId);

        var cart = await _cartRepository
            .FindAsync(x => x.UserId == new UserId(userId), includes: x => x.Items);

        cart.AddProduct(itemToPay, itemQuantity);
        await _cartRepository.UpdateAsync(cart);

        return cart.AsDto();
    }
}
