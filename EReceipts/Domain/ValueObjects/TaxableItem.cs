using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EReceipts.Domain.ValueObjects;

public class TaxableItem
{
    [Required(ErrorMessage = "TaxType is mandatory.")]
    [StringLength(30, ErrorMessage = "TaxType cannot exceed 30 characters.")]
    public string TaxType { get; set; }

    [Required(ErrorMessage = "Tax Amount is mandatory.")]
    [Precision(18, 5)]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "SubType is mandatory.")]
    [StringLength(50, ErrorMessage = "SubType cannot exceed 50 characters.")]
    public string SubType { get; set; }

    [Precision(18, 5)]
    [Range(0, 100, ErrorMessage = "Rate must be between 0 and 100.")]
    public decimal Rate { get; set; }
}


