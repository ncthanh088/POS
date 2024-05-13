using MediatR;
using POS.Application.DTO;

namespace POS.Application.Items.Queries;

public record BrowseItems : IRequest<IEnumerable<ItemDto>>;
