using MediatR;
using POS.Application.DTO;

namespace POS.Application.Orders.Queries;

public record BrowseOrders(Guid UserId) : IRequest<IEnumerable<OrderDto>>;

