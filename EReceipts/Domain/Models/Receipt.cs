using EReceipts.Domain.Enums;
using EReceipts.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace EReceipts.Domain.Models;

public class Receipt
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "ReceiptNumber is mandatory.")]
    [StringLength(50, ErrorMessage = "ReceiptNumber cannot exceed 50 characters.")]
    public string ReceiptNumber { get; set; }

    [Required(ErrorMessage = "UUID is mandatory.")]
    [StringLength(256, ErrorMessage = "UUID cannot exceed 256 characters (SHA256 format expected).")]
    public string Uuid { get; set; }

    [Required(ErrorMessage = "PreviousUUID is mandatory.")]
    [StringLength(256, ErrorMessage = "PreviousUUID cannot exceed 256 characters (SHA256 format expected).")]
    public string PreviousUuid { get; set; }

    [StringLength(256, ErrorMessage = "ReferenceOldUUID cannot exceed 256 characters.")]
    public string ReferenceOldUuid { get; set; }

    [Required(ErrorMessage = "Header information is mandatory.")]
    public Header Header { get; set; }

    [Required(ErrorMessage = "Document type information is mandatory.")]
    public DocumentType DocumentType { get; set; }

    [Required(ErrorMessage = "Seller information is mandatory.")]
    public Seller Seller { get; set; }

    [Required(ErrorMessage = "Buyer information is mandatory.")]
    public Buyer Buyer { get; set; }

    [Required(ErrorMessage = "ItemData collection is mandatory.")]
    public List<ItemData> ItemData { get; set; } = new List<ItemData>();

    [Required(ErrorMessage = "TotalSales is mandatory.")]
    [Precision(18, 5)] 
    public decimal TotalSales { get; set; }

    [Precision(18, 5)]
    public decimal TotalCommercialDiscount { get; set; }

    [Precision(18, 5)]
    public decimal TotalItemsDiscount { get; set; }

    public List<DiscountData> ExtraReceiptDiscountData { get; set; } = new List<DiscountData>();

    [Required(ErrorMessage = "NetAmount is mandatory.")]
    [Precision(18, 5)]
    public decimal NetAmount { get; set; }

    [Precision(18, 5)]
    public decimal FeesAmount { get; set; }

    [Required(ErrorMessage = "TotalAmount is mandatory.")]
    [Precision(18, 5)]
    public decimal TotalAmount { get; set; }

    public List<TaxTotal> TaxTotals { get; set; } = new List<TaxTotal>();

    [Required(ErrorMessage = "PaymentMethod is mandatory.")]
    [StringLength(50, ErrorMessage = "PaymentMethod cannot exceed 50 characters.")]
    public string PaymentMethod { get; set; }

    [Precision(18, 5)]
    public decimal Adjustment { get; set; }

    public Contractor Contractor { get; set; }

    public Beneficiary Beneficiary { get; set; }
}

