using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EReceipts.Domain.ValueObjects;

public class Contractor
{
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [Precision(18, 5)]
    public decimal Amount { get; set; }

    [Precision(18, 5)]
    public decimal Rate { get; set; }
}


