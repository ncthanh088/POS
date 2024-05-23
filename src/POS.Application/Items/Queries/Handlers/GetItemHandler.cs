using MediatR;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Application.Items.Queries.Handlers;

internal sealed class GetItemHandler : IRequestHandler<GetItem, ItemDto>
{
    private readonly IItemRepository _itemRepository;

    public GetItemHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<ItemDto> Handle(GetItem request, CancellationToken cancellationToken)
    {
        return await _itemRepository.GetItemByIdAsync(request.ItemId);
    }
}

