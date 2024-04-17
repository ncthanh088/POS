using MediatR;
using POS.Application.DTO;
using POS.Domain.Entities;
using POS.Domain.Repositories;
using POS.Domain.ValueObjects;

namespace POS.Application.Products.Queries.Handlers;

internal sealed class GetProductHandler : IRequestHandler<GetProduct, ProductDto>
{
    private readonly IRepository<Product> _productRepository;

    public GetProductHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProduct request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindAsync(x => x.Id == new ProductId(request.ProductId));

        return product.AsDto();
    }
}

