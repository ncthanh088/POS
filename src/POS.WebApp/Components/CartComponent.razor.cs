using POS.WebApp.Models;

namespace POS.WebApp.Components;

public partial class CartComponent
{
    public IEnumerable<Item> Items { get; set; }

    protected override void OnInitialized()
    {
        Items = new List<Item> {
            new Item {
                CartId = new Guid("275edd23-a9a3-4c69-adea-f41c9ba7bdb8"),
                Product = new Product {
                    Id = new Guid("c1b32020-8e19-4005-8cdc-a2635404214c"),
                    Name = "Latte"
                },
                UnitPrice = 99.00M,
                Quantity = 2,
            },
            new Item {
                CartId = new Guid("3b45ec94-2bb7-461a-a4f3-7a3c15335dac"),
                Product = new Product {
                    Id = new Guid("f90f0b4e-1ad8-46e7-9103-3741cf354a41"),
                    Name = "Bnana"
                },
                UnitPrice = 19.00M,
                Quantity = 1,
            },
            new Item {
                CartId = new Guid("468b2986-8a00-4723-b657-0b7e36626246"),
                Product = new Product {
                    Id = new Guid("39de0ab2-c7e0-4e8e-bf89-95e37a58f650"),
                    Name = "Chocolate"
                },
                UnitPrice = 10.06M,
                Quantity = 5,
            },
            new Item {
                CartId = new Guid("83cc6fd5-3bee-4dfa-b4af-84f542c316ae"),
                Product = new Product {
                    Id = new Guid("39a8ac40-7b84-46b4-b182-d9ac738de7a1"),
                    Name = "Rice"
                },
                UnitPrice = 18.50M,
                Quantity = 1,
            },
        };
    }
}
