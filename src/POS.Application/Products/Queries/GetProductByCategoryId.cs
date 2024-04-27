using MediatR;
using POS.Application.DTO;

namespace POS.Application.Products.Queries;

public record GetProductByCategoryId(int CategoryId) : IRequest<IEnumerable<ProductDto>>;
