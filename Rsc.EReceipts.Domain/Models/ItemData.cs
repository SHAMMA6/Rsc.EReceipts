namespace Rsc.EReceipts.Domain.Models;

public class ItemData
{
    public string InternalCode { get; private set; }
    public string Description { get; private set; }
    public string ItemType { get; private set; }
    public string ItemCode { get; private set; }
    public string UnitType { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal NetSale { get; private set; }
    public decimal TotalSale { get; private set; }

}

