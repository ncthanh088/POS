using MediatR;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Application.Items.Queries.Handlers;

internal sealed class GetItemsByCategoryIDHandler : IRequestHandler<GetItemsByCategoryId, IEnumerable<ItemDto>>
{
    private readonly IItemRepository _itemRepository;

    public GetItemsByCategoryIDHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<ItemDto>> Handle(GetItemsByCategoryId request, CancellationToken cancellationToken)
    {
        var products = await _itemRepository.GetItemsByCategoryIdAsync(request.CategoryID);

        return products;
    }
}

