using Rsc.EReceipts.Domain.Enums;
using Rsc.EReceipts.Domain.ValueObjects;

namespace Rsc.EReceipts.Domain.Models;

public class Receipt
{
    public Guid Id { get; private set; }       //  Momken Nemsa7a //
    public string ReceiptNumber { get; private set; }
    public string Uuid { get; private set; } 
    public string PreviousUuid { get; private set; } 
    public string ReferenceOldUuid { get; private set; } 
    public Header Header { get; private set; }
    public DocumentType DocumentType { get; private set; }
    public Seller Seller { get; private set; }
    public Buyer Buyer { get; private set; }
    public decimal TotalSales { get; private set; }
    public decimal TotalCommercialDiscount { get; private set; }
    public decimal TotalItemsDiscount { get; private set; }
    public decimal NetAmount { get; private set; }
    public decimal FeesAmount { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string PaymentMethod { get; private set; }
    public decimal Adjustment { get; private set; }
    public Contractor Contractor { get; private set; }
    public Beneficiary Beneficiary { get; private set; }
}