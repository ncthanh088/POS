namespace POS.Application.DTO;

public class CartDto
{
    public Guid Id { get; set; }
    public IEnumerable<ItemDto> Items { get; set; }
}
