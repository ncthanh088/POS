using MediatR;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Application.Products.Queries.Handlers;

internal sealed class GetProductHandler : IRequestHandler<GetItem, ProductDto>
{
    private readonly IItemsRepository _productRepository;

    public GetProductHandler(IItemsRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetItem request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetProductByIdAsync(request.ProductId);
    }
}

