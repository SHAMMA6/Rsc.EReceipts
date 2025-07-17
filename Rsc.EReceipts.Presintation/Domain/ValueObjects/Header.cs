namespace Rsc.EReceipts.Domain.ValueObjects;

public class Header
{
    public DateTime DateTimeIssued { get; set; }
    public string ReceiptNumber { get; set; }
    public string Uuid { get; set; }
    public string PreviousUuid { get; set; }
    public string ReferenceOldUuid { get; set; }
    public string Currency { get; set; }
    public decimal ExchangeRate { get; set; }
    public string SOrderNameCode { get; set; }
    public string OrderDeliveryMode { get; set; }
    public decimal GrossWeight { get; set; }
    public decimal NetWeight { get; set; }
}



