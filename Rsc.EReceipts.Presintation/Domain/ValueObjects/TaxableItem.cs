namespace Rsc.EReceipts.Domain.ValueObjects;

public class TaxableItem
{
    public string TaxType { get; set; }
    public decimal Amount { get; set; }
    public string SubType { get; set; }
    public decimal Rate { get; set; }
}


