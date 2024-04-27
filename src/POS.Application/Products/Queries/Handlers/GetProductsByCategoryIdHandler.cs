using MediatR;
using POS.Domain.Entities;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Application.Products.Queries.Handlers;

internal sealed class GetProductsByCategoryIdHandler : IRequestHandler<GetProductByCategoryId, IEnumerable<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;

    public GetProductsByCategoryIdHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductByCategoryId request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.FindAllAsync(x => x.CategoryId == request.CategoryId);

        return products.Select(x => x.AsDto());
    }
}

