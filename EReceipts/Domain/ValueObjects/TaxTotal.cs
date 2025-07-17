using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EReceipts.Domain.ValueObjects;

public class TaxTotal
{
    [Required(ErrorMessage = "TaxType is mandatory for TaxTotal.")]
    [StringLength(30, ErrorMessage = "TaxType cannot exceed 30 characters.")]
    public string TaxType { get; set; }

    [Required(ErrorMessage = "Tax Total Amount is mandatory.")]
    [Precision(18, 5)]
    public decimal Amount { get; set; }
}

