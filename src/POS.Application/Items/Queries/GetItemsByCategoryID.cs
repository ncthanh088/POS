using MediatR;
using POS.Application.DTO;

namespace POS.Application.Items.Queries;

public record GetItemsByCategoryId(int CategoryID) : IRequest<IEnumerable<ItemDto>>;
