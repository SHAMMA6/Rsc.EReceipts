using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EReceipts.Domain.ValueObjects;

public class DiscountData
{
    [Required(ErrorMessage = "Discount Amount is mandatory.")]
    [Precision(18, 5)]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Discount Description is mandatory.")]
    [StringLength(50, ErrorMessage = "Description cannot exceed 50 characters.")]
    public string Description { get; set; }

    [Precision(18, 5)]
    [Range(0, 100, ErrorMessage = "Rate must be between 0 and 100.")]
    public decimal Rate { get; set; }
}
