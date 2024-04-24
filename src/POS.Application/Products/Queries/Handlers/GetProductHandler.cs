using MediatR;
using POS.Domain.Entities;
using POS.Application.DTO;
using POS.Application.Repositories;

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
        var product = await _productRepository.FindAsync(x => x.Id == request.ProductId);

        return product.AsDto();
    }
}

