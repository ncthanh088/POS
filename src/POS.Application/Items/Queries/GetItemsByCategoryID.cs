using MediatR;
using POS.Application.DTO;

namespace POS.Application.Items.Queries;

public record GetItemsByCategoryID(int CategoryID) : IRequest<IEnumerable<ItemDto>>;
