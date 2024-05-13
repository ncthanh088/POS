namespace POS.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }
        public string Color { get; private set; }

        public List<Item> Products { get; set; }

        public Category(int id, string name, string description, string icon, string color)
        {
            Id = id;
            Name = name;
            Description = description;
            Icon = icon;
            Color = color;
        }
    }
}
