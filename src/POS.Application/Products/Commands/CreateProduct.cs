using MediatR;

namespace POS.Application.Products.Commands;
public record CreateProduct(Guid Id, string Name, string Description, string Type,
    string Vendor, decimal Price, int Quantity, string ImageUrl, int CategoryId) : IRequest;
