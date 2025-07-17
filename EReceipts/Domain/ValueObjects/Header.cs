using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EReceipts.Domain.ValueObjects;

public class Header
{
    [Required(ErrorMessage = "DateTimeIssued is mandatory.")]
    public DateTime DateTimeIssued { get; set; }

    [Required(ErrorMessage = "ReceiptNumber is mandatory for Header.")]
    [StringLength(50, ErrorMessage = "ReceiptNumber cannot exceed 50 characters.")]
    public string ReceiptNumber { get; set; }

    [Required(ErrorMessage = "UUID is mandatory for Header.")]
    [StringLength(256, ErrorMessage = "UUID cannot exceed 256 characters.")]
    public string Uuid { get; set; }

    [Required(ErrorMessage = "PreviousUUID is mandatory for Header.")]
    [StringLength(256, ErrorMessage = "PreviousUUID cannot exceed 256 characters.")]
    public string PreviousUuid { get; set; }

    [StringLength(256, ErrorMessage = "ReferenceOldUUID cannot exceed 256 characters.")]
    public string ReferenceOldUuid { get; set; }

    [Required(ErrorMessage = "Currency is mandatory.")]
    [StringLength(3, ErrorMessage = "Currency must be 3 characters (ISO 4217).")]
    public string Currency { get; set; }

    [Precision(18, 5)]
    public decimal ExchangeRate { get; set; }

    [StringLength(200, ErrorMessage = "SOrderNameCode cannot exceed 200 characters.")]
    public string SOrderNameCode { get; set; }

    [StringLength(30, ErrorMessage = "OrderDeliveryMode cannot exceed 30 characters.")]
    public string OrderDeliveryMode { get; set; }

    [Precision(18, 5)]
    public decimal GrossWeight { get; set; }

    [Precision(18, 5)]
    public decimal NetWeight { get; set; }
}



