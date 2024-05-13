using POS.Domain.Entities;

namespace POS.Application.DTO
{
    public static class Extensions
    {

        public static UserDto AsDto(this User user)
        {
            return new()
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
            };
        }

        public static ItemDto AsDto(this Item item)
        {
            return new()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Type = item.Type,
                Vendor = item.Vendor,
                Price = item.Price,
                Quantity = item.Quantity,
                ImageUrl = item.ImageUrl,
            };
        }

        public static CategoryDTO AsDto(this Category category)
        {
            return new()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Icon = category.Icon,
                Products = category.Products,
            };
        }
    }
}
