using MediatR;
using POS.Application.DTO;

namespace POS.Application.Products.Queries;

public record BrowseProducts : IRequest<IEnumerable<ProductDto>>;
