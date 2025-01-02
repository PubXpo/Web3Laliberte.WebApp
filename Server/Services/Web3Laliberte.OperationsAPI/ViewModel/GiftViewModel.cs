using System;

namespace Web3Laliberte.OperationsAPI.ViewModel;

public class GiftViewModel
{
    public Guid GiftId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int InventoryAmount { get; set; }
}