using MediatR;
using POS.Application.DTO;

namespace POS.Application.Products.Queries;
public record GetProduct(Guid ProductId) : IRequest<ProductDto>;
