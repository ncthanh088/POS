using System.Text.Json.Serialization;

namespace POS.WebApp.Models;

public class Item
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public string Name { get; set; }
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }

    [JsonIgnore]
    public Product Product { get; set; }
    public decimal UnitPrice { get; set; }
    public int TaxIdentity { get; set; }

    public decimal RegularUnitPrice { get; set; }
    public decimal ActualUnitPrice { get; set; }
    public decimal ExtendedPrice { get; set; }
    public decimal TaxAmount { get; set; }
    public bool IsMemberBenefit { get; set; }
    public bool IsVocher { get; set; }
    public int Quantity { get; set; } = 0;

    [JsonIgnore]
    public decimal TotalPrice => Quantity * UnitPrice;

}
