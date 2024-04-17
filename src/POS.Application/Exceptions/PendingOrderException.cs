using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions
{
    public class PendingOrderException : GlobalException
    {
        public Guid UserId { get; }
        public PendingOrderException(Guid userId)
            : base($"Customer with id: '{userId}' has already a pending order.")
        {
            UserId = userId;
        }
    }
}
