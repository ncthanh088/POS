namespace POS.MultiApp.Models;

public class Discount
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public bool InclusiveOfTax { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}
