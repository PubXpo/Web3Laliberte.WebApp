using System.Collections.Generic;

namespace Web3Laliberte.OperationsAPI.Model.Orders;

public class Band
{
    public int BandId { get; set; }
    public string Name { get; set; }
    public ICollection<Gift> Gifts { get; set; }
}