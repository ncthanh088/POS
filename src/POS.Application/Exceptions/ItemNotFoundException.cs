using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions
{
    public class ItemNotFoundException : GlobalException
    {
        public Guid ItemId { get; }

        public ItemNotFoundException(Guid itemId) : base($"Item with ID: '{itemId}' was not found.")
        {
            ItemId = itemId;
        }

    }
}
