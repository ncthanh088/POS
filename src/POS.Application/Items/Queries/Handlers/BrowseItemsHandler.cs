using MediatR;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Application.Items.Queries.Handlers;

public class BrowseItemsHandler : IRequestHandler<BrowseItems, IEnumerable<ItemDto>>
{
    private readonly IItemRepository _itemRepository;

    public BrowseItemsHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<ItemDto>> Handle(BrowseItems request, CancellationToken cancellationToken)
    {
        return await _itemRepository.GetItemsAsync();
    }
}

