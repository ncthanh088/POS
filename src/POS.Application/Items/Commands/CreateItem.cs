using MediatR;

namespace POS.Application.Items.Commands;
public record CreateItem(
    int Id,
    string Name,
    string Description,
    string Type,
    string Vendor,
    decimal Price,
    int Quantity,
    string ImageUrl,
    int CategoryID) : IRequest;
