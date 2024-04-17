using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions
{
    public class ItemOutOfStockException : GlobalException
    {
        public Guid ItemId { get; }

        public ItemOutOfStockException(Guid itemId)
            : base($"Item with ID: '{itemId}' was out of stock.")
        {
            ItemId = itemId;
        }
    }
}
