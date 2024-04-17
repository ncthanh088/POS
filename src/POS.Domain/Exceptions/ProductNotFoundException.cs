using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions;

public class ProductNotFoundException : GlobalException
{
    public Guid ProductId { get; set; }
    public ProductNotFoundException(Guid productId) : base($"Product with Id: '{productId}' was not found.")
    {
        ProductId = productId;
    }
}
