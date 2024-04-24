using POS.Domain.Exceptions;

namespace POS.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        private ISet<Item> _items = new HashSet<Item>();
        public DateTime CreatedAt { get; private set; }

        public IEnumerable<Item> Items
        {
            get => _items;
            set => _items = new HashSet<Item>(value);
        }

        protected Cart()
        {
        }

        public Cart(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }

        public void Clear()
            => _items.Clear();

        public void AddProduct(Product product, int quantity)
        {
            var item = GetItem(product.Id);

            if (item != null)
            {
                item.IncreaseQuantity(quantity);

                return;
            }

            item = new Item(product, quantity);
            _items.Add(item);
        }

        public void DeleteProduct(Guid productId)
        {
            var item = GetItem(productId);

            if (item is null)
                throw new ProductNotFoundException(productId);

            _items.Remove(item);
        }

        public void UpdateProduct(Product product)
        {
            var item = GetItem(product.Id);

            if (item is null)
                throw new ProductNotFoundException(product.Id);

            item.Update(product);
        }

        private Item GetItem(Guid productId)
            => _items.FirstOrDefault(x => x.ProductId == productId);
    }
}
