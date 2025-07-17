using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EReceipts.Domain.Models;

public class ItemData
{
    [Required(ErrorMessage = "InternalCode is mandatory.")]
    [StringLength(50, ErrorMessage = "InternalCode cannot exceed 50 characters.")]
    public string InternalCode { get; set; }

    [Required(ErrorMessage = "Description is mandatory.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "ItemType is mandatory.")]
    [StringLength(30, ErrorMessage = "ItemType cannot exceed 30 characters.")]
    [RegularExpression("^(GS1|EGS)$", ErrorMessage = "ItemType must be 'GS1' or 'EGS'.")]
    public string ItemType { get; set; }

    [Required(ErrorMessage = "ItemCode is mandatory.")]
    [StringLength(100, ErrorMessage = "ItemCode cannot exceed 100 characters.")]
    public string ItemCode { get; set; }

    [Required(ErrorMessage = "UnitType is mandatory.")]
    [StringLength(30, ErrorMessage = "UnitType cannot exceed 30 characters.")]
    public string UnitType { get; set; }

    [Required(ErrorMessage = "Quantity is mandatory.")]
    [Range(0.00001, double.MaxValue, ErrorMessage = "Quantity must be larger than 0.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "UnitPrice is mandatory.")]
    [Precision(18, 5)]
    public decimal UnitPrice { get; set; }

    [Required(ErrorMessage = "NetSale is mandatory.")]
    [Precision(18, 5)]
    public decimal NetSale { get; set; }

    [Required(ErrorMessage = "TotalSale is mandatory.")]
    [Precision(18, 5)]
    public decimal TotalSale { get; set; }

    [Required(ErrorMessage = "Total is mandatory.")]
    [Precision(18, 5)]
    public decimal Total { get; set; }

    public List<ValueObjects.DiscountData> CommercialDiscountData { get; set; } = new List<ValueObjects.DiscountData>();

    public List<ValueObjects.DiscountData> ItemDiscountData { get; set; } = new List<ValueObjects.DiscountData>();

    public ValueObjects.DiscountData AdditionalCommercialDiscount { get; set; }

    public ValueObjects.DiscountData AdditionalItemDiscount { get; set; }

    [Precision(18, 5)]
    public decimal ValueDifference { get; set; }

    public List<ValueObjects.TaxableItem> TaxableItems { get; set; } = new List<ValueObjects.TaxableItem>();
}

