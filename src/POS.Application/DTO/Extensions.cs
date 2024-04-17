using POS.Domain.Entities;

namespace POS.Application.DTO
{
    public static class Extensions
    {
        public static CartDto AsDto(this Cart cart)
        {
            return new()
            {
                Id = cart.UserId,
                Items = cart.Items.Select(x => new ItemDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity
                })
            };
        }

        public static OrderDto AsDto(this Order order)
        {
            return new()
            {
                Id = order.Id,
                UserId = order.UserId,
                ItemsCount = order.Items.Count(),
                TotalAmount = order.TotalAmount,
                Currency = order.Currency,
                Status = order.Status.ToString().ToLowerInvariant()
            };
        }

        public static UserDto AsDto(this User user)
        {
            return new()
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
            };
        }

        public static ProductDto AsDto(this Product product)
        {
            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Type = product.Type,
                Vendor = product.Vendor,
                Price = product.Price,
                Quantity = product.Quantity,
                ImageUrl = product.ImageUrl,
            };
        }

        public static CategoryDTO AsDto(this Category category)
        {
            return new()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Products = category.Products,
            };
        }
    }
}
