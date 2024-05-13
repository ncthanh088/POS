using MediatR;
using POS.Domain.Types;
using POS.Domain.Enums;
using POS.Domain.Entities;
using POS.Application.Repositories;

namespace POS.Application.Items.Commands.Handlers
{
    internal sealed class CreateItemHandler : IRequestHandler<CreateItem>
    {
        private readonly IRepository<Item> _itemRepository;

        public CreateItemHandler(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Unit> Handle(CreateItem request, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = request.Name,
                Description = request.Description,
                Type = request.Type.ToEnum(ItemType.Other),
                Vendor = request.Vendor,
                Price = request.Price,
                Quantity = request.Quantity,
                ImageUrl = request.ImageUrl,
                CategoryID = request.CategoryID
            };

            await _itemRepository.AddAsync(item);
            return Unit.Value;
        }
    }
}
