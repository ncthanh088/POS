using MediatR;
using POS.Application.DTO;
using POS.Domain.Entities;
using POS.Domain.Repositories;

namespace POS.Application.Products.Queries.Handlers;

public class BrowseProductsHandler : IRequestHandler<BrowseProducts, IEnumerable<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;

    public BrowseProductsHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(BrowseProducts request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.FindAllAsync();

        return products.Select(x => x.AsDto());
    }
}

