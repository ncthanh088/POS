using POS.Domain.Entities;

namespace POS.Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public List<Product> Products { get; set; }
    }
}
