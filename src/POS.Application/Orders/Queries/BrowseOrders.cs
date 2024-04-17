using MediatR;
using POS.Application.DTO;
using POS.Domain.ValueObjects;

namespace POS.Application.Orders.Queries;

public record BrowseOrders(UserId UserId) : IRequest<IEnumerable<OrderDto>>;

