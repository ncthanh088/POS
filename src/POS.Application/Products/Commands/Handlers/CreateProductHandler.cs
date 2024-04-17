using MediatR;
using POS.Application.Repositories;
using POS.Domain.Entities;
using POS.Domain.Enums;
using POS.Domain.Types;

namespace POS.Application.Products.Commands.Handlers
{
    internal sealed class CreateProductHandler : IRequestHandler<CreateProduct>
    {
        private readonly IRepository<Product> _productRepository;

        public CreateProductHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var product = new Product(id: Guid.NewGuid(),
                                      request.Name,
                                      request.Description,
                                      request.Type.ToEnum(ProductType.Other),
                                      request.Vendor,
                                      request.Price,
                                      request.Quantity,
                                      request.ImageUrl,
                                      request.CategoryId);

            await _productRepository.AddAsync(product);

            return Unit.Value;
        }
    }
}
