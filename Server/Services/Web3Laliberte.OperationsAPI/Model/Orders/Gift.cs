using System;

namespace Web3Laliberte.OperationsAPI.Model.Orders;

public class Gift
{
    public Guid GiftId { get; set; }
    public int BandId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int InventoryAmount { get; set; }
    public Band Band { get; set; }
}