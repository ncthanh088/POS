using System.Linq.Expressions;
using POS.Domain.Entities;

namespace POS.Application.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public List<Item> Items { get; set; }

        public static Expression<Func<Category, CategoryDto>> Expression
        {
            get
            {
                return category => new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    Icon = category.Icon,
                    Color = category.Color,
                    Items = category.Items,
                };
            }
        }

        public static CategoryDto Parse(Category category)
        {
            if (category == null)
                return null;
            return Expression.Compile().Invoke(category);
        }
    }
}
