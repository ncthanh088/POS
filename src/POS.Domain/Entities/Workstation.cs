namespace POS.Domain.Entities;

public class Workstation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DeviceAddress { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
}
